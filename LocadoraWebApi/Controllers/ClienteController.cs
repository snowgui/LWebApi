using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;
using LocadoraWebApi.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServico _LocadorCliente;

        public ClienteController(IClienteServico locadorServico)
        {
            _LocadorCliente = locadorServico;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> ListaLocadorAtivos()
        {
            return _LocadorCliente.ListaClienteAtivos();
        }

        [HttpGet("all")]
        public ActionResult<List<Cliente>> ListaTodosLocador()
        {
            return _LocadorCliente.ListaTodosClientes();
        }

        [HttpPost(Name = "SalvarLocador")]
        public ActionResult SalvarLocador(ClienteDto obj)
        {
            _LocadorCliente.SalvarCliente(obj);

            return Created(new Uri(Url.Link("SalvarLocador", null)), obj);
        }

        [HttpDelete]
        public ActionResult DeletarLocador(Guid id)
        {
            _LocadorCliente.DeletarCliente(id);
            return NoContent();
        }
    }
}
