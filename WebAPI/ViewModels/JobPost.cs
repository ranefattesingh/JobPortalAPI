using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class JobPost
    {
        public int ID { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        public int LocationID { get; set; }
        public int DepartmentID { get; set; }
        public DateTime ClosingDate { get; set; }
        public string? Code { get; set; }
    }
}
