using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Entities
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string ISBN { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Genre { get; set; }

        public int? PublishedYear { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int TotalAmount { get; set; }
        public int AvailableAmount { get; set; }
        public int LoanDuration { get; set; } //e.g 2 days

        public string? Aisle { get; set; }

        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public int PublisherID { get; set; }

        public Publisher? Publisher { get; set; }

        public int AuthorID { get; set; }
        public Author? Author { get; set; }

        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
    }
}
