namespace LibraryManagementSystemAPI.DTO
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Section { get; set; } = string.Empty;
        public double FinePrice { get; set; }
        public List<BookDTO> Books { get; set; } = new();
    }

    public class CreateCategoryDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Section { get; set; } = string.Empty;
        public double FinePrice { get; set; }
    }

    public class UpdateCategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Section { get; set; } = string.Empty;
        public double FinePrice { get; set; }
    }
}
