using LocadoraWebApi.Entidades;
using LocadoraWebApi.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraWebApi.Repositorio.Repositorios
{
    public class FilmeRepositorio : IFilmeRepositorio
    {
        public Filme Add(Filme obj)
        {
            MemoriaContexto.MemoriaFilmes.Add(obj);
            return obj;
        }

        public void Delete(Guid id)
        {
            MemoriaContexto.MemoriaFilmes.Where(x => x.Id == id).FirstOrDefault().Ativo = false;
        }

        public List<Filme> GetAll()
        {
            return MemoriaContexto.MemoriaFilmes;
        }

        public Filme GetById(Guid id)
        {
            return MemoriaContexto.MemoriaFilmes.Where(x => x.Id == id).FirstOrDefault();
        }

        public Filme GetByName(string nome)
        {
            return MemoriaContexto.MemoriaFilmes.Where(x => x.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }       
        public Filme Update(Filme obj)
        {
            // Implementar atualizar filme
            throw new NotImplementedException();
        }
    }
}
