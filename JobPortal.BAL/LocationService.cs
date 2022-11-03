using JobPortal.BAL.BusinessEntities;
using JobPortal.DAL;
using JobPortal.DAL.DataEntities;

namespace JobPortal.BAL
{
    public interface ILocationService
    {
        public LocationBE CreateLocation(LocationBE locationBE);
        public LocationBE? UpdateLocation(int id, LocationBE locationBE);
        public IEnumerable<LocationBE> GetLocations();
    }
    public class LocationService : ILocationService
    {
        public ILocationRepository _locationRepository { get; set; }
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public LocationBE CreateLocation(LocationBE locationBE)
        {
            var locationDE = new LocationDE()
            {
                Title = locationBE.Title,
                City = locationBE.City,
                State = locationBE.State,
                Country = locationBE.Country,
                Zip = locationBE.Zip,
            };

            var createdLocationDE = _locationRepository.CreateLocation(locationDE);

            var createdLocationBE = new LocationBE
            {
                ID = createdLocationDE.ID,
                Title = createdLocationDE.Title,
                City = createdLocationDE.City,
                State = createdLocationDE.State,
                Country = createdLocationDE.Country,
                Zip = createdLocationDE.Zip,
            };

            return createdLocationBE;
        }

        public IEnumerable<LocationBE> GetLocations()
        {
            var locationDEList = _locationRepository.GetLocations();
            var departmentBEList = locationDEList.Select(l => new LocationBE
            {
                ID = l.ID,
                Title = l.Title,
                City = l.City,
                State = l.State,
                Country = l.Country,
                Zip = l.Zip,
            }).ToList();

            return departmentBEList;
        }

        public LocationBE? UpdateLocation(int id, LocationBE locationBE)
        {
            var departmentDE = new LocationDE
            {
                Title = locationBE.Title,
                City = locationBE.City,
                State = locationBE.State,
                Country = locationBE.Country,
                Zip = locationBE.Zip,
            };

            var updatedLocationDE = _locationRepository.UpdateLocation(id, departmentDE);
            if(updatedLocationDE == null)
            {
                return null;
            }

            var updatedLocationBE = new LocationBE
            {
                ID = updatedLocationDE.ID,
                Title = updatedLocationDE.Title,
                City = updatedLocationDE.City,
                State = updatedLocationDE.State,
                Country = updatedLocationDE.Country,
                Zip = updatedLocationDE.Zip,
            };

            return updatedLocationBE;
        }
    }
}