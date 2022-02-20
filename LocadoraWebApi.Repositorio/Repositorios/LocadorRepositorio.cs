using LocadoraWebApi.Entidades;
using LocadoraWebApi.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraWebApi.Repositorio.Repositorios
{
    public class LocadorRepositorio : ILocadorRepositorio
    {
        public Locador Add(Locador obj)
        {
            MemoriaContexto.MemoriaLocador.Add(obj);
            return obj;
        }

        public List<Locador> GetAll()
        {
            return MemoriaContexto.MemoriaLocador;
        }

        public Locador GetById(Guid id)
        {
            return MemoriaContexto.MemoriaLocador.FirstOrDefault(x => x.Id == id);
        }

        public Locador GetByCpf(string cpf)
        {
            return MemoriaContexto.MemoriaLocador.FirstOrDefault(x => x.Cpf.Equals(cpf, StringComparison.OrdinalIgnoreCase));
        }

        public void Delete(Guid id)
        {
            MemoriaContexto.MemoriaLocador.Where(x => x.Id == id).FirstOrDefault().Ativo = false;
        }

    }
}
