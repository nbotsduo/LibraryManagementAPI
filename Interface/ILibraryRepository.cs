using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Entities;

namespace LibraryManagementSystemAPI.Interface
{
    public interface ILibraryRepository
    {
        #region Author
        Task<List<AuthorDTO>> GetAllAuthorsAsync();
        Task<AuthorDTO?> GetAuthorsAsync(int id);
        Task<UpdateAuthorDTO> CreateAuthorAsync(CreateAuthorDTO create);
        Task<UpdateAuthorDTO?> UpdateAuthorAsync(int id,UpdateAuthorDTO update);
        Task<bool> DeleteAuthorAsync(int ID);
        #endregion

        #region Category
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO?> GetCategoriesAsync(int id);
        Task<UpdateCategoryDTO> CreateCategoryAsync(CreateCategoryDTO category);
        Task<UpdateCategoryDTO> UpdateCategoryAsync(int id,UpdateCategoryDTO category);
        Task<bool> DeleteCategoryAsync(int id);
        #endregion

        #region Publisher
        Task<List<PublisherDTO>> GetAllPublisherAsync();
        Task<PublisherDTO?> GetPublisherAsync(int id);
        Task<UpdatePublisherDTO> CreatePublisherAsync(CreatePublisherDTO publisher);
        Task<UpdatePublisherDTO> UpdatePublisherAsync(int id,UpdatePublisherDTO publisher);
        Task<bool> DeletePublisherAsync(int id);
        #endregion

        #region Member
        Task<List<MemberDTO>> GetAllMemberAsync();
        Task<MemberDTO?> GetMemberAsync(int id);
        Task<UpdateMemberDTO> CreateMemberAsync(CreateMemberDTO member);
        Task<UpdateMemberDTO> UpdateMemberAsync(int id, UpdateMemberDTO member);
        Task<bool> DeleteMemberAsync(int id);
        #endregion

        #region Staff
        Task<List<StaffDTO>> GetAllStaffAsync();
        Task <StaffDTO?> GetStaffAsync(int id);
        Task <UpdateStaffDTO> CreateStaffAsync(CreateStaffDTO staff);
        Task <UpdateStaffDTO?> UpdateStaffAsync(int id,UpdateStaffDTO staff);
        Task <bool> DeleteStaffAsync(int id);
        #endregion

        #region Book
        Task<List<BookDTO>> GetAllBooksAsync();
        Task<BookDTO?> GetBookAsync(int id);
        Task<BookDTO> CreateBookAsync(CreateBookDTO book);
        Task<BookDTO?> UpdateBookAsync(int id, UpdateBookDTO updateBook);
        Task<bool> DeleteBookAsync(int id);
        #endregion

        #region BookCopy
        Task<List<BookCopiesDTO>> GetAllBookCopiesAsync();
        Task<BookCopiesDTO?> GetBookCopyAsync(int id);
        Task<BookCopiesDTO> CreateBookCopyAsync(CreateBookCopiesDTO book);
        Task<BookCopiesDTO?> UpdateBookCopyAsync(int id, UpdateBookCopiesDTO updateBook);
        Task<bool> DeleteBookCopyAsync(int id);
        #endregion

        #region Loan
        Task<List<LoanDTO>> GetAllLoansAsync();
        Task<LoanDTO?> GetLoanAsync(int id);
        Task<LoanDTO> CreateLoanAsync(CreateLoanDTO loan);
        Task<LoanDTO> UpdateLoanDTOAsync(int id,UpdateLoanDTO loan);
        Task<LoanDTO> ExtendLoanAsync(int id); //Extend loan duration
        Task<LoanDTO> ReturnLoanAsync(int id); //Return book loan
        Task<bool> DeleteLoanAsyncs(int id);
        #endregion
        //Task<Publisher> GetPublisherAsync(string name);
        ////Books
        //Task<List<Book>> GetAllBooksAsync();
    }
}
