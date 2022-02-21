using AutoMapper;
using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;
using LocadoraWebApi.Repositorio.Interfaces;
using LocadoraWebApi.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadadoraWebApi.Servicos
{
    public class ClienteServico : IClienteServico
    {

        private readonly IClienteRepositorio _RepositorioCliente;
        private readonly IMapper _mapper;

        public ClienteServico(IClienteRepositorio _repositorio, IMapper mapper)
        {
            this._RepositorioCliente = _repositorio;
            this._mapper = mapper;
        }
        public List<Cliente> ListaClienteAtivos()
        {
            var lst = _RepositorioCliente.GetAll();
            return lst.Where(x => x.Ativo == true).ToList();
        }

        public List<Cliente> ListaTodosClientes()
        {
            return _RepositorioCliente.GetAll();
        }
        
        public void SalvarCliente(ClienteDto obj)
        {
            var cliente = _RepositorioCliente.GetByCpf(obj.Cpf);

            if(cliente == null)
            {
                cliente = _mapper.Map<Cliente>(obj);
                cliente.Id = Guid.NewGuid();
                cliente.Ativo = true;

                _RepositorioCliente.Add(cliente);
            }
            else
            {
                throw new ArgumentException($"Erro para cadastrar cliente, CPF: {obj.Cpf} já está sendo utilizado!");
            }
            
        }
        public void DeletarCliente(Guid id)
        {
            _RepositorioCliente.Delete(id);
        }

        public Cliente GetByCpf(string cpf)
        {
            return _RepositorioCliente.GetByCpf(cpf);
        }
    }
}
