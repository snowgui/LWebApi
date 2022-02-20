using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;
using LocadoraWebApi.Servico.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public ActionResult<List<Filme>> ListaFilmesAtivos()
        {
            return Ok(_FilmeServico.ListaFilmesAtivos());
        }

        [HttpGet("all")]
        public ActionResult<List<Filme>> ListaTodosFilmes()
        {
            return Ok(_FilmeServico.ListaTodosFilmes());
        }

        [HttpGet("id")]
        public ActionResult<Filme> ObterFilmePorId(Guid id)
        {
            return Ok(_FilmeServico.ObterFilmePorId(id));
        }

        [HttpPost(Name = "SalvarFilme" )]
        public ActionResult SalvarFilme(FilmeDto obj)
        {
            _FilmeServico.SalvarFilme(obj);

            return Created(new Uri(Url.Link("SalvarFilme", null)), obj);            
        }

        [HttpDelete]
        public ActionResult DeletarFilme(Guid id)
        {
            _FilmeServico.DeletarFilme(id);
            return NoContent();
        }
    
    }
}
