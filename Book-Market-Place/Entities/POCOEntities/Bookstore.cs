using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.POCOEntities
{
    public class Bookstore : BaseEntity.BaseEntity
    {
        public string StoreName { get; set; }

        public string Adress { get; set; }

        public string TelPhone { get; set; }

        public string SaleManName { get; set; }

        public ushort Rating { get; set; }

        //public DateTime SalemanBirthDate { get; set; }

        //public List<BookStore_Book> BookStore_Books { get; set; }

    }
}
