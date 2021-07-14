using ApplicationServices.DTO;
using Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.BookCategoryServices
{
    public interface IBookCategoryService
    {
        Task Insert(BookCategoryDTO book);

        Task Update(BookCategoryUpdateDTO book);

        Task Delete(int ID);

        ValueTask<BookCategory> GetByID(int ID);

        Task<List<BookCategory>> GetAll();

        IQueryable<BookCategory> GetQuery();
    }
}
