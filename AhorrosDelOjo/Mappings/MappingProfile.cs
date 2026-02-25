using AutoMapper;
using FinanzasWeb.Dtos;
using FinanzasWeb.Models;

namespace FinanzasWeb.Mappings
{
    public class MappingProfile : Profile
    {
        /// Dependency Injection utilizado 
        public MappingProfile()
        {
            CreateMap<Gasto, GastoDto>().ReverseMap();
        }
    }
}