using ApplicationServices.DTO;
using AutoMapper;
using Entities.POCOEntities;

namespace ApplicationServices.Mapper
{
    public class BookStoreMapper : Profile
    {
        public BookStoreMapper()
        {
            CreateMap<BookStoreDTO, Bookstore>();

            CreateMap<BookStoreUpdateDTO, Bookstore>();
        }
    }
}
