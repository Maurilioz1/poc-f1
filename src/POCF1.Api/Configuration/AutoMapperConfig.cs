using AutoMapper;
using POCF1.Api.ViewModels;
using POCF1.Business.Models;

namespace POCF1.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Equipe, EquipeViewModel>().ReverseMap();
            CreateMap<Piloto, PilotoViewModel>().ReverseMap();
            CreateMap<Corrida, CorridaViewModel>().ReverseMap();
        }
    }
}
