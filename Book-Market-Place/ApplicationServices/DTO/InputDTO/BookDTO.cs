using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.DTO
{
    public class BookDTO
    {

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string AutherName { get; set; }

        public string PublishDate { get; set; }

        public short PublishCount { get; set; }

        public bool IsOld { get; set; }
    }
}
