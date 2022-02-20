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
    public class LocadorController : ControllerBase
    {
        private readonly ILocadorServico _LocadorServico;

        public LocadorController(ILocadorServico locadorServico)
        {
            _LocadorServico = locadorServico;
        }

        [HttpGet]
        public ActionResult<List<Locador>> ListaLocadorAtivos()
        {
            return _LocadorServico.ListaLocadorAtivos();
        }

        [HttpGet("all")]
        public ActionResult<List<Locador>> ListaTodosLocador()
        {
            return _LocadorServico.ListaTodosLocador();
        }

        [HttpPost(Name = "SalvarLocador")]
        public ActionResult SalvarLocador(LocadorDto obj)
        {
            _LocadorServico.SalvarLocador(obj);

            return Created(new Uri(Url.Link("SalvarLocador", null)), obj);
        }

        [HttpDelete]
        public ActionResult DeletarLocador(Guid id)
        {
            _LocadorServico.DeletarLocador(id);
            return NoContent();
        }
    }
}
