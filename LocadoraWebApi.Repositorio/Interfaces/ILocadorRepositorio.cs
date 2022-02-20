using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Repositorio.Interfaces
{
    public interface ILocadorRepositorio
    {
        List<Locador> GetAll();
        Locador GetById(Guid id);
        Locador Add(Locador obj);
        Locador GetByCpf(String Nome);
        void Delete(Guid id);        
    }
}
