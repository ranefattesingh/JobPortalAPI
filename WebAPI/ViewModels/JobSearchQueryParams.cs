namespace WebAPI.ViewModels
{
    public class JobSearchQueryParams
    {
        public string Q { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int? LocationID { get; set; }
        public int? DepartmentID { get; set; }
    }
}
