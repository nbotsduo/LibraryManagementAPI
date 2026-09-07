using LibraryManagementSystemAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Data
{
    public static class DbInitializer
    {
        public static void Seed(LibraryDbContext context)
        {
            // Guard: only seed an empty database
            if (context.Book.Any())
            {
                return;
            }

            // ---------------------------------------------------------------
            // 1. Publishers
            // ---------------------------------------------------------------
            var penguin = new Publisher { Name = "Penguin Random House", Address = "1745 Broadway, New York, NY" };
            var harper = new Publisher { Name = "HarperCollins", Address = "195 Broadway, New York, NY" };
            var simonSchuster = new Publisher { Name = "Simon & Schuster", Address = "1230 Avenue of the Americas, New York, NY" };

            context.Publishers.AddRange(penguin, harper, simonSchuster);
            context.SaveChanges();

            // ---------------------------------------------------------------
            // 2. Categories
            // ---------------------------------------------------------------
            var fiction = new Category { Name = "Fiction", Section = "A1", FinePrice = 0.50 };
            var scienceFiction = new Category { Name = "Science Fiction", Section = "A2", FinePrice = 0.50 };
            var nonFiction = new Category { Name = "Non-Fiction", Section = "B1", FinePrice = 0.75 };
            var fantasy = new Category { Name = "Fantasy", Section = "A3", FinePrice = 0.50 };
            var biography = new Category { Name = "Biography", Section = "B2", FinePrice = 0.75 };
            var mystery = new Category { Name = "Mystery", Section = "A4", FinePrice = 0.60 };

            context.Categories.AddRange(fiction, scienceFiction, nonFiction, fantasy, biography, mystery);
            context.SaveChanges();

            // ---------------------------------------------------------------
            // 3. Authors
            // ---------------------------------------------------------------
            var orwell = new Author { Name = "George Orwell" };
            var rowling = new Author { Name = "J.K. Rowling" };
            var harari = new Author { Name = "Yuval Noah Harari" };
            var christie = new Author { Name = "Agatha Christie" };
            var king = new Author { Name = "Stephen King" };
            var obama = new Author { Name = "Michelle Obama" };

            context.Author.AddRange(orwell, rowling, harari, christie, king, obama);
            context.SaveChanges();

            // ---------------------------------------------------------------
            // 4. Books
            // ---------------------------------------------------------------
            var book1 = new Book
            {
                Title = "1984",
                ISBN = "978-0-452-28423-4",
                Genre = "Dystopian",
                PublishedYear = 1949,
                Description = "A dystopian social science fiction novel and cautionary tale.",
                TotalAmount = 3,
                AvailableAmount = 3,
                LoanDuration = 14,
                Aisle = "A1-01",
                Category = fiction,
                Publisher = penguin,
                Author = orwell
            };

            var book2 = new Book
            {
                Title = "Animal Farm",
                ISBN = "978-0-452-28424-1",
                Genre = "Satire",
                PublishedYear = 1945,
                Description = "An allegorical novella about a group of farm animals who rebel.",
                TotalAmount = 2,
                AvailableAmount = 2,
                LoanDuration = 14,
                Aisle = "A1-02",
                Category = fiction,
                Publisher = penguin,
                Author = orwell
            };

            var book3 = new Book
            {
                Title = "Harry Potter and the Philosopher's Stone",
                ISBN = "978-0-7475-3269-9",
                Genre = "Fantasy",
                PublishedYear = 1997,
                Description = "A young wizard discovers his magical heritage on his 11th birthday.",
                TotalAmount = 4,
                AvailableAmount = 4,
                LoanDuration = 21,
                Aisle = "A3-01",
                Category = fantasy,
                Publisher = harper,
                Author = rowling
            };

            var book4 = new Book
            {
                Title = "Sapiens: A Brief History of Humankind",
                ISBN = "978-0-06-231609-7",
                Genre = "History",
                PublishedYear = 2011,
                Description = "An exploration of how Homo sapiens came to dominate the world.",
                TotalAmount = 2,
                AvailableAmount = 2,
                LoanDuration = 21,
                Aisle = "B1-01",
                Category = nonFiction,
                Publisher = harper,
                Author = harari
            };

            var book5 = new Book
            {
                Title = "Murder on the Orient Express",
                ISBN = "978-0-06-269336-0",
                Genre = "Mystery",
                PublishedYear = 1934,
                Description = "Detective Hercule Poirot investigates a murder aboard a snowbound train.",
                TotalAmount = 3,
                AvailableAmount = 3,
                LoanDuration = 14,
                Aisle = "A4-01",
                Category = mystery,
                Publisher = harper,
                Author = christie
            };

            var book6 = new Book
            {
                Title = "The Shining",
                ISBN = "978-0-307-74365-9",
                Genre = "Horror",
                PublishedYear = 1977,
                Description = "A family heads to an isolated hotel for the winter where an evil spiritual presence influences the father.",
                TotalAmount = 2,
                AvailableAmount = 2,
                LoanDuration = 14,
                Aisle = "A1-03",
                Category = fiction,
                Publisher = simonSchuster,
                Author = king
            };

            var book7 = new Book
            {
                Title = "Becoming",
                ISBN = "978-1-5247-6313-8",
                Genre = "Memoir",
                PublishedYear = 2018,
                Description = "The memoir of former First Lady Michelle Obama.",
                TotalAmount = 2,
                AvailableAmount = 2,
                LoanDuration = 21,
                Aisle = "B2-01",
                Category = biography,
                Publisher = penguin,
                Author = obama
            };

            var book8 = new Book
            {
                Title = "Harry Potter and the Chamber of Secrets",
                ISBN = "978-0-7475-3849-3",
                Genre = "Fantasy",
                PublishedYear = 1998,
                Description = "Harry's second year at Hogwarts brings a mysterious monster and a diary that talks back.",
                TotalAmount = 3,
                AvailableAmount = 3,
                LoanDuration = 21,
                Aisle = "A3-02",
                Category = fantasy,
                Publisher = harper,
                Author = rowling
            };

            context.Book.AddRange(book1, book2, book3, book4, book5, book6, book7, book8);
            context.SaveChanges();

            // ---------------------------------------------------------------
            // 5. Members
            // ---------------------------------------------------------------
            var member1 = new Member { FirstName = "Alice", LastName = "Tan", Email = "alice.tan@example.com", Phone = "+60123456701", MembershipDate = DateTime.UtcNow.AddMonths(-10), MembershipStatus = true };
            var member2 = new Member { FirstName = "Benjamin", LastName = "Lee", Email = "ben.lee@example.com", Phone = "+60123456702", MembershipDate = DateTime.UtcNow.AddMonths(-8), MembershipStatus = true };
            var member3 = new Member { FirstName = "Chloe", LastName = "Wong", Email = "chloe.wong@example.com", Phone = "+60123456703", MembershipDate = DateTime.UtcNow.AddMonths(-6), MembershipStatus = true };
            var member4 = new Member { FirstName = "Daniel", LastName = "Kumar", Email = "daniel.kumar@example.com", Phone = "+60123456704", MembershipDate = DateTime.UtcNow.AddMonths(-4), MembershipStatus = true };
            var member5 = new Member { FirstName = "Emma", LastName = "Chong", Email = "emma.chong@example.com", Phone = "+60123456705", MembershipDate = DateTime.UtcNow.AddMonths(-2), MembershipStatus = false };

            context.Members.AddRange(member1, member2, member3, member4, member5);
            context.SaveChanges();

            // ---------------------------------------------------------------
            // 6. Staff
            // ---------------------------------------------------------------
            var staff1 = new Staff { FirstName = "Grace", LastName = "Lim", Email = "grace.lim@library.org", Phone = "+60123456801", Roles = "Librarian" };
            var staff2 = new Staff { FirstName = "Marcus", LastName = "Ong", Email = "marcus.ong@library.org", Phone = "+60123456802", Roles = "Assistant Librarian" };
            var staff3 = new Staff { FirstName = "Priya", LastName = "Nair", Email = "priya.nair@library.org", Phone = "+60123456803", Roles = "Circulation Desk" };

            context.Staffs.AddRange(staff1, staff2, staff3);
            context.SaveChanges();

            // ---------------------------------------------------------------
            // 7. Book Copies
            // Created before Loans now, since Loan requires a BookCopy (not
            // the other way around). Status: A = available, B = borrowed, D = disposed.
            // ---------------------------------------------------------------
            var now = DateTime.UtcNow;

            // 1984 - 3 copies
            var copy1984_1 = new BookCopy { Book = book1, Price = 15.99, PurchaseDate = now.AddYears(-2), Status = "A" };
            var copy1984_2 = new BookCopy { Book = book1, Price = 15.99, PurchaseDate = now.AddYears(-2), Status = "A" };
            var copy1984_3 = new BookCopy { Book = book1, Price = 15.99, PurchaseDate = now.AddYears(-1), Status = "B" };

            // Animal Farm - 2 copies
            var copyFarm_1 = new BookCopy { Book = book2, Price = 12.50, PurchaseDate = now.AddYears(-3), Status = "A" };
            var copyFarm_2 = new BookCopy { Book = book2, Price = 12.50, PurchaseDate = now.AddYears(-1), Status = "A" };

            // Harry Potter and the Philosopher's Stone - 4 copies
            var copyHp1_1 = new BookCopy { Book = book3, Price = 18.75, PurchaseDate = now.AddYears(-4), Status = "A" };
            var copyHp1_2 = new BookCopy { Book = book3, Price = 18.75, PurchaseDate = now.AddYears(-2), Status = "A" };
            var copyHp1_3 = new BookCopy { Book = book3, Price = 18.75, PurchaseDate = now.AddYears(-1), Status = "A" };
            var copyHp1_4 = new BookCopy { Book = book3, Price = 19.99, PurchaseDate = now.AddMonths(-6), Status = "B" };

            // Sapiens - 2 copies
            var copySapiens_1 = new BookCopy { Book = book4, Price = 22.00, PurchaseDate = now.AddYears(-2), Status = "A" };
            var copySapiens_2 = new BookCopy { Book = book4, Price = 22.00, PurchaseDate = now.AddYears(-1), Status = "A" };

            // Murder on the Orient Express - 3 copies
            var copyOrient_1 = new BookCopy { Book = book5, Price = 14.25, PurchaseDate = now.AddYears(-3), Status = "A" };
            var copyOrient_2 = new BookCopy { Book = book5, Price = 14.25, PurchaseDate = now.AddYears(-2), Status = "A" };
            var copyOrient_3 = new BookCopy { Book = book5, Price = 14.25, PurchaseDate = now.AddMonths(-8), Status = "B" };

            // The Shining - 2 copies
            var copyShining_1 = new BookCopy { Book = book6, Price = 16.50, PurchaseDate = now.AddYears(-5), Status = "A" };
            var copyShining_2 = new BookCopy { Book = book6, Price = 16.50, PurchaseDate = now.AddYears(-6), Status = "D" };

            // Becoming - 2 copies
            var copyBecoming_1 = new BookCopy { Book = book7, Price = 20.00, PurchaseDate = now.AddYears(-1), Status = "A" };
            var copyBecoming_2 = new BookCopy { Book = book7, Price = 20.00, PurchaseDate = now.AddMonths(-9), Status = "A" };

            // Harry Potter and the Chamber of Secrets - 3 copies
            var copyHp2_1 = new BookCopy { Book = book8, Price = 18.75, PurchaseDate = now.AddYears(-3), Status = "A" };
            var copyHp2_2 = new BookCopy { Book = book8, Price = 18.75, PurchaseDate = now.AddYears(-2), Status = "A" };
            var copyHp2_3 = new BookCopy { Book = book8, Price = 19.99, PurchaseDate = now.AddMonths(-4), Status = "B" };

            context.BookCopies.AddRange(
                copy1984_1, copy1984_2, copy1984_3,
                copyFarm_1, copyFarm_2,
                copyHp1_1, copyHp1_2, copyHp1_3, copyHp1_4,
                copySapiens_1, copySapiens_2,
                copyOrient_1, copyOrient_2, copyOrient_3,
                copyShining_1, copyShining_2,
                copyBecoming_1, copyBecoming_2,
                copyHp2_1, copyHp2_2, copyHp2_3);
            context.SaveChanges();

            // ---------------------------------------------------------------
            // 8. Loans
            // Each loan now points at a specific BookCopy. Available/disposed
            // copies carry their past (returned) loan history; borrowed copies
            // carry an active loan with ReturnDate left null.
            // ---------------------------------------------------------------
            var loans = new[]
            {
                // --- Returned loan history for currently-available copies ---
                new Loan { BookCopy = copy1984_1, Member = member1, Staff = staff1, LoanDate = now.AddDays(-30), DueDate = now.AddDays(-16), ReturnDate = now.AddDays(-18), Status = "R", FineAmount = 0, Notes = "Returned on time" },
                new Loan { BookCopy = copy1984_2, Member = member1, Staff = staff2, LoanDate = now.AddDays(-40), DueDate = now.AddDays(-26), ReturnDate = now.AddDays(-27), Status = "R", FineAmount = 0, Notes = "Returned on time" },

                new Loan { BookCopy = copyFarm_1, Member = member2, Staff = staff2, LoanDate = now.AddDays(-28), DueDate = now.AddDays(-14), ReturnDate = now.AddDays(-15), Status = "R", FineAmount = 0, Notes = "Returned on time" },
                new Loan { BookCopy = copyFarm_2, Member = member4, Staff = staff1, LoanDate = now.AddDays(-45), DueDate = now.AddDays(-24), ReturnDate = now.AddDays(-25), Status = "R", FineAmount = 0, Notes = "Returned on time" },

                new Loan { BookCopy = copyHp1_1, Member = member3, Staff = staff1, LoanDate = now.AddDays(-25), DueDate = now.AddDays(-11), ReturnDate = now.AddDays(-9), Status = "L", FineAmount = 1.00, Notes = "Returned 2 days late" },
                new Loan { BookCopy = copyHp1_2, Member = member5, Staff = staff1, LoanDate = now.AddDays(-35), DueDate = now.AddDays(-21), ReturnDate = now.AddDays(-22), Status = "R", FineAmount = 0, Notes = "Returned on time" },
                new Loan { BookCopy = copyHp1_3, Member = member5, Staff = staff3, LoanDate = now.AddDays(-50), DueDate = now.AddDays(-29), ReturnDate = now.AddDays(-28), Status = "L", FineAmount = 0.50, Notes = "Returned 1 day late" },

                new Loan { BookCopy = copySapiens_1, Member = member4, Staff = staff3, LoanDate = now.AddDays(-20), DueDate = now.AddDays(-6), ReturnDate = now.AddDays(-7), Status = "R", FineAmount = 0, Notes = "Returned on time" },
                new Loan { BookCopy = copySapiens_2, Member = member2, Staff = staff3, LoanDate = now.AddDays(-15), DueDate = now.AddDays(-1), ReturnDate = now.AddDays(-2), Status = "R", FineAmount = 0, Notes = "Returned on time" },

                new Loan { BookCopy = copyOrient_1, Member = member3, Staff = staff2, LoanDate = now.AddDays(-12), DueDate = now.AddDays(9), ReturnDate = now.AddDays(-3), Status = "R", FineAmount = 0, Notes = "Returned early" },
                new Loan { BookCopy = copyOrient_2, Member = member1, Staff = staff1, LoanDate = now.AddDays(-30), DueDate = now.AddDays(-16), ReturnDate = now.AddDays(-17), Status = "R", FineAmount = 0, Notes = "Returned on time" },

                new Loan { BookCopy = copyShining_1, Member = member2, Staff = staff2, LoanDate = now.AddDays(-28), DueDate = now.AddDays(-14), ReturnDate = now.AddDays(-15), Status = "R", FineAmount = 0, Notes = "Returned on time" },
                new Loan { BookCopy = copyShining_2, Member = member1, Staff = staff2, LoanDate = now.AddDays(-100), DueDate = now.AddDays(-86), ReturnDate = now.AddDays(-88), Status = "R", FineAmount = 0, Notes = "Returned on time - copy later disposed due to damage" },

                new Loan { BookCopy = copyBecoming_1, Member = member5, Staff = staff1, LoanDate = now.AddDays(-35), DueDate = now.AddDays(-21), ReturnDate = now.AddDays(-22), Status = "R", FineAmount = 0, Notes = "Returned on time" },
                new Loan { BookCopy = copyBecoming_2, Member = member4, Staff = staff1, LoanDate = now.AddDays(-45), DueDate = now.AddDays(-24), ReturnDate = now.AddDays(-25), Status = "R", FineAmount = 0, Notes = "Returned on time" },

                new Loan { BookCopy = copyHp2_1, Member = member3, Staff = staff1, LoanDate = now.AddDays(-25), DueDate = now.AddDays(-11), ReturnDate = now.AddDays(-9), Status = "L", FineAmount = 1.00, Notes = "Returned 2 days late" },
                new Loan { BookCopy = copyHp2_2, Member = member5, Staff = staff3, LoanDate = now.AddDays(-50), DueDate = now.AddDays(-29), ReturnDate = now.AddDays(-28), Status = "L", FineAmount = 0.50, Notes = "Returned 1 day late" },
 
                // --- Active loans for currently-borrowed copies (ReturnDate is null) ---
                new Loan { BookCopy = copy1984_3, Member = member2, Staff = staff1, LoanDate = now.AddDays(-5), DueDate = now.AddDays(9), ReturnDate = null, Status = "B", FineAmount = 0, Notes = "Currently borrowed" },
                new Loan { BookCopy = copyHp1_4, Member = member3, Staff = staff2, LoanDate = now.AddDays(-3), DueDate = now.AddDays(11), ReturnDate = null, Status = "B", FineAmount = 0, Notes = "Currently borrowed" },
                new Loan { BookCopy = copyOrient_3, Member = member4, Staff = staff3, LoanDate = now.AddDays(-20), DueDate = now.AddDays(-6), ReturnDate = null, Status = "L", FineAmount = 3.00, Notes = "Overdue - fine accruing" },
                new Loan { BookCopy = copyHp2_3, Member = member1, Staff = staff1, LoanDate = now.AddDays(-1), DueDate = now.AddDays(13), ReturnDate = null, Status = "B", FineAmount = 0, Notes = "Currently borrowed" },
            };

            context.Loans.AddRange(loans);
            context.SaveChanges();

            // ---------------------------------------------------------------
            // 9. Keep Book.AvailableAmount / TotalAmount in sync with copies
            // ---------------------------------------------------------------
            foreach (var book in context.Book.Include(b => b.BookCopies))
            {
                book.AvailableAmount = book.BookCopies.Count(c => c.Status == "A");
                book.TotalAmount = book.BookCopies.Count(c => c.Status != "D");
            }
            context.SaveChanges();
        }
    }
}
