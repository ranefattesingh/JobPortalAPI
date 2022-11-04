using Common.Exception;
using JobPortal.DAL.DataEntities;
using Persistance.EntityFramework;
using Persistance.EntityFramework.Models;

namespace JobPortal.DAL
{
    public interface IDepartmentRepository
    {
        public DepartmentDE CreateDepartment(DepartmentDE department);
        public DepartmentDE? UpdateDepartment(int id, DepartmentDE department);
        public IEnumerable<DepartmentDE> GetDepartments();
    }
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly JobPortalContext _context;
        public DepartmentRepository(JobPortalContext context)
        {
            _context = context;
        }
        public DepartmentDE CreateDepartment(DepartmentDE departmentDE)
        {
            var departmentModel = new Department
            {
                Title = departmentDE.Title,
            };

            _context.Add(departmentModel);
            _context.SaveChanges();

            var createdDepartment =  new DepartmentDE
            {
                ID = departmentModel.ID,
                Title = departmentModel.Title,
            };

            return createdDepartment;
        }

        public IEnumerable<DepartmentDE> GetDepartments()
        {
            var departmentDEList = _context.Departments.Select(d => new DepartmentDE
            {
                ID = d.ID,
                Title = d.Title,
            }).ToList();

            return departmentDEList;
        }

        public DepartmentDE? UpdateDepartment(int id, DepartmentDE department)
        {
           var existingDepartment = _context.Find<Department>(id);
            if(existingDepartment == null)
            {
                throw new NotFoundException("department", id);
            }

            existingDepartment.Title = department.Title;

            _context.Update(existingDepartment);
            _context.SaveChanges();

            var updatedDepartment = new DepartmentDE
            {
                ID = existingDepartment.ID,
                Title = existingDepartment.Title,
            };

            return updatedDepartment;
        }
    }
}