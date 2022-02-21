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
        private readonly IClienteServico _LocadorClienteServico;

        public ClienteController(IClienteServico _locadorServico)
        {
            _LocadorClienteServico = _locadorServico;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> ListaLocadorAtivos()
        {
            return _LocadorClienteServico.ListaClienteAtivos();
        }

        [HttpGet("all")]
        public ActionResult<List<Cliente>> ListaTodosLocador()
        {
            return _LocadorClienteServico.ListaTodosClientes();
        }

        [HttpPost(Name = "SalvarLocador")]
        public ActionResult SalvarLocador(ClienteDto obj)
        {
            try
            {
                _LocadorClienteServico.SalvarCliente(obj);

                return Created(new Uri(Url.Link("SalvarLocador", null)), obj);

            }
            catch (ArgumentException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpDelete]
        public ActionResult DeletarLocador(Guid id)
        {
            _LocadorClienteServico.DeletarCliente(id);
            return NoContent();
        }

        [HttpGet("cpf/{cpf}")]
        public ActionResult<Cliente> ObterLocadorPorId(String cpf) => Ok(_LocadorClienteServico.GetByCpf(cpf));
                            
     }
}
