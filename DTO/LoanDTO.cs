using LibraryManagementSystemAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.DTO
{
    public class LoanDTO
    {
        public int ID { get; set; }

        public DateTime LoanDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = string.Empty; // B- borrowed, R - return, L - late 
        public double FineAmount { get; set; }
        public string? Notes { get; set; }

        public string? MemberName { get; set; }
        public int MemberID { get; set; }
        public string Staff { get; set; }
        public int StaffID { get; set; }
        public string? BookTitle { get; set; }
        public int BookCopyID { get; set; }
    }

    public class CreateLoanDTO
    {
        //public DateTime LoanDate { get; set; } = DateTime.UtcNow;
        //public DateTime DueDate { get; set; }
        //public DateTime? ReturnDate { get; set; }
        //public string Status { get; set; } = string.Empty; // B- borrowed, R - return, L - late 
        //public double FineAmount { get; set; }
        public string? Notes { get; set; }

        public int MemberID { get; set; }
        public int StaffID { get; set; }
        public int BookCopyID { get; set; }
    }

    public class UpdateLoanDTO
    {
        public int ID { get; set; }

        //public DateTime LoanDate { get; set; } = DateTime.UtcNow;
        //public DateTime DueDate { get; set; }
        //public DateTime? ReturnDate { get; set; }
        //public string Status { get; set; } = string.Empty; // B- borrowed, R - return, L - late 
        //public double FineAmount { get; set; }
        public string? Notes { get; set; }

        //public int MemberID { get; set; }
        //public int StaffID { get; set; }
        //public int BookCopyID { get; set; }
    }
}
