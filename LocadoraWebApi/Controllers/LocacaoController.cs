using LocadadoraWebApi.Servicos.Dto;
using LocadadoraWebApi.Servicos.Interfaces;
using LocadoraWebApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoServico _LocacaoServico;

        public LocacaoController(ILocacaoServico _locacaoServico)
        {
            this._LocacaoServico = _locacaoServico;
        }

        [HttpGet]
        public ActionResult<List<Locacao>> ObterTodasLocacao()
        {
            return Ok(_LocacaoServico.ObterTodasLocacao());
        }

        [HttpPost(Name = "AlugarFilme")]
        public ActionResult<LocacaoDto> AlugarFilme(LocacaoInserirDto locacaoInserir)
        {
            if (locacaoInserir == null) return BadRequest();
            
            try
            {
                var obj = _LocacaoServico.AlugarFilme(locacaoInserir);
                return Created(new Uri(Url.Link("AlugarFilme", null)), obj);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Devolver/Filme/{id}")]
        public ActionResult<LocacaoDevolverDto> DevolverFilme(Guid id)
        {
            try
            {
                return Ok(_LocacaoServico.DevolverFilme(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("cliente/{id}")]
        public ActionResult<List<Locacao>> ObterTodasLocacaoPorCliente(Guid id) => _LocacaoServico.ObterTodasLocacaoPorCliente(id);                            


        [HttpGet("pendente/cliente/{id}")]
        public ActionResult<List<Locacao>> ObterTodasLocacaoPendentePorCliente(Guid id) => _LocacaoServico.ObterTodasLocacaoPendentePorCliente(id);

    }
}
