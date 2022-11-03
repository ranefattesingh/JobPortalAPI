using JobPortal.BAL.BusinessEntities;
using JobPortal.DAL;
using JobPortal.DAL.DataEntities;
using Persistance.EntityFramework.Models;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.BAL
{
    public interface IJobsService
    {
        public JobPostBE CreateJob(JobPostBE jobPostBE);
        public JobPostBE? UpdateJob(int id, JobPostBE jobPostBE);
        public JobPostBE? GetJobDetail(int id);
    }

    public class JobsService : IJobsService
    {
        public IJobsRepository _jobsRepository { get; set; }
        public JobsService(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        public JobPostBE CreateJob(JobPostBE jobPostBE)
        {
            var jobPostDE = new JobPostDE
            {
                Title = jobPostBE.Title,
                Description = jobPostBE.Description,
                LocationID = jobPostBE.LocationID,
                DepartmentID = jobPostBE.DepartmentID,
                ClosingDate = jobPostBE.ClosingDate,
            };

            var createdJobPostDE = _jobsRepository.CreateJob(jobPostDE);

            var createdJobPostBE = new JobPostBE
            {
                ID = createdJobPostDE.ID,
                Title = createdJobPostDE.Title,
                Description = createdJobPostDE.Description,
                LocationID = createdJobPostDE.LocationID,
                DepartmentID = createdJobPostDE.DepartmentID,
                ClosingDate = createdJobPostDE.ClosingDate,
            };

            return createdJobPostBE;
        }

        public JobPostBE? UpdateJob(int id, JobPostBE jobPostBE)
        {
            var jobPostDE = new JobPostDE
            {
                Title = jobPostBE.Title,
                Description = jobPostBE.Description,
                LocationID = jobPostBE.LocationID,
                DepartmentID = jobPostBE.DepartmentID,
                ClosingDate = jobPostBE.ClosingDate,
            };

            var updatedJobPostDE = _jobsRepository.UpdateJob(id, jobPostDE);
            if(updatedJobPostDE == null)
            {
                return null;
            }

            var updatedJobPostBE = new JobPostBE
            {
                ID = updatedJobPostDE.ID,
                Title = updatedJobPostDE.Title,
                Description = updatedJobPostDE.Description,
                LocationID = updatedJobPostDE.LocationID,
                DepartmentID = updatedJobPostDE.DepartmentID,
                ClosingDate = updatedJobPostDE.ClosingDate,
            };

            return updatedJobPostBE;
        }

        public JobPostBE? GetJobDetail(int id)
        {
            var jobDetailDE = _jobsRepository.GetJobDetail(id);
            if (jobDetailDE == null)
            {
                return null;
            }

            var jobDetailBE = new JobPostBE
            {
                ID = jobDetailDE.ID,
                Title = jobDetailDE.Title,
                Description = jobDetailDE.Description,
                LocationID = jobDetailDE.LocationID,
                DepartmentID = jobDetailDE.DepartmentID,
                ClosingDate = jobDetailDE.ClosingDate,
                Code = jobDetailDE.Code,
                PostedDate = jobDetailDE.PostedDate,
                Department = new Department
                {
                    ID = jobDetailDE.Department.ID,
                    Title = jobDetailDE.Department.Title,
                },
                Location = new Location
                {
                    ID = jobDetailDE.Location.ID,
                    Title = jobDetailDE.Location.Title,
                    City = jobDetailDE.Location.City,
                    State = jobDetailDE.Location.State,
                    Country = jobDetailDE.Location.Country,
                    Zip = jobDetailDE.Location.Zip,
                    JobPost = jobDetailDE.Location.JobPost,
                },
            };

            return jobDetailBE;
        }
    }
}
