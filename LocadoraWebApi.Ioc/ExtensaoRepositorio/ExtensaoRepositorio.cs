using LocadoraWebApi.Repositorio.Interfaces;
using LocadoraWebApi.Repositorio.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWebApi.Ioc.ExtensaoRepositorio
{
    public static class ExtensaoRepositorio
    {
        public static IServiceCollection RegistrarRepositorios(this IServiceCollection servicos)
        {
            servicos.AddScoped<IFilmeRepositorio, FilmeRepositorio>();
            servicos.AddScoped<ILocadorRepositorio, LocadorRepositorio>();
            return servicos;
        }
    }
}
