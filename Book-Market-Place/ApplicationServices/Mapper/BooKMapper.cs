using ApplicationServices.DTO;
using AutoMapper;
using Entities.POCOEntities;

namespace ApplicationServices.Mapper
{
    public class BooKMapper : Profile
    {
        public BooKMapper()
        {
            CreateMap<BookDTO, Book>();

            //CreateMap<BookUpdateDTO, Book>();

            CreateMap<BookUpdateDTO, Book>();
        }
    }
}
