namespace LibraryManagementSystemAPI.Model
{
    public class ErrorResultModel
    {
        public int Code { get; set; }
        public string Description { get; set; }
    }

    public class BoolResultModel
    {
        public bool Bool { get; set; }
        public string Description { get; set; }
    }

    public class BookDetails
    {
        public string? Category { get; set; }
        public string? Publisher { get; set; }
        public string? Author { get; set; }
    }
}
