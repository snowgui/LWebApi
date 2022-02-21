using FluentAssertions;
using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Controllers;
using LocadoraWebApi.Entidades;
using LocadoraWebApi.Repositorio;
using LocadoraWebApi.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net;
using Xunit;

namespace LocadoraWebApi.Testes
{
    public class ApiFilmeTest
    {
        private readonly Mock<IFilmeServico> _FilmeServicoMock;
        private readonly FilmesController _Controller;

        public ApiFilmeTest()
        {
            _FilmeServicoMock = new Mock<IFilmeServico>();
            _Controller = new FilmesController(_FilmeServicoMock.Object);
        }

        [Fact]
        public void ListaTodosFilmes_ReturnsExpectedStatusCode()
        {
            var actionResult = _Controller.ListaTodosFilmes().Result;

            actionResult.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public void ListaFilmesAtivos_ReturnsExpectedStatusCode()
        {
            var actionResult = _Controller.ListaFilmesAtivos().Result;

            actionResult.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public void SalvarFilme_VerifyServiceWasCalled()
        {
            _ = _Controller.SalvarFilme(It.IsAny<FilmeDto>());

            _FilmeServicoMock.Verify(t => t.SalvarFilme(It.IsAny<FilmeDto>()), Times.Once, "SalvarFilme não foi chamado!");
        }

        [Fact]
        public void DeletarFilme_ReturnsExpectedStatusCode()
        {           
            var actionResult = _Controller.DeletarFilme(MemoriaContexto.MemoriaFilmes[0].Id);

            actionResult.Should().BeOfType<NoContentResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
        }

        //TODO: Implementar testes p/ métodos ObterFilmePorId, SalvarFilme

    }
}

