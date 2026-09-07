using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Entities
{
    public class Author
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
