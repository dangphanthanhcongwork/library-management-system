using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Infrastucture.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrowing> BookBorrowings { get; set; }
        public DbSet<BookBorrowingDetail> BookBorrowingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many relationship between User and BookBorrowing (User as Requestor)
            modelBuilder.Entity<User>()
                .HasMany(u => u.BookBorrowingAsRequester)
                .WithOne(b => b.Requestor)
                .HasForeignKey(b => b.RequestorId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many relationship between User and BookBorrowing (User as Approver)
            modelBuilder.Entity<User>()
                .HasMany(u => u.BookBorrowingAsApprover)
                .WithOne(b => b.Approver)
                .HasForeignKey(b => b.ApproverId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many relationship between Category and Book
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many relationship between BookBorrowing and BookBorrowingDetail
            modelBuilder.Entity<BookBorrowing>()
                .HasMany(bb => bb.BookBorrowingDetails)
                .WithOne(bbd => bbd.BookBorrowing)
                .HasForeignKey(bbd => bbd.BookBorrowingId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many relationship between Book and BookBorrowingDetail
            modelBuilder.Entity<Book>()
                .HasMany(b => b.BookBorrowingDetails)
                .WithOne(bb => bb.Book)
                .HasForeignKey(bb => bb.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}