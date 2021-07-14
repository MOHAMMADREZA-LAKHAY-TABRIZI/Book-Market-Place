using ApplicationServices.DTO;
using AutoMapper;
using Entities.IRepositories;
using Entities.IUnitOfWork;
using Entities.POCOEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationServices.Services.BookStoreServices
{
    public class BookStoreService : IBookStoreService
    {
        private readonly IRepositories<Bookstore> repositories;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BookStoreService(IRepositories<Bookstore> repositories, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.repositories = repositories;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Delete(int ID)
        {
            repositories.Delete(ID);

            await unitOfWork.Save();
        }

        public async Task<List<Bookstore>> GetAll()
        {
            var allRecords = await repositories.GetAll();

            return allRecords;
        }

        public async ValueTask<Bookstore> GetByID(int ID)
        {
            var bookStore = await repositories.Get(ID);

            return bookStore;
        }

        public IQueryable<Bookstore> GetQuery()
        {
            return repositories.GetQuery();
        }

        public async Task Insert(BookStoreDTO bookStore)
        {
            repositories.Insert(mapper.Map<Bookstore>(bookStore));

            await unitOfWork.Save();

            return;
        }

        public async Task Update(BookStoreUpdateDTO bookStore)
        {
            repositories.Update(mapper.Map<Bookstore>(bookStore));

            await unitOfWork.Save();

            return;
        }
    }
}
