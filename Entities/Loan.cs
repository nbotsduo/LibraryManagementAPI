using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Entities
{
    public class Loan
    {
        [Key]
        public int ID { get; set; }

        public DateTime LoanDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate {  get; set; } 
        public DateTime? ReturnDate { get; set; }

        [Required]
        [StringLength(1)]
        [RegularExpression(@"^[BRL]")]
        public string Status { get; set; } = string.Empty; // B- borrowed, R - return, L - late 

        public double FineAmount { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public int MemberID { get; set; }
        public Member Member { get; set; }
        public int StaffID { get; set; }
        public Staff Staff { get; set; }
        public int BookCopyID { get; set; }
        public BookCopy BookCopy { get; set; } = null!;
    }
}
