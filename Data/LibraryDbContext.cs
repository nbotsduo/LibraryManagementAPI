
using LibraryManagementSystemAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Author> Author => Set<Author>();
        public DbSet<Book> Book => Set<Book>();
        public DbSet<BookCopy> BookCopies => Set<BookCopy>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Loan> Loans => Set<Loan>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Publisher> Publishers => Set<Publisher>();
        public DbSet<Staff> Staffs => Set<Staff>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(b=>b.ID);
                entity.HasMany(b => b.Books)
                      .WithOne(b => b.Author)
                      .HasForeignKey(b => b.AuthorID)
                      .IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.ID);

                entity.HasMany(b => b.BookCopies).WithOne(b => b.Book).HasForeignKey(b => b.BookID).IsRequired();
            });

            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.HasKey(b => b.ID);
                entity.HasOne(b => b.Book).WithMany(b => b.BookCopies).HasForeignKey(b => b.BookID).IsRequired();
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(b => b.ID);

                entity.HasOne(b => b.BookCopy).WithMany(b => b.Loans).HasForeignKey(b => b.BookCopyID).IsRequired();
                entity.HasOne(b => b.Member).WithMany(b => b.loans).HasForeignKey(b => b.MemberID).IsRequired();
                entity.HasOne(b => b.Staff).WithMany(b => b.Loans).HasForeignKey(b => b.StaffID).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(b => b.ID);

                entity.HasMany(b => b.books).WithOne(b => b.Category).HasForeignKey(b => b.CategoryID).IsRequired();
            });

            

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(b => b.ID);

                entity.HasMany(b => b.loans).WithOne(b => b.Member).HasForeignKey(b =>b.MemberID).IsRequired();
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(b => b.ID);

                entity.HasMany(b => b.Books).WithOne(b => b.Publisher).HasForeignKey(b =>b.PublisherID).IsRequired();
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(b => b.ID);

                entity.HasMany(b => b.Loans).WithOne(b => b.Staff).HasForeignKey(b => b.StaffID).IsRequired();
            });
        }
    }
}
