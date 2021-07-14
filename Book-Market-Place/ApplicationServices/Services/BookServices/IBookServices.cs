using ApplicationServices.DTO;
using Entities.POCOEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public interface IBookServices
    {
        Task Insert(BookDTO book);

        Task Update(BookUpdateDTO book);

        Task Delete(int ID);

        ValueTask<Book> GetByID(int ID);

        Task<List<Book>> GetAll();

        IQueryable<Book> GetQuery();

    }
}
