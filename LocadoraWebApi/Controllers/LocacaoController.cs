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

        /// <summary>
        /// Retorna lista com todas as locações de filmes.
        /// </summary>
        /// <returns>Lista das loções de Filmes</returns>
        [HttpGet]
        public ActionResult<List<Locacao>> ObterTodasLocacao()
        {
            return Ok(_LocacaoServico.ObterTodasLocacao());
        }

        /// <summary>
        /// Cria uma locação de Filme
        /// </summary>
        /// <param name="locacaoInserir">Objeto Request para realizar uma locação de filme, informar no corpo da requisição = ClientId e FilmeId</param>
        /// <returns></returns>
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

        /// <summary>
        /// Deolver um Filme
        /// </summary>
        /// <param name="id">id da locação</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna todas as locações de determinado locador(cliente).
        /// </summary>
        /// <param name="id">id do locador (cliente). </param>
        /// <returns></returns>
        [HttpGet("cliente/{id}")]
        public ActionResult<List<Locacao>> ObterTodasLocacaoPorCliente(Guid id) => _LocacaoServico.ObterTodasLocacaoPorCliente(id);

        /// <summary>
        /// Retorna todas as locações pendentes de determinado locador(cliente).
        /// </summary>
        /// <param name="id">id do locador (cliente). </param>
        /// <returns></returns>
        [HttpGet("pendente/cliente/{id}")]
        public ActionResult<List<Locacao>> ObterTodasLocacaoPendentePorCliente(Guid id) => _LocacaoServico.ObterTodasLocacaoPendentePorCliente(id);

    }
}
