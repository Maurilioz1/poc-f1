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
            CreateMap<PilotoViewModel, Piloto>();

            CreateMap<Piloto, PilotoViewModel>()
                .ForMember(dest => dest.NomeEquipe, opt => opt.MapFrom(src => src.Equipe.Nome));
        }
    }
}
