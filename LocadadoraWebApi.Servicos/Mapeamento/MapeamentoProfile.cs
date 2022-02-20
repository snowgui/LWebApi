using AutoMapper;
using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;

namespace LocadadoraWebApi.Servicos.Mapeamento
{
    public class MapeamentoProfile : Profile
    {
        public MapeamentoProfile()
        {            
            CreateMap<Filme, FilmeDto>()
                .ReverseMap();
        }
    }
}
