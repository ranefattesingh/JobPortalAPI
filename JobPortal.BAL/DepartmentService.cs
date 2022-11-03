using JobPortal.BAL.BusinessEntities;
using JobPortal.DAL;
using JobPortal.DAL.DataEntities;
using System.Collections.Generic;

namespace JobPortal.BAL
{
    public interface IDepartmentService
    {
        public DepartmentBE CreateDepartment(DepartmentBE departmentBE);
        public DepartmentBE? UpdateDepartment(int id,DepartmentBE departmentBE);
        public IEnumerable<DepartmentBE> GetDepartments();
    }
    public class DepartmentService : IDepartmentService
    {
        public IDepartmentRepository _departmentRepository { get; set; }
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public DepartmentBE CreateDepartment(DepartmentBE departmentBE)
        {
            var departmentDE = new DepartmentDE
            {
                Title = departmentBE.Title,
            };

            var createdDepartmentDE = _departmentRepository.CreateDepartment(departmentDE);

            var createdDepartmentBE = new DepartmentBE
            {
                ID = createdDepartmentDE.ID,
                Title = createdDepartmentDE.Title,
            };

            return createdDepartmentBE;
        }

        public IEnumerable<DepartmentBE> GetDepartments()
        {
            var departmentDEList = _departmentRepository.GetDepartments();
            var departmentBEList = departmentDEList.Select(d => new DepartmentBE
            {
                ID = d.ID,
                Title = d.Title,
            }).ToList();

            return departmentBEList;
        }

        public DepartmentBE? UpdateDepartment(int id, DepartmentBE departmentBE)
        {
            var departmentDE = new DepartmentDE
            {
                Title = departmentBE.Title,
            };

            var updatedDepartmentDE = _departmentRepository.UpdateDepartment(id, departmentDE);
            if(updatedDepartmentDE == null)
            {
                return null;
            }

            var updatedDepartmentBE = new DepartmentBE
            {
                ID = updatedDepartmentDE.ID,
                Title = updatedDepartmentDE.Title,
            };

            return updatedDepartmentBE;
        }
    }
}