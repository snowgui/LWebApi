using AutoMapper;
using LocadadoraWebApi.Servicos.Mapeamento;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraWebApi.Ioc.ExtensaoMapeamento
{
    public static class ExtensaoMapeamento
    {
        public static IServiceCollection RegistrarMapeamentos(this IServiceCollection servicos)
        {
            MapperConfiguration mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapeamentoProfile());
            });

            servicos.AddSingleton(c => mapper.CreateMapper());

            return servicos;
        }
    }
}
