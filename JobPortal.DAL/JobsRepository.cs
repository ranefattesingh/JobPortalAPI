using JobPortal.DAL.DataEntities;
using Persistance.EntityFramework;
using Persistance.EntityFramework.Models;

namespace JobPortal.DAL
{
    public interface IJobsRepository
    {
        public JobPostDE CreateJob(JobPostDE jobPostDE);
        public JobPostDE? UpdateJob(int id, JobPostDE jobPostDE);
        public JobPostDE? GetJobDetail(int id);
    }

    public class JobsRepository : IJobsRepository
    {
        private readonly JobPortalContext _context;
        public JobsRepository(JobPortalContext context)
        {
            _context = context;
        }

        public JobPostDE CreateJob(JobPostDE jobPostDE)
        {
            var jobPostModel = new JobPost
            {
                Title = jobPostDE.Title,
                Description = jobPostDE.Description,
                LocationID = jobPostDE.LocationID,
                DepartmentID = jobPostDE.DepartmentID,
                ClosingDate = jobPostDE.ClosingDate,
                Code = string.Format("JOB-0{0}", _context.JobPosts.Count()+1),
                PostedDate = DateTime.Now,
            };

            _context.Add(jobPostModel);

            _context.SaveChanges();

            var createdJobPostDE = new JobPostDE
            {
                Title = jobPostModel.Title,
                Description = jobPostModel.Description,
                LocationID = jobPostModel.LocationID,
                DepartmentID = jobPostModel.DepartmentID,
                ClosingDate = jobPostModel.ClosingDate,
                Code = jobPostModel.Code,
                PostedDate = jobPostModel.PostedDate,
            };

            return createdJobPostDE;
        }

        public JobPostDE? UpdateJob(int id, JobPostDE jobPostDE)
        {
            var existingJobPost = _context.JobPosts.Find(id);
            if(existingJobPost == null)
            {
                return null;
            }

            existingJobPost.Title = jobPostDE.Title;
            existingJobPost.Description = jobPostDE.Description;
            existingJobPost.LocationID = jobPostDE.LocationID;
            existingJobPost.DepartmentID = jobPostDE.DepartmentID;
            existingJobPost.ClosingDate = jobPostDE.ClosingDate;

            _context.Update(existingJobPost);

            _context.SaveChanges();

            var updatedJobPostDE = new JobPostDE
            {
                Title = existingJobPost.Title,
                Description = existingJobPost.Description,
                LocationID = existingJobPost.LocationID,
                DepartmentID = existingJobPost.DepartmentID,
                ClosingDate = existingJobPost.ClosingDate,
                Code = existingJobPost.Code,
                PostedDate = existingJobPost.PostedDate,
            };

            return updatedJobPostDE;
        }

        public JobPostDE? GetJobDetail(int id)
        {
            var job = _context.JobPosts.Find(id);
            if (job == null)
            {
                return null;
            }

            var jobDetailDE = new JobPostDE
            {
                ID = job.ID,
                Title = job.Title,
                Description = job.Description,
                LocationID = job.LocationID,
                DepartmentID = job.DepartmentID,
                ClosingDate = job.ClosingDate,
                Code = job.Code,
                PostedDate = job.PostedDate,
                Department = new Department
                {
                    ID = job.Department.ID,
                    Title = job.Department.Title,
                },
                Location = new Location
                {
                    ID = job.Location.ID,
                    Title = job.Location.Title,
                    City = job.Location.City,
                    State = job.Location.State,
                    Country = job.Location.Country,
                    Zip = job.Location.Zip,
                    JobPost = job.Location.JobPost,
                },
            };

            return jobDetailDE;
        }
    }
}
