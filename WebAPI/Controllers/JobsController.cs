using JobPortal.BAL.BusinessEntities;
using JobPortal.BAL;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;
        public JobsController(IJobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpPost]
        public ActionResult CreateJob(JobPost request)
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

                var jobPostBE = new JobPostBE
                {
                    Title = request.Title,
                    Description = request.Description,
                    LocationID = request.LocationID,
                    DepartmentID = request.DepartmentID,
                    ClosingDate = request.ClosingDate,
                };

                var createdJobsBE = _jobsService.CreateJob(jobPostBE);

                return CreatedAtAction(nameof(CreateJob), new
                {
                    Success = true,
                    Job = new JobPost()
                    {
                        ID = createdJobsBE.ID,
                        Title = createdJobsBE.Title,
                        Description = createdJobsBE.Description,
                        LocationID = createdJobsBE.LocationID,
                        DepartmentID = createdJobsBE.DepartmentID,
                        ClosingDate = createdJobsBE.ClosingDate,
                        Code = createdJobsBE.Code,
                    },
                });
            }
            catch (Exception e)
            {
                // TODO: return Internal Server Error
                throw e;
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateJob(int id, JobPost request)
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

                var jobPostBE = new JobPostBE
                {
                    Title = request.Title,
                    Description = request.Description,
                    LocationID = request.LocationID,
                    DepartmentID = request.DepartmentID,
                    ClosingDate = request.ClosingDate,
                };

                var updatedJobsBE = _jobsService.UpdateJob(id, jobPostBE);
                if (updatedJobsBE == null)
                {
                    return new NotFoundObjectResult(new
                    {
                        Success = false,
                        Message = "job post does not exist"
                    });
                }

                return new OkObjectResult(new
                {
                    Success = true,
                    Job = new JobPost()
                    {
                        ID = updatedJobsBE.ID,
                        Title = updatedJobsBE.Title,
                        Description = updatedJobsBE.Description,
                        LocationID = updatedJobsBE.LocationID,
                        DepartmentID = updatedJobsBE.DepartmentID,
                        ClosingDate = updatedJobsBE.ClosingDate,
                        Code = updatedJobsBE.Code,
                    },
                });
            }
            catch (Exception e)
            {
                // TODO: return Internal Server Error
                throw e;
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetJobDetail(int id)
        {
            try
            {
                var jobDetail = _jobsService.GetJobDetail(id);
                if (jobDetail == null)
                {
                    return new NotFoundObjectResult(new
                    {
                        Success = false,
                        Message = "job post does not exist"
                    });
                }

                return new OkObjectResult(new
                {
                    Success = true,
                    Job = new JobDetail()
                    {
                        ID = jobDetail.ID,
                        Title = jobDetail.Title,
                        Description = jobDetail.Description,
                        ClosingDate = jobDetail.ClosingDate,
                        Code = jobDetail.Code,
                        PostedDate = jobDetail.PostedDate,
                        Department = new Department
                        {
                            ID = jobDetail.Department.ID,
                            Title = jobDetail.Department.Title,
                        },
                        Location = new Location
                        {
                            ID = jobDetail.Location.ID,
                            Title = jobDetail.Location.Title,
                            City = jobDetail.Location.City,
                            State = jobDetail.Location.State,
                            Country = jobDetail.Location.Country,
                            Zip = jobDetail.Location.Zip,
                        },
                    },
                });
            }
            catch (Exception e)
            {
                // TODO: return Internal Server Error
                throw e;
            }
        }

    }
}
