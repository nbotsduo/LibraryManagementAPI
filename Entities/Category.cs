using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Entities
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Section { get; set; }

        public double FinePrice { get; set; } = 0.00; //Fine Price for each category

        public ICollection<Book> books { get; set; }  = new List<Book>();
    }
}
