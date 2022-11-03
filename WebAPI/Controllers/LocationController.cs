using JobPortal.BAL.BusinessEntities;
using JobPortal.BAL;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost]
        public ActionResult CreateLocation(Location request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(new
                    {
                        Success = false,
                        Error = "all fields are mandatory",
                    });
                }

                var locationBE = new LocationBE()
                {
                    Title = request.Title,
                    City = request.City,
                    State = request.State,
                    Country = request.Country,
                    Zip = request.Zip,
                };

                var createdLocationBE = _locationService.CreateLocation(locationBE);

                return CreatedAtAction(nameof(CreateLocation), new
                {
                    Success = true,
                    Location = new Location()
                    {
                        ID = createdLocationBE.ID,
                        Title = createdLocationBE.Title,
                        City = createdLocationBE.City,
                        State = createdLocationBE.State,
                        Country = createdLocationBE.Country,
                        Zip = createdLocationBE.Zip,
                    },
                });
            }
            catch (Exception e)
            {
                // TODO: return Internal Server Error
                throw e;
            }
        }

        [HttpGet]
        public ActionResult GetDepartments()
        {

            try
            {
                var locationBEs = _locationService.GetLocations();

                return new OkObjectResult(new
                {
                    Success = true,
                    TotalCount = locationBEs.Count(),
                    Locations = locationBEs.Select(l => new Location()
                    {
                        ID = l.ID,
                        Title = l.Title,
                        City = l.City,
                        State = l.State,
                        Country = l.Country,
                        Zip = l.Zip,
                    }).ToList(),
                });
            }
            catch (Exception e)
            {
                // TODO: return internal server error
                throw e;
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDepartment(int id, Location request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(new
                    {
                        Success = false,
                        Error = "title is required",
                    });
                }

                var locationBE = new LocationBE()
                {
                    Title = request.Title,
                    City = request.City,
                    State = request.State,
                    Country = request.Country,
                    Zip = request.Zip,
                };

                var updatedLocationBE = _locationService.UpdateLocation(id, locationBE);
                if (updatedLocationBE == null)
                {
                    return new NotFoundObjectResult(new
                    {
                        Success = false,
                        Message = "location does not exist"
                    });
                }

                return new OkObjectResult(new
                {
                    Success = true,
                    Departments = new Location()
                    {
                        ID = updatedLocationBE.ID,
                        Title = updatedLocationBE.Title,
                        City = updatedLocationBE.City,
                        State = updatedLocationBE.State,
                        Country = updatedLocationBE.Country,
                        Zip = updatedLocationBE.Zip,
                    }
                });
            }
            catch (Exception e)
            {
                // TODO: return internal server error
                throw e;
            }
        }
    }
}
