namespace LibraryManagementSystemAPI.DTO
{
    public class MemberDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; }
        public DateTime MembershipDate { get; set; } = DateTime.UtcNow;
        public bool MembershipStatus { get; set; } = true;

        public List<LoanDTO> loans { get; set; } = new();
    }

    public class CreateMemberDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; }
        //public bool MembershipStatus { get; set; } = true;
    }

    public class UpdateMemberDTO {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; }
        public DateTime MembershipDate { get; set; }
        public bool MembershipStatus { get; set; } = true;
    }

}
