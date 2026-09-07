namespace LibraryManagementSystemAPI.DTO
{
    public class BookDTO
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string? Genre { get; set; }
        public int? PublishedYear { get; set; }
        public string? Description { get; set; }
        public int TotalAmount { get; set; }
        public int AvailableAmount { get; set; }
        public int LoanDuration { get; set; } //e.g 2 days
        public string? Aisle { get; set; }
        public int CategoryID { get; set; }
        public string? Category { get; set; }
        public int PublisherID { get; set; }
        public string? Publisher { get; set; }
        public int AuthorID { get; set; }
        public string? Author { get; set; }
        public int BookCopyCount { get; set; }

        public List<BookCopiesDTO> bookCopies { get; set; } = new();
    }

    public class CreateBookDTO
    {
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string? Genre { get; set; }
        public int? PublishedYear { get; set; }
        public string? Description { get; set; }
        public int TotalAmount { get; set; }
        public int AvailableAmount { get; set; }
        public int LoanDuration { get; set; } //e.g 2 days
        public string? Aisle { get; set; }
        public int CategoryID { get; set; }
        public int PublisherID { get; set; }
        public int AuthorID { get; set; }
        
    }

    public class UpdateBookDTO
    {
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string? Genre { get; set; }
        public int? PublishedYear { get; set; }
        public string? Description { get; set; }
        public int TotalAmount { get; set; }
        public int AvailableAmount { get; set; }
        public int LoanDuration { get; set; } //e.g 2 days
        public string? Aisle { get; set; }
        public int CategoryID { get; set; }
        public int PublisherID { get; set; }
        public int AuthorID { get; set; }

    }
}
