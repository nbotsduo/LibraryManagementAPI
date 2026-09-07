using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.DTO
{
    public class AuthorDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BookDTO> Books { get; set; } = new();
    }

    public class CreateAuthorDTO
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateAuthorDTO
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
    }
}
