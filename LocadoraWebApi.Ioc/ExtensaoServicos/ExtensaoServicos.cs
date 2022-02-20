using LocadadoraWebApi.Servicos.Servicos;
using LocadoraWebApi.Servico.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraWebApi.Ioc.ExtensaoServicos
{
    public static class ExtensaoServicos
    {
        public static IServiceCollection RegistrarServicos(this IServiceCollection servicos)
        {
            servicos.AddScoped<IFilmeServico, FilmeServico>();
            servicos.AddScoped<ILocadorServico, LocadorServico>();

            return servicos;
        }
    }
}
