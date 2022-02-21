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
            var obj = _LocacaoServico.AlugarFilme(locacaoInserir);
            return Created(new Uri(Url.Link("AlugarFilme", null)), obj);
        }

        [HttpPost("id")]
        public ActionResult<LocacaoDto> DevolverFilme(Guid id)
        {

            try
            {
                return Ok(_LocacaoServico.DevolverFilme(id));
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

    }
}
