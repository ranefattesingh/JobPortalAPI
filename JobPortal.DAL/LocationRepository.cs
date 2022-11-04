using Common.Exception;
using JobPortal.DAL.DataEntities;
using Persistance.EntityFramework;
using Persistance.EntityFramework.Models;
using System.Diagnostics.Metrics;

namespace JobPortal.DAL
{
    public interface ILocationRepository
    {
        public LocationDE CreateLocation(LocationDE location);
        public LocationDE? UpdateLocation(int id, LocationDE location);
        public IEnumerable<LocationDE> GetLocations();
    }
    public class LocationRepository : ILocationRepository
    {
        private readonly JobPortalContext _context;
        public LocationRepository(JobPortalContext context)
        {
            _context = context;
        }
        public LocationDE CreateLocation(LocationDE locationDE)
        {
            var locationModel = new Location
            {
                Title = locationDE.Title,
                City = locationDE.City,
                State = locationDE.State,
                Country = locationDE.Country,
                Zip = locationDE.Zip,
            };

            _context.Add(locationModel);
            _context.SaveChanges();

            var createdLocation =  new LocationDE
            {
                ID = locationModel.ID,
                Title = locationModel.Title,
                City = locationModel.City,
                State = locationModel.State,
                Country = locationModel.Country,
                Zip = locationModel.Zip,
            };

            return createdLocation;
        }

        public IEnumerable<LocationDE> GetLocations()
        {
            var locationDEList = _context.Locations.Select(l => new LocationDE
            {
                ID = l.ID,
                Title = l.Title,
                City = l.City,
                State = l.State,
                Country = l.Country,
                Zip = l.Zip,
            }).ToList();

            return locationDEList;
        }

        public LocationDE? UpdateLocation(int id, LocationDE locationDE)
        {
           var existingLocation = _context.Find<Location>(id);
            if(existingLocation == null)
            {
                throw new NotFoundException("location", id);
            }

            existingLocation.Title = locationDE.Title;
            existingLocation.City = locationDE.City;
            existingLocation.State = locationDE.State;
            existingLocation.Country = locationDE.Country;
            existingLocation.Zip = locationDE.Zip;

            _context.Update(existingLocation);
            _context.SaveChanges();

            var updatedLocation = new LocationDE
            {
                ID = existingLocation.ID,
                Title = existingLocation.Title,
                City = existingLocation.City,
                State = existingLocation.State,
                Country = existingLocation.Country,
                Zip = existingLocation.Zip,
            };

            return updatedLocation;
        }
    }
}