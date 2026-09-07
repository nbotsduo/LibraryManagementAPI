using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Entities
{
    public class BookCopy
    {
        [Key]
        public int ID { get; set; }

        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(1)]
        [RegularExpression(@"^[ABD]$")]
        public string Status { get; set; } = string.Empty; //B - borowed, A-available, D-disposed

        public Book? Book { get; set; }
        public int BookID { get; set; }
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();

    }
}
