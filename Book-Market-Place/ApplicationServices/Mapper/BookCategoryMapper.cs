using ApplicationServices.DTO;
using AutoMapper;
using Entities.POCOEntities;

namespace ApplicationServices.Mapper
{
    public class BookCategoryMapper : Profile
    {
        public BookCategoryMapper()
        {
            CreateMap<BookCategoryDTO, BookCategory>();

            CreateMap<BookCategoryUpdateDTO, BookCategory>();
        }

    }
}
