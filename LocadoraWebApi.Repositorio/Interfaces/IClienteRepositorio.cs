using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Repositorio.Interfaces
{
    public interface IClienteRepositorio
    {
        List<Cliente> GetAll();
        Cliente GetById(Guid id);
        Cliente Add(Cliente obj);
        Cliente GetByCpf(String Nome);
        void Delete(Guid id);        
    }
}
