using ApplicationServices.DTO;
using AutoMapper;
using Entities.IRepositories;
using Entities.IUnitOfWork;
using Entities.POCOEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class BookServices : IBookServices
    {
        private readonly IRepositories<Book> repositories;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BookServices(IRepositories<Book> repositories, IUnitOfWork unitOfWork, IMapper mapper)
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

        public async Task<List<Book>> GetAll()
        {
            var allRecords = await repositories.GetAll();

            return allRecords;
        }

        public async ValueTask<Book> GetByID(int ID)
        {
            var book = await repositories.Get(ID);

            return book;
        }

        public IQueryable<Book> GetQuery()
        {
            return repositories.GetQuery();
        }

        public async Task Insert(BookDTO book)
        {
            
            repositories.Insert(mapper.Map<Book>(book));

            await unitOfWork.Save();

            return;

        }

        public async Task Update(BookUpdateDTO book)
        {

            repositories.Update(mapper.Map<Book>(book));

            await unitOfWork.Save();

            return;

        }


    }
}
