namespace Entities.POCOEntities
{
    public class Book : BaseEntity.BaseEntity
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string AutherName { get; set; }

        public string PublishDate { get; set; }

        public short PublishCount { get; set; }

        public bool IsOld { get; set; }

        //public BookCategory BookCategory { get; set; }

        //public Publisher Publisher { get; set; }

        //public List<BookStore_Book> BookStore_Books { get; set; }

        //public List<Author_Book> Author_Books { get; set; }

        //public List<Book_Translator> Book_Translators { get; set; }
    }
}
