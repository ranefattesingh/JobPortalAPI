using JobPortal.BAL;
using JobPortal.BAL.BusinessEntities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public ActionResult CreateDepartment(Department request)
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

                var departmentBE = new DepartmentBE()
                {
                    Title = request.Title,
                };

                var createdDepartment = _departmentService.CreateDepartment(departmentBE);

                return CreatedAtAction(nameof(CreateDepartment), new
                {
                    Success = true,
                    Department = new Department()
                    {
                        ID = createdDepartment.ID,
                        Title = createdDepartment.Title,
                    },
                });
            }
            catch(Exception e)
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
                var departmentBEs = _departmentService.GetDepartments();

                return new OkObjectResult(new
                {
                    Success = true,
                    TotalCount = departmentBEs.Count(),
                    Departments = departmentBEs.Select(d => new Department()
                    {
                        ID = d.ID,
                        Title = d.Title,
                    }).ToList(),
                });
            }
            catch(Exception e)
            {
                // TODO: return internal server error
                throw e;
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDepartment(int id, Department request)
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

                var departmentBE = new DepartmentBE()
                {
                    Title = request.Title,
                };

                var updatedDepartmentBE = _departmentService.UpdateDepartment(id, departmentBE);
                if (updatedDepartmentBE == null)
                {
                    return new NotFoundObjectResult(new
                    {
                        Success = false,
                        Message = "department does not exist"
                    });
                }

                return new OkObjectResult(new
                {
                    Success = true,
                    Departments = new Department()
                    {
                        ID = updatedDepartmentBE.ID,
                        Title = updatedDepartmentBE.Title,
                    }
                });
            }
            catch(Exception e)
            {
                // TODO: return internal server error
                throw e;
            }
        }
    }
}
