using AutoMapper;
using Monster_Review_Store.DTO;
using Monster_Review_Store.Models;

namespace Monster_Review_Store.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Monster, DragonDTO>();
            CreateMap<Category,CategoryDTO>();
            CreateMap<Country, CountryDTO>();
        }
    }
}
