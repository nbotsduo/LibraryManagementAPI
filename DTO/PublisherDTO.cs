namespace LibraryManagementSystemAPI.DTO
{
    public class PublisherDTO
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }
        public List<BookDTO> Books { get; set; } = new();
    }

    public class CreatePublisherDTO
    {
        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }
    }

    public class UpdatePublisherDTO
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }
    }
}
