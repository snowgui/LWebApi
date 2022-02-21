using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Repositorio.Interfaces
{
    public interface IFilmeRepositorio
    {
        List<Filme> GetAll();
        Filme GetById(Guid id);
        Filme Add(Filme obj);
        Filme Update(Filme obj);
        void Delete(Guid id);
        Filme GetByName(string nome);        
    }
}
