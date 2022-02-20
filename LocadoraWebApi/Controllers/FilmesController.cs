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

        [HttpPost]
        public ActionResult<FilmeDto> SalvarFilme(FilmeDto obj)
        {
            _FilmeServico.SalvarFilme(obj);

            return Ok(obj);
        }

        [HttpGet]
        public ActionResult<List<Filme>> ObterTodosFilmesAtivos()
        {
            return Ok(_FilmeServico.ListaFilmesAtivos());
        }

        [HttpGet("all")]
        public ActionResult<List<Filme>> ObterTodosFilmes()
        {
            return Ok(_FilmeServico.ListaTodosFilmes());
        }
    }
}
