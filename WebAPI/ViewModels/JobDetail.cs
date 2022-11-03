using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class JobDetail
    {
        public int ID { get; set; }
        public string? Code { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Location? Location { get; set; }
        public Department? Department { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
