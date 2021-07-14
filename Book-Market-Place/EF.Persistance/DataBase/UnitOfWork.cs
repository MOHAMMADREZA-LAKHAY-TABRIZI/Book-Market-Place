using Entities.IUnitOfWork;
using System.Threading.Tasks;

namespace EF.Persistance.DataBase
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookMarketPlaceDBContex bookMarketPlaceDBContex;

        public UnitOfWork(BookMarketPlaceDBContex bookMarketPlaceDBContex)
        {
            this.bookMarketPlaceDBContex = bookMarketPlaceDBContex;
        }

        public Task Save()
        {
            return bookMarketPlaceDBContex.SaveChangesAsync();
        }
    }
}
