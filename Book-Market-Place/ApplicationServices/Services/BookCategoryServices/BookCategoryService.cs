using ApplicationServices.DTO;
using AutoMapper;
using Entities.IRepositories;
using Entities.IUnitOfWork;
using Entities.POCOEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationServices.Services.BookCategoryServices
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IRepositories<BookCategory> repositories;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BookCategoryService(IRepositories<BookCategory> repositories, IUnitOfWork unitOfWork, IMapper mapper)
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

        public async Task<List<BookCategory>> GetAll()
        {
            var allRecords = await repositories.GetAll();

            return allRecords;
        }

        public async ValueTask<BookCategory> GetByID(int ID)
        {
            var bookCategory = await repositories.Get(ID);

            return bookCategory;
        }

        public IQueryable<BookCategory> GetQuery()
        {
            return repositories.GetQuery();
        }

        public async Task Insert(BookCategoryDTO bookCategory)
        {
            repositories.Insert(mapper.Map<BookCategory>(bookCategory));

            await unitOfWork.Save();

            return;
        }

        public async Task Update(BookCategoryUpdateDTO bookCategory)
        {
            repositories.Update(mapper.Map<BookCategory>(bookCategory));

            await unitOfWork.Save();

            return;
        }
    }
}
