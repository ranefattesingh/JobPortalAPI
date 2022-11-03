using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class Department
    {
        public int      ID      { get; set; }
        [Required]
        public string?  Title   { get; set; }
    }
}
