using LocadoraWebApi.Repositorio.Interfaces;
using LocadoraWebApi.Repositorio.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraWebApi.Ioc.ExtensaoRepositorio
{
    public static class ExtensaoRepositorio
    {
        public static IServiceCollection RegistrarRepositorios(this IServiceCollection servicos)
        {
            servicos.AddScoped<IFilmeRepositorio, FilmeRepositorio>();
            servicos.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            return servicos;
        }
    }
}
