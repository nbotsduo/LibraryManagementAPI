using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Entities
{
    public class Publisher
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Address { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
