using LocadadoraWebApi.Servicos;
using LocadadoraWebApi.Servicos.Interfaces;
using LocadoraWebApi.Servico.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraWebApi.Ioc.ExtensaoServicos
{
    public static class ExtensaoServicos
    {
        public static IServiceCollection RegistrarServicos(this IServiceCollection servicos)
        {
            servicos.AddScoped<IFilmeServico, FilmeServico>();
            servicos.AddScoped<IClienteServico, ClienteServico>();
            servicos.AddScoped<ILocacaoServico, LocacaoServico>();          

            return servicos;
        }
    }
}
