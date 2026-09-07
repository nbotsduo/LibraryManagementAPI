using LibraryManagementSystemAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.DTO
{
    public class BookCopiesDTO
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = string.Empty; //B - borowed, A-available, D-disposed
        public string Book { get; set; }
        public int BookID { get; set; }
        public List<LoanDTO> loans { get; set; } = new();
    }

    public class CreateBookCopiesDTO
    {
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = string.Empty; //B - borowed, A-available, D-disposed
        public int BookID { get; set; }
    }

    public class UpdateBookCopiesDTO
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = string.Empty; //B - borowed, A-available, D-disposed
        public int BookID { get; set; }
    }
}
