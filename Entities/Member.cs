using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Entities
{
    public class Member
    {
        [Key] 
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } =string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [MaxLength(20)]
        public string Phone { get; set; }

        public DateTime MembershipDate { get; set; } = DateTime.UtcNow;

        public bool MembershipStatus { get; set; } = true;

        public ICollection<Loan> loans { get; set; } = new List<Loan>();
    }
}
