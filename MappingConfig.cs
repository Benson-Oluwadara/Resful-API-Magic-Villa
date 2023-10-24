using AutoMapper;
using MagicVilla_Api.Models;
using MagicVilla_Api.Models.DTO;

namespace MagicVilla_Api
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            //CreateMap<VillaDTO, VillaCreateDTO>();
            //CreateMap<VillaCreateDTO, VillaDTO>();

            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreatedDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();




        }
    }
}
