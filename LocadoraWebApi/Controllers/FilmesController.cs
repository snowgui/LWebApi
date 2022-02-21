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
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeServico _FilmeServico;
        
        public FilmesController(IFilmeServico filmeServico)
        {
            _FilmeServico = filmeServico;
        }

        /// <summary>
        /// Retorna Lista de Filmes ativos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Filme>> ListaFilmesAtivos()
        {
            return Ok(_FilmeServico.ListaFilmesAtivos());
        }

        /// <summary>
        /// Retorna Lista de todos os Filmes.
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public ActionResult<List<Filme>> ListaTodosFilmes()
        {
            return Ok(_FilmeServico.ListaTodosFilmes());
        }

        /// <summary>
        /// Retorna filme por id informado.
        /// </summary>
        /// <param name="id">id do Filme</param>
        /// <returns></returns>
        [HttpGet("id")]
        public ActionResult<Filme> ObterFilmePorId(Guid id)
        {
            return Ok(_FilmeServico.ObterFilmePorId(id));
        }

        /// <summary>
        /// Adicionado um novo filme, informar Nome e Genero.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost(Name = "SalvarFilme" )]
        public ActionResult SalvarFilme(FilmeDto obj)
        {
            _FilmeServico.SalvarFilme(obj);

            return Created(new Uri(Url.Link("SalvarFilme", null)), obj);            
        }

        /// <summary>
        /// Remove um filme por id informado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult DeletarFilme(Guid id)
        {
            _FilmeServico.DeletarFilme(id);
            return NoContent();
        }
    
    }
}
