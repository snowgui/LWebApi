using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraWebApi.Repositorio.Repositorios
{
    public class ClienteRepositorio : Interfaces.IClienteRepositorio
    {
        public Cliente Add(Cliente obj)
        {
            MemoriaContexto.MemoriaClientes.Add(obj);
            return obj;
        }

        public List<Cliente> GetAll()
        {
            return MemoriaContexto.MemoriaClientes;
        }

        public Cliente GetById(Guid id)
        {
            return MemoriaContexto.MemoriaClientes.FirstOrDefault(x => x.Id == id);
        }

        public Cliente GetByCpf(string cpf)
        {
            return MemoriaContexto.MemoriaClientes.FirstOrDefault(x => x.Cpf.Equals(cpf, StringComparison.OrdinalIgnoreCase));
        }

        public void Delete(Guid id)
        {
            MemoriaContexto.MemoriaClientes.Where(x => x.Id == id).FirstOrDefault().Ativo = false;
        }

    }
}
