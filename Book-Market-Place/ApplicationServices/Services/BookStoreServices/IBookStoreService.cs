using ApplicationServices.DTO;
using Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.BookStoreServices
{
    public interface IBookStoreService
    {
        Task Insert(BookStoreDTO book);

        Task Update(BookStoreUpdateDTO book);

        Task Delete(int ID);

        ValueTask<Bookstore> GetByID(int ID);

        Task<List<Bookstore>> GetAll();

        IQueryable<Bookstore> GetQuery();
    }
}
