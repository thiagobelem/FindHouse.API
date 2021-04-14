using AutoMapper;
using FindHouse.Business.Models;
using FindHouse.API.ViewModels;

namespace FindHouse.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Anunciante, AnuncianteViewModel>().ReverseMap();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<Endereco, EnderecoViewModel>().ForMember(dest => dest.Imovel, opt => opt.Ignore());
            CreateMap<Imovel, ImovelViewModel>().ForMember(dest => dest.NomeAnunciante, opt => opt.MapFrom(a => a.Anunciante.Nome))
                                                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(a => a.Endereco));
            CreateMap<ImovelViewModel, Imovel>();
        }
    }
}
