using Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;

namespace EF.Persistance.DataBase
{
    public class BookMarketPlaceDBContex : DbContext
    {

        public DbSet<Book> Books { get; set; }

        public DbSet<Bookstore> Bookstores { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        //public DbSet<Author_Book> Author_Books { get; set; }

        // public DbSet<Book_Translator> Book_Translators { get; set; }

        // public DbSet<Publisher> Publishers { get; set; }

        // public DbSet<BookStore_Book> BookStore_Books { get; set; }


        public BookMarketPlaceDBContex()
        {

        }

        public BookMarketPlaceDBContex(DbContextOptions<BookMarketPlaceDBContex> dbContextOptions) : base(dbContextOptions)
        {

        }

    }
}
