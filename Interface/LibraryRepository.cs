using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Entities;
using LibraryManagementSystemAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagementSystemAPI.Interface
{
    public class LibraryRepository (LibraryDbContext _context) : ILibraryRepository
    {
        //private readonly LibraryDbContext _context;

        #region Author
        public async Task<UpdateAuthorDTO> CreateAuthorAsync(CreateAuthorDTO author)
        {
            try
            {
                var create = new Author()
                {
                    Name = author.Name,
                };
                _context.Author.Add(create);
                await _context.SaveChangesAsync();

                return new UpdateAuthorDTO() { ID=create.ID,Name=create.Name};
            }
            catch (Exception ex) { }
            return null;
            
        }

        public async Task<bool> DeleteAuthorAsync(int ID)
        {
            try
            {
                var author =await _context.Author.Where(o => o.ID == ID).FirstOrDefaultAsync();
                if (author != null) { 
                    _context.Author.Remove(author);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) {
            }
            return false;
        }

        public async Task<List<AuthorDTO>> GetAllAuthorsAsync()
        {
            return await _context.Author
            .Select(a => new AuthorDTO
            {
                ID = a.ID,
                Name = a.Name,
                Books = a.Books.Select(b => new BookDTO
                {
                    ID = b.ID,
                    Title = b.Title,
                    Category = b.Category!.Name,
                    ISBN = b.ISBN,
                    Genre = b.Genre,
                    PublishedYear = b.PublishedYear,
                    Description = b.Description,
                    LoanDuration = b.LoanDuration,
                    Aisle=b.Aisle,
                    Publisher = b.Publisher!.Name,
                    TotalAmount = b.TotalAmount,
                    AvailableAmount = b.AvailableAmount,
                    BookCopyCount = b.BookCopies.Count,
                    CategoryID=b.CategoryID,
                    PublisherID=b.PublisherID,
                    AuthorID=b.AuthorID,
                    Author=a.Name
                    
                }).ToList()
            })
            .ToListAsync();
        }

        public async Task<AuthorDTO?> GetAuthorsAsync(int ID)
        {
            return await _context.Author.Where(x =>x.ID == ID)
                 .Select(a => new AuthorDTO
                 {
                     ID = a.ID,
                     Name = a.Name,
                     Books = a.Books.Select(b => new BookDTO
                     {
                         ID = b.ID,
                         Title = b.Title,
                         Category = b.Category!.Name,
                         ISBN = b.ISBN,
                         Genre = b.Genre,
                         PublishedYear = b.PublishedYear,
                         Description = b.Description,
                         LoanDuration = b.LoanDuration,
                         Aisle = b.Aisle,
                         Publisher = b.Publisher!.Name,
                         TotalAmount = b.TotalAmount,
                         AvailableAmount = b.AvailableAmount,
                         BookCopyCount = b.BookCopies.Count,
                         CategoryID = b.CategoryID,
                         PublisherID = b.PublisherID,
                         AuthorID = b.AuthorID,
                         Author = a.Name

                     }).ToList()
                 })
                .FirstOrDefaultAsync();
        }
        public async Task<UpdateAuthorDTO?> UpdateAuthorAsync(int id,UpdateAuthorDTO update)
        {
            var author =await _context.Author.Where(x =>x.ID == id).FirstOrDefaultAsync();
            if (author != null)
            {
                author.Name = update.Name;
                await _context.SaveChangesAsync();
                return new UpdateAuthorDTO()
                {
                    ID=author.ID,
                    Name=author.Name,
                };
            }
            return null;
        }
        #endregion
        #region Category

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Select(a => new CategoryDTO
                {
                    ID = a.ID,
                    Name = a.Name,
                    Section = a.Section,
                    FinePrice = a.FinePrice,
                    Books = a.books.Select(b => new BookDTO
                    {
                        ID = b.ID,
                        Title = b.Title,
                        Category = b.Category!.Name,
                        ISBN = b.ISBN,
                        Genre = b.Genre,
                        PublishedYear = b.PublishedYear,
                        Description = b.Description,
                        LoanDuration = b.LoanDuration,
                        Aisle = b.Aisle,
                        Publisher = b.Publisher!.Name,
                        TotalAmount = b.TotalAmount,
                        AvailableAmount = b.AvailableAmount,
                        BookCopyCount = b.BookCopies.Count,
                        CategoryID = b.CategoryID,
                        PublisherID = b.PublisherID,
                        AuthorID = b.AuthorID,
                        Author = b.Author!.Name

                    }).ToList()
                })
                .ToListAsync();
        }
        public async Task<CategoryDTO?> GetCategoriesAsync(int id)
        {
            try
            {
                var result = await _context.Categories.Where(x =>x.ID == id)
                    .Select(a => new CategoryDTO
                    {
                        ID = a.ID,
                        Name = a.Name,
                        Section = a.Section,
                        FinePrice = a.FinePrice,
                        Books = a.books.Select(b => new BookDTO
                        {
                            ID = b.ID,
                            Title = b.Title,
                            Category = b.Category!.Name,
                            ISBN = b.ISBN,
                            Genre = b.Genre,
                            PublishedYear = b.PublishedYear,
                            Description = b.Description,
                            LoanDuration = b.LoanDuration,
                            Aisle = b.Aisle,
                            Publisher = b.Publisher!.Name,
                            TotalAmount = b.TotalAmount,
                            AvailableAmount = b.AvailableAmount,
                            BookCopyCount = b.BookCopies.Count,
                            CategoryID = b.CategoryID,
                            PublisherID = b.PublisherID,
                            AuthorID = b.AuthorID,
                            Author = b.Author!.Name

                        }).ToList()
                    })
                    .FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex) { }
            return null;
        }
        public async Task<UpdateCategoryDTO> CreateCategoryAsync(CreateCategoryDTO category)
        {
            try
            {
                var create = new Category()
                {
                    Name = category.Name,
                    Section = category.Section,
                    FinePrice = category.FinePrice,
                };
                _context.Categories.Add(create);
                await _context.SaveChangesAsync();

                return new UpdateCategoryDTO() { ID = create.ID , Name=create.Name,FinePrice=create.FinePrice,Section=create.Section};

            }catch(Exception ex)
            {

            }
            return null;
        }
        public async Task<UpdateCategoryDTO> UpdateCategoryAsync(int id, UpdateCategoryDTO category)
        {
            try
            {
                var obj = await _context.Categories.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (obj != null) { 

                    obj.Name = category.Name;
                    obj.Section = category.Section;
                    obj.FinePrice = category.FinePrice;

                    await _context.SaveChangesAsync();
                    return new UpdateCategoryDTO() { ID=id, Name=obj.Name,FinePrice=obj.FinePrice, Section=obj.Section};
                }
             
            } catch (Exception ex) { }
            return null;
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var obj =await _context.Categories.Where(x =>x.ID == id).FirstOrDefaultAsync();
                if (obj != null) { 
                    _context.Categories.Remove(obj);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }catch (Exception ex) { }
            return false;
        }
        #endregion

        #region Publisher
        public async Task<List<PublisherDTO>> GetAllPublisherAsync()
        {
            return await _context.Publishers
                .Select(a => new PublisherDTO
                {
                    ID = a.ID,
                    Name = a.Name,
                    Address = a.Address,
                    Books = a.Books.Select(b => new BookDTO
                    {
                        ID = b.ID,
                        Title = b.Title,
                        Category = b.Category!.Name,
                        ISBN = b.ISBN,
                        Genre = b.Genre,
                        PublishedYear = b.PublishedYear,
                        Description = b.Description,
                        LoanDuration = b.LoanDuration,
                        Aisle = b.Aisle,
                        Publisher = b.Publisher!.Name,
                        TotalAmount = b.TotalAmount,
                        AvailableAmount = b.AvailableAmount,
                        BookCopyCount = b.BookCopies.Count,
                        CategoryID = b.CategoryID,
                        PublisherID = b.PublisherID,
                        AuthorID = b.AuthorID,
                        Author = b.Author!.Name

                    }).ToList()
                })
                .ToListAsync();
        }
        public async Task<PublisherDTO?> GetPublisherAsync(int id)
        {
            return await _context.Publishers.Where( x => x.ID == id)
                .Select(a => new PublisherDTO
                {
                    ID = a.ID,
                    Name = a.Name,
                    Address = a.Address,
                    Books = a.Books.Select(b => new BookDTO
                    {
                        ID = b.ID,
                        Title = b.Title,
                        Category = b.Category!.Name,
                        ISBN = b.ISBN,
                        Genre = b.Genre,
                        PublishedYear = b.PublishedYear,
                        Description = b.Description,
                        LoanDuration = b.LoanDuration,
                        Aisle = b.Aisle,
                        Publisher = b.Publisher!.Name,
                        TotalAmount = b.TotalAmount,
                        AvailableAmount = b.AvailableAmount,
                        BookCopyCount = b.BookCopies.Count,
                        CategoryID = b.CategoryID,
                        PublisherID = b.PublisherID,
                        AuthorID = b.AuthorID,
                        Author = b.Author!.Name

                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }
        public async Task<UpdatePublisherDTO> CreatePublisherAsync(CreatePublisherDTO publisher)
        {
            try
            {
                var pub = new Publisher()
                {
                    Name = publisher.Name,
                    Address = publisher.Address
                };

                _context.Publishers.Add(pub);
                await _context.SaveChangesAsync();

                return new UpdatePublisherDTO() { ID=pub.ID, Name=publisher.Name, Address=publisher.Address };
            }catch(Exception ex) { }
            return null;
        }
        public async Task<UpdatePublisherDTO> UpdatePublisherAsync(int id, UpdatePublisherDTO publisher)
        {
            try
            {
                var pub = await _context.Publishers.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (pub != null) {
                    pub.Name = publisher.Name;
                    pub.Address = publisher.Address;

                    await _context.SaveChangesAsync();

                    return new UpdatePublisherDTO() { ID=publisher.ID, Name=publisher.Name,Address=publisher.Address };
                }
            }catch(Exception ex) { }
            return null;
        }
        public async Task<bool> DeletePublisherAsync(int id)
        {
            try
            {
                var pub = await _context.Publishers.Where(x =>x.ID == id).FirstOrDefaultAsync();
                if (pub != null)
                {
                    _context.Publishers.Remove(pub);
                    await _context.SaveChangesAsync();

                    return true;
                }
            }catch(Exception ex) { }
            return false;
        }
        #endregion

        #region Member
        public async Task<List<MemberDTO>> GetAllMemberAsync()
        {
            return await _context.Members.Select(a => new MemberDTO 
                {
                ID = a.ID,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                Phone = a.Phone,
                MembershipDate = a.MembershipDate,
                MembershipStatus = a.MembershipStatus,
                loans=a.loans.Select(b =>new LoanDTO { 
                    ID = b.ID,
                    LoanDate = b.LoanDate,
                    DueDate = b.DueDate,
                    ReturnDate = b.ReturnDate,
                    Status = b.Status,
                    Notes = b.Notes,
                    MemberName=a.FirstName+" "+a.LastName,
                    Staff = b.Staff.FirstName+" "+b.Staff.LastName,
                    BookTitle=b.BookCopy!.Book!.Title,
                    BookCopyID=b.BookCopyID,
                    StaffID=b.StaffID,
                    MemberID=b.MemberID,
                    FineAmount = b.FineAmount,
                }).ToList()
                })
                .ToListAsync();
        }
        public async Task<MemberDTO?> GetMemberAsync(int id)
        {
            return await _context.Members.Where(x =>x.ID == id)
                .Select(a => new MemberDTO
                {
                    ID = a.ID,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    Phone = a.Phone,
                    MembershipDate = a.MembershipDate,
                    MembershipStatus = a.MembershipStatus,
                    loans = a.loans.Select(b => new LoanDTO
                    {
                        ID = b.ID,
                        LoanDate = b.LoanDate,
                        DueDate = b.DueDate,
                        ReturnDate = b.ReturnDate,
                        Status = b.Status,
                        Notes = b.Notes,
                        MemberName = a.FirstName + " " + a.LastName,
                        Staff = b.Staff.FirstName + " " + b.Staff.LastName,
                        BookTitle = b.BookCopy!.Book!.Title,
                        BookCopyID = b.BookCopyID,
                        StaffID = b.StaffID,
                        MemberID = b.MemberID,
                        FineAmount = b.FineAmount,
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }
        public async Task<UpdateMemberDTO> CreateMemberAsync(CreateMemberDTO member)
        {
            try
            {
                var obj = new Member()
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Email = member.Email,
                    Phone= member.Phone,
                    MembershipDate = DateTime.UtcNow,
                    MembershipStatus = true
                };

                _context.Members.Add(obj);
                await _context.SaveChangesAsync();
                return new UpdateMemberDTO()
                {
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Email = obj.Email,
                    Phone = obj.Phone,
                    MembershipDate = obj.MembershipDate,
                    MembershipStatus = obj.MembershipStatus
                };
            }catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<UpdateMemberDTO> UpdateMemberAsync(int id, UpdateMemberDTO member)
        {
            try
            {
                var obj = await _context.Members.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (obj != null) { 
                    obj.FirstName= member.FirstName;
                    obj.LastName = member.LastName;
                    obj.Email = member.Email;
                    obj.Phone = member.Phone;
                    obj.MembershipStatus = member.MembershipStatus;

                    await _context.SaveChangesAsync();

                    return new UpdateMemberDTO()
                    {
                        FirstName= member.FirstName,
                        LastName= member.LastName,
                        Email= member.Email,
                        Phone= member.Phone,
                        MembershipDate=obj.MembershipDate,
                        MembershipStatus=obj.MembershipStatus
                    };
                }
            }catch(Exception ex) { }
            return null;
        }
        public async Task<bool> DeleteMemberAsync(int id)
        {
            try
            {
                var member = await _context.Members.Where(x =>x.ID == id).FirstOrDefaultAsync();
                if (member != null) { 
                    _context.Members.Remove(member);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }catch (Exception ex) { }
            return false;
        }
        #endregion

        #region Staff
        public async Task<List<StaffDTO>> GetAllStaffAsync() { 
            return await _context.Staffs
                .Select(a => new StaffDTO
                {
                    ID = a.ID,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    Phone = a.Phone,

                    loans = a.Loans.Select(b => new LoanDTO
                    {
                        ID = b.ID,
                        LoanDate = b.LoanDate,
                        DueDate = b.DueDate,
                        ReturnDate = b.ReturnDate,
                        Status = b.Status,
                        Notes = b.Notes,
                        MemberName = b.Member!.FirstName + " " + b.Member!.LastName,
                        Staff = b.Staff.FirstName + " " + b.Staff.LastName,
                        BookTitle = b.BookCopy!.Book!.Title,
                        BookCopyID = b.BookCopyID,
                        StaffID = b.StaffID,
                        MemberID = b.MemberID,
                        FineAmount = b.FineAmount,
                    }).ToList()
                })
                .ToListAsync();
        }
        public async Task<StaffDTO?> GetStaffAsync(int id)
        {
            return await _context.Staffs.Where(x =>x.ID == id)
                .Select(a => new StaffDTO
                {
                    ID = a.ID,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    Phone = a.Phone,
                    loans = a.Loans.Select(b => new LoanDTO
                    {
                        ID = b.ID,
                        LoanDate = b.LoanDate,
                        DueDate = b.DueDate,
                        ReturnDate = b.ReturnDate,
                        Status = b.Status,
                        Notes = b.Notes,
                        MemberName = a.FirstName + " " + a.LastName,
                        Staff = b.Staff.FirstName + " " + b.Staff.LastName,
                        BookTitle = b.BookCopy!.Book!.Title,
                        BookCopyID = b.BookCopyID,
                        StaffID = b.StaffID,
                        MemberID = b.MemberID,
                        FineAmount = b.FineAmount,
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }
        public async Task<UpdateStaffDTO> CreateStaffAsync(CreateStaffDTO staff)
        {
            try
            {
                var obj = new Staff()
                {
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Email = staff.Email,
                    Phone = staff.Phone,
                    Roles = staff.Roles,
                };

                _context.Staffs.Add(obj);
                await _context.SaveChangesAsync();

                return new UpdateStaffDTO() { ID = obj.ID, FirstName = staff.FirstName, LastName = staff.LastName, Email = staff.Email, Phone = staff.Phone, Roles = staff.Roles };

            }catch(Exception ex) { }
            return null;
        }
        public async Task<UpdateStaffDTO?> UpdateStaffAsync(int id, UpdateStaffDTO staff)
        {
            try {
                var obj = await _context.Staffs.Where(x => x.ID == id).FirstOrDefaultAsync();

                if (obj != null) { 
                    obj.FirstName = staff.FirstName;
                    obj.LastName = staff.LastName;
                    obj.Email = staff.Email;
                    obj.Phone = staff.Phone;
                    obj.Roles = staff.Roles;

                    await _context.SaveChangesAsync();

                    return new UpdateStaffDTO() { ID=obj.ID, FirstName = staff.FirstName,LastName = staff.LastName,Email = staff.Email,Phone = staff.Phone,Roles = staff.Roles };
                }
            }
            catch (Exception ex) { }
            return null;
        }
        public async Task<bool> DeleteStaffAsync(int id)
        {
            try { 
                var staff = await _context.Staffs.Where(x =>x.ID == id).FirstOrDefaultAsync();
                if (staff != null) { 
                    _context.Staffs.Remove(staff);
                    await _context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
        }
        #endregion

        #region Book
        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            return await _context.Book.Select(a => new BookDTO 
                { 
                ID=a.ID,
                Title=a.Title,
                ISBN=a.ISBN,
                Genre=a.Genre,
                PublishedYear=a.PublishedYear,
                Description=a.Description,
                TotalAmount=a.TotalAmount,
                AvailableAmount=a.AvailableAmount,
                LoanDuration=a.LoanDuration,
                Aisle=a.Aisle,
                Category=a.Category!.Name,
                CategoryID=a.CategoryID,
                Publisher=a.Publisher!.Name,
                PublisherID=a.PublisherID,
                Author=a.Author!.Name,
                AuthorID=a.AuthorID,
                BookCopyCount=a.BookCopies!.Count(),
                bookCopies=a.BookCopies.Select(b => new BookCopiesDTO
                {
                    ID = b.ID,
                    Price=b.Price,
                    PurchaseDate=b.PurchaseDate,
                    Status=b.Status,
                    Book=a.Title,
                    BookID=b.BookID,
                }).ToList(),
                })
                .ToListAsync();
        }
        public async Task<BookDTO?> GetBookAsync(int id)
        {
            return await _context.Book.Where(x =>x.ID == id)
                .Select(a => new BookDTO
                {
                    ID = a.ID,
                    Title = a.Title,
                    ISBN = a.ISBN,
                    Genre = a.Genre,
                    PublishedYear = a.PublishedYear,
                    Description = a.Description,
                    TotalAmount = a.TotalAmount,
                    AvailableAmount = a.AvailableAmount,
                    LoanDuration = a.LoanDuration,
                    Aisle = a.Aisle,
                    Category = a.Category!.Name,
                    CategoryID = a.CategoryID,
                    Publisher = a.Publisher!.Name,
                    PublisherID = a.PublisherID,
                    Author = a.Author!.Name,
                    AuthorID = a.AuthorID,
                    BookCopyCount = a.BookCopies!.Count(),
                    bookCopies = a.BookCopies.Select(b => new BookCopiesDTO
                    {
                        ID = b.ID,
                        Price = b.Price,
                        PurchaseDate = b.PurchaseDate,
                        Status = b.Status,
                        Book = a.Title,
                        BookID = b.BookID,
                    }).ToList(),
                })
                .FirstOrDefaultAsync();
        }
        public async Task<BookDTO> CreateBookAsync(CreateBookDTO bookDTO)
        {
            try
            {
                //Check if Category,Publisher,Author exist
                BoolResultModel check =await  CheckBooksValidation(bookDTO.CategoryID, bookDTO.PublisherID, bookDTO.AuthorID);
                if (!check.Bool)
                {
                    return null;
                }
                //else return BookDTO
                var book = new Book()
                {
                    Title= bookDTO.Title,
                    ISBN= bookDTO.ISBN,
                    Genre= bookDTO.Genre,
                    PublishedYear= bookDTO.PublishedYear,
                    Description= bookDTO.Description,
                    TotalAmount= bookDTO.TotalAmount,
                    AvailableAmount= bookDTO.AvailableAmount,
                    LoanDuration= bookDTO.LoanDuration,
                    Aisle= bookDTO.Aisle,
                    CategoryID= bookDTO.CategoryID,
                    PublisherID= bookDTO.PublisherID,
                    AuthorID= bookDTO.AuthorID,
                };

                _context.Book.Add(book);
                await _context.SaveChangesAsync();

                //Get the names of Category,Publisher,Author
                BookDetails details = await GetBooksDetails(bookDTO.CategoryID, bookDTO.PublisherID, bookDTO.AuthorID);

                return new BookDTO()
                {
                    Title = book.Title,
                    ISBN = book.ISBN,
                    Genre = book.Genre,
                    PublishedYear = book.PublishedYear,
                    Description = book.Description,
                    TotalAmount = book.TotalAmount,
                    AvailableAmount = book.AvailableAmount,
                    LoanDuration = book.LoanDuration,
                    Aisle = book.Aisle,
                    CategoryID = book.CategoryID,
                    PublisherID = book.PublisherID,
                    AuthorID=book.AuthorID,
                    Category=details.Category,
                    Publisher=details.Publisher,
                    Author=details.Author,

                };
            }
            catch (Exception ex) { }
            return null;
        }
        public async Task<BookDTO?> UpdateBookAsync(int id, UpdateBookDTO bookDTO)
        {
            try
            {
                //Check if Category,Publisher,Author exist
                BoolResultModel check = await CheckBooksValidation(bookDTO.CategoryID, bookDTO.PublisherID, bookDTO.AuthorID);
                if (!check.Bool)
                {
                    return null;
                }

                var book = await _context.Book.Where(x => x.ID  == id).FirstOrDefaultAsync();
                if(book != null)
                {
                    book.Title = bookDTO.Title;
                    book.ISBN = bookDTO.ISBN;
                    book.Genre = bookDTO.Genre;
                    book.PublishedYear = bookDTO.PublishedYear;
                    book.Description = bookDTO.Description;
                    book.TotalAmount = bookDTO.TotalAmount;
                    book.AvailableAmount = bookDTO.AvailableAmount;
                    book.LoanDuration = bookDTO.LoanDuration;
                    book.Aisle = bookDTO.Aisle;
                    book.CategoryID = bookDTO.CategoryID;
                    book.PublisherID = bookDTO.PublisherID;
                    book.AuthorID = bookDTO.AuthorID;

                    await _context.SaveChangesAsync();

                    //Get the names of Category,Publisher,Author
                    BookDetails details = await GetBooksDetails(bookDTO.CategoryID, bookDTO.PublisherID, bookDTO.AuthorID);

                    return new BookDTO()
                    {
                        Title = book.Title,
                        ISBN = book.ISBN,
                        Genre = book.Genre,
                        PublishedYear = book.PublishedYear,
                        Description = book.Description,
                        TotalAmount = book.TotalAmount,
                        AvailableAmount = book.AvailableAmount,
                        LoanDuration = book.LoanDuration,
                        Aisle = book.Aisle,
                        CategoryID = book.CategoryID,
                        PublisherID = book.PublisherID,
                        AuthorID = book.AuthorID,
                        Category = details.Category,
                        Publisher = details.Publisher,
                        Author = details.Author,

                    };
                }
            }
            catch (Exception ex) { }

            return null;
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            try
            {
                //TODO: check if the existing bookcopies have been removed

                var book = await _context.Book.Where(x =>x.ID == id).FirstOrDefaultAsync();
                if(book != null)
                {
                    _context.Book.Remove(book);
                    await _context.SaveChangesAsync();
                }

            }catch (Exception ex) { }
            return false;
        }
        #endregion

        #region BookCopy
        public async Task<List<BookCopiesDTO>> GetAllBookCopiesAsync()
        {
            return await _context.BookCopies
                 .Select(a => new BookCopiesDTO
                 {
                     ID = a.ID,
                    Price = a.Price,
                    PurchaseDate = a.PurchaseDate,
                    Status = a.Status,
                    Book=a.Book!.Title,
                    BookID = a.BookID,

                     loans = a.Loans.Select(b => new LoanDTO
                     {
                         ID = b.ID,
                         LoanDate = b.LoanDate,
                         DueDate = b.DueDate,
                         ReturnDate = b.ReturnDate,
                         Status = b.Status,
                         Notes = b.Notes,
                         MemberName = b.Member!.FirstName + " " + b.Member!.LastName,
                         Staff = b.Staff.FirstName + " " + b.Staff.LastName,
                         BookTitle = b.BookCopy!.Book!.Title,
                         BookCopyID = b.BookCopyID,
                         StaffID = b.StaffID,
                         MemberID = b.MemberID,
                         FineAmount = b.FineAmount,
                     }).ToList()
                 })
                .ToListAsync();
        }
        public async Task<BookCopiesDTO?> GetBookCopyAsync(int id){
            return await _context.BookCopies
                 .Select(a => new BookCopiesDTO
                 {
                     ID = a.ID,
                     Price = a.Price,
                     PurchaseDate = a.PurchaseDate,
                     Status = a.Status,
                     Book = a.Book!.Title,
                     BookID = a.BookID,

                     loans = a.Loans.Select(b => new LoanDTO
                     {
                         ID = b.ID,
                         LoanDate = b.LoanDate,
                         DueDate = b.DueDate,
                         ReturnDate = b.ReturnDate,
                         Status = b.Status,
                         Notes = b.Notes,
                         MemberName = b.Member!.FirstName + " " + b.Member!.LastName,
                         Staff = b.Staff.FirstName + " " + b.Staff.LastName,
                         BookTitle = b.BookCopy!.Book!.Title,
                         BookCopyID = b.BookCopyID,
                         StaffID = b.StaffID,
                         MemberID = b.MemberID,
                         FineAmount = b.FineAmount,
                     }).ToList()
                 })
                .FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<BookCopiesDTO> CreateBookCopyAsync(CreateBookCopiesDTO book)
        {
            try
            {
                //check if book parent exist
                var bookParent = await CheckBookParentExists(book.BookID);
                if (bookParent.Bool)
                {
                    var bookCopy = new BookCopy();
                    bookCopy.PurchaseDate = book.PurchaseDate;
                    bookCopy.Price = book.Price;
                    bookCopy.Status = book.Status;
                    bookCopy.BookID = book.BookID;

                    _context.BookCopies.Add(bookCopy);

                    await _context.SaveChangesAsync();

                    return new BookCopiesDTO()
                    {
                        ID=bookCopy.ID,
                        PurchaseDate=bookCopy.PurchaseDate,
                        Price=bookCopy.Price,
                        Status=bookCopy.Status,
                        BookID=bookCopy.BookID,
                        Book=bookParent.Description
                    };
                }

            }catch (Exception ex) { }

            return null; 
        }
        public async Task<BookCopiesDTO?> UpdateBookCopyAsync(int id, UpdateBookCopiesDTO updateBook)
        {
            try {
                // check if book is borrowed. If the book is borrowed and status is changed, alert the staff
                var bookCopy = await _context.BookCopies.Where(x => x.ID == id).FirstOrDefaultAsync();
                if( bookCopy != null)
                {
                    //TODO: check if book is borrowed. If the book is borrowed and status is changed, alert the staff
                    if(bookCopy.Status != updateBook.Status)
                    {
                        return null;
                    }
                    //check if book parent exist
                    var bookParent = await CheckBookParentExists(updateBook.BookID);
                    if (bookParent.Bool == false) {
                        return null;
                    }

                    bookCopy.Price=updateBook.Price;
                    bookCopy.PurchaseDate=updateBook.PurchaseDate;
                    bookCopy.BookID=updateBook.BookID;

                    await _context.SaveChangesAsync();

                    return new BookCopiesDTO(){ ID=bookCopy.ID,PurchaseDate=bookCopy.PurchaseDate, Price=bookCopy.Price, Status=bookCopy.Status, BookID=bookCopy.BookID };
                }
            }
            catch (Exception ex) { } return null;
        }
        public async Task<bool> DeleteBookCopyAsync(int id)
        {
            var bookCopy = await _context.BookCopies.Where(x =>x.ID == id).FirstOrDefaultAsync();
            //make sure the book copy status set to D - Dispose
            if(bookCopy != null && bookCopy.Status != "B" && bookCopy.Status !="A")
            {
                _context.BookCopies.Remove(bookCopy);
                await _context.SaveChangesAsync() ;
                return true;
            }
            return false;
        }
        #endregion

        #region Loan
        public async Task<List<LoanDTO>> GetAllLoansAsync()
        {
            return await _context.Loans.Select(a => new LoanDTO
            {
                ID=a.ID,
                LoanDate=a.LoanDate,
                DueDate=a.DueDate,
                ReturnDate=a.ReturnDate,
                Status=a.Status,
                FineAmount=a.FineAmount,
                Notes=a.Notes,
                MemberID=a.MemberID,
                MemberName=a.Member!.FirstName +" "+a.Member!.LastName,
                StaffID=a.StaffID,
                Staff=a.Staff!.FirstName +" "+a.Staff!.LastName,
                BookCopyID=a.BookCopyID,
                BookTitle=a.BookCopy!.Book!.Title

            })
                .ToListAsync();
        }
        public async Task<LoanDTO?> GetLoanAsync(int id)
        {
            return await _context.Loans.Where(x =>x.ID==id).Select(a => new LoanDTO
            {
                ID = a.ID,
                LoanDate = a.LoanDate,
                DueDate = a.DueDate,
                ReturnDate = a.ReturnDate,
                Status = a.Status,
                FineAmount = a.FineAmount,
                Notes = a.Notes,
                MemberID = a.MemberID,
                MemberName = a.Member!.FirstName + " " + a.Member!.LastName,
                StaffID = a.StaffID,
                Staff = a.Staff!.FirstName + " " + a.Staff!.LastName,
                BookCopyID = a.BookCopyID,
                BookTitle = a.BookCopy!.Book!.Title

            })
                .FirstOrDefaultAsync();
        }
        public async Task<LoanDTO> CreateLoanAsync(CreateLoanDTO loanDTO)
        {
            try {
                var check = await CheckLoanApplicationValidation(loanDTO.BookCopyID, loanDTO.MemberID, loanDTO.StaffID);
                if (check.Bool)
                {
                    //check if the member is active
                    var member =await _context.Members.FirstOrDefaultAsync(x => x.ID == loanDTO.MemberID);

                    if ( member != null && member.MembershipStatus == true)
                    {
                        var bookID = await _context.BookCopies.Where(x => x.ID == loanDTO.BookCopyID).Select(b => b.BookID).FirstOrDefaultAsync();
                        var book = await _context.Book.Where(x => x.ID == bookID).FirstOrDefaultAsync();

                        var loan = new Loan();
                        loan.LoanDate = DateTime.UtcNow;
                        loan.DueDate = DateTime.UtcNow.AddDays(book.LoanDuration);
                        loan.Status = "B";
                        loan.Notes = loanDTO.Notes;
                        loan.MemberID = loanDTO.MemberID;
                        loan.StaffID = loanDTO.StaffID;
                        loan.BookCopyID = loanDTO.BookCopyID;

                        _context.Loans.Add(loan);
                        await _context.SaveChangesAsync();

                        var staff = await _context.Staffs.FirstOrDefaultAsync(x => x.ID == loanDTO.StaffID);

                        return new LoanDTO()
                        {
                            ID = loan.ID,
                            LoanDate = loan.LoanDate,
                            DueDate = loan.DueDate,
                            Status = loan.Status,
                            Notes = loanDTO.Notes,
                            MemberName = member.FirstName + " " +member.LastName,
                            Staff = staff.FirstName +" "+ staff.LastName,
                            BookTitle = book.Title,
                            MemberID = loanDTO.MemberID,
                            StaffID = loanDTO.StaffID,
                            BookCopyID = loan.BookCopyID,
                        };
                    }
                }
            
            }
            catch(Exception ex) { }
            return null;
        }
        public async Task<LoanDTO> UpdateLoanDTOAsync(int id, UpdateLoanDTO loanDTO)
        {
            try {
                var loan = await _context.Loans.SingleOrDefaultAsync(x => x.ID == id);

                if (loan != null) {
                    loan.Notes = loanDTO.Notes;

                    await _context.SaveChangesAsync();

                    var member = await _context.Members.FirstOrDefaultAsync(x => x.ID == loan.MemberID);
                    var staff = await _context.Staffs.FirstOrDefaultAsync(x => x.ID == loan.StaffID);
                    var bookID = await _context.BookCopies.Where(x => x.ID == loan.BookCopyID).Select(b => b.BookID).FirstOrDefaultAsync();
                    var book = await _context.Book.Where(x => x.ID == bookID).FirstOrDefaultAsync();

                    return new LoanDTO()
                    {
                        ID = loan.ID,
                        LoanDate = loan.LoanDate,
                        DueDate = loan.DueDate,
                        ReturnDate = loan.ReturnDate,
                        Status = loan.Status,
                        Notes = loan.Notes,
                        FineAmount = loan.FineAmount,
                        MemberID = loan.MemberID,
                        StaffID = loan.StaffID,
                        BookCopyID = loan.BookCopyID,
                        MemberName = member.FirstName + " " + member.LastName,
                        Staff = staff.FirstName + " " + staff.LastName,
                        BookTitle = book.Title,
                    };
                }
            }
            catch (Exception ex) { }
            return null;
        }
        public async Task<LoanDTO> ExtendLoanAsync(int id)
        {
            try
            {
                var loan = await _context.Loans.SingleOrDefaultAsync(x => x.ID == id);

                if (loan != null)
                {
                    var bookID = await _context.BookCopies.Where(x => x.ID == loan.BookCopyID).Select(b => b.BookID).FirstOrDefaultAsync();
                    var book = await _context.Book.Where(x => x.ID == bookID).FirstOrDefaultAsync();
                    var category = await _context.Categories.Where(x => x.ID == book.CategoryID).FirstOrDefaultAsync();
                    if (loan.DueDate > DateTime.UtcNow)
                    {
                        loan.Status = "R";
                        loan.FineAmount += (category.FinePrice * (DateTime.UtcNow - loan.DueDate).Days);

                    }
                    loan.DueDate.AddDays(book.LoanDuration);

                    await _context.SaveChangesAsync();
                    var member = await _context.Members.FirstOrDefaultAsync(x => x.ID == loan.MemberID);
                    var staff = await _context.Staffs.FirstOrDefaultAsync(x => x.ID == loan.StaffID);

                    return new LoanDTO()
                    {
                        ID = loan.ID,
                        LoanDate = loan.LoanDate,
                        DueDate = loan.DueDate,
                        ReturnDate = loan.ReturnDate,
                        Status = loan.Status,
                        Notes = loan.Notes,
                        FineAmount = loan.FineAmount,
                        MemberID = loan.MemberID,
                        StaffID = loan.StaffID,
                        BookCopyID = loan.BookCopyID,
                        MemberName = member.FirstName + " " + member.LastName,
                        Staff = staff.FirstName + " " + staff.LastName,
                        BookTitle = book.Title,
                    };
                }
            }
            catch (Exception ex) { }
            return null;
        } //Extend loan duration
        public async Task<LoanDTO> ReturnLoanAsync(int id)
        {
            try
            {
                var loan = await _context.Loans.SingleOrDefaultAsync(x => x.ID == id);

                if (loan != null)
                {
                    var bookID = await _context.BookCopies.Where(x => x.ID == loan.BookCopyID).Select(b => b.BookID).FirstOrDefaultAsync();
                    var book = await _context.Book.Where(x => x.ID == bookID).FirstOrDefaultAsync();
                    var category = await _context.Categories.Where(x =>x.ID == book.CategoryID).FirstOrDefaultAsync();
                    
                    if (loan.DueDate > DateTime.UtcNow)
                    {
                        loan.FineAmount += (category.FinePrice * (DateTime.UtcNow - loan.DueDate).Days);
                    }

                    loan.Status = "R";

                    await _context.SaveChangesAsync();
                    var member = await _context.Members.FirstOrDefaultAsync(x => x.ID == loan.MemberID);
                    var staff = await _context.Staffs.FirstOrDefaultAsync(x => x.ID == loan.StaffID);

                    return new LoanDTO()
                    {
                        ID = loan.ID,
                        LoanDate = loan.LoanDate,
                        DueDate = loan.DueDate,
                        ReturnDate = loan.ReturnDate,
                        Status = loan.Status,
                        Notes = loan.Notes,
                        FineAmount = loan.FineAmount,
                        MemberID = loan.MemberID,
                        StaffID = loan.StaffID,
                        BookCopyID = loan.BookCopyID,
                        MemberName = member.FirstName + " " + member.LastName,
                        Staff = staff.FirstName + " " + staff.LastName,
                        BookTitle = book.Title,
                    };
                }
            }
            catch (Exception ex) { }
            return null;
        }
        public async Task<bool> DeleteLoanAsyncs(int id)
        {
            try
            {
                //check if book already been return
                var loan = await _context.Loans.SingleOrDefaultAsync(x => x.ID == id);

                if(loan != null &&loan.Status == "R")
                {
                    _context.Loans.Remove(loan);
                    await _context.SaveChangesAsync();
                    return true;
                }

            }catch(Exception ex) { } return false;
        }
        #endregion

        #region Utilities
        private async Task<BoolResultModel> CheckBooksValidation (int categoryID,int publisherID, int authorID)
        {
            var exists = await Task.WhenAll(
                _context.Categories.Where(x => x.ID == categoryID).AnyAsync(),
                _context.Publishers.Where(x => x.ID == publisherID).AnyAsync(),
                _context.Author.Where(x => x.ID != authorID).AnyAsync()
                );

            if (exists[0] && exists[1] && exists[2]) { 
                return new BoolResultModel() { Bool = true};
            }
            return new BoolResultModel() { Bool = false ,Description= BuildErrorMessageBook(exists[0], exists[1], exists[2])};
        }

        private string BuildErrorMessageBook(bool cat,bool pub,bool auth)
        {
            var errors = new List<String>();
            if (!cat) errors.Add("Category not exist");
            if (!pub) errors.Add("Publisher not exist");
            if (!auth) errors.Add("Author not exist");

            return string.Join(" and ", errors);
        }

        private async Task<BookDetails> GetBooksDetails(int categoryID, int publisherID, int authorID)
        {
            BookDetails obj = new BookDetails() { };

            obj.Category = await _context.Categories.Where(x => x.ID == categoryID).Select(p => p.Name).FirstOrDefaultAsync();
            obj.Publisher = await _context.Publishers.Where(x =>x.ID == publisherID).Select(p => p.Name).FirstOrDefaultAsync();
            obj.Author = await _context.Author.Where(x =>x.ID == authorID).Select(p => p.Name).FirstOrDefaultAsync();
            return obj;
        }

        private async Task<BoolResultModel> CheckBookParentExists(int bookID)
        {
            var book = await _context.Book.Where(x =>x.ID == bookID).FirstOrDefaultAsync();

            if (book == null) return new BoolResultModel() { Bool=false};
            return new BoolResultModel() { Bool = true, Description=book.Title };
        }

        private async Task<BoolResultModel> CheckLoanApplicationValidation (int bookCopyID,int memberID,int staffID)
        {
            var exists = await Task.WhenAll(
                _context.BookCopies.Where(x => x.ID == bookCopyID).AnyAsync(),
                _context.Members.Where(x => x.ID == memberID).AnyAsync(),
                _context.Staffs.Where(x=>x.ID == staffID).AnyAsync()
                );

            if (exists[0] && exists[1] && exists[2])
            {
                return new BoolResultModel() { Bool = true };
            }
            return new BoolResultModel() { Bool = false, Description = BuildErrorMessageLoanCreation(exists[0], exists[1], exists[2]) };
        }

        private string BuildErrorMessageLoanCreation(bool bookCopy, bool member, bool staff)
        {
            var errors = new List<String>();
            if (!bookCopy) errors.Add("Book Copy not exist");
            if (!member) errors.Add("Member not exist");
            if (!staff) errors.Add("Staff not exist");

            return string.Join(" and ", errors);
        }
        #endregion
    }
}
