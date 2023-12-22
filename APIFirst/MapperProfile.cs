using APIFirst.DTOs.CategoryDtos;
using APIFirst.Entities;
using AutoMapper;

namespace APIFirst
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            {
                CreateMap<CreateCategoryDto, Category>();
                CreateMap<CreateCategoryDto, Category>()
                    .ForMember(destination=>destination.Tag,
                    opr=>opr.MapFrom(src=>src.TagName));
            }
        }
    }
}
