using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Servico.Interfaces
{
    public interface IClienteServico
    {
        void SalvarCliente(ClienteDto obj);               
        List<Cliente> ListaClienteAtivos();
        List<Cliente> ListaTodosClientes();
        void DeletarCliente(Guid id);
    }
}
