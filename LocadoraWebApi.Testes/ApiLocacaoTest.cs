using FluentAssertions;
using LocadadoraWebApi.Servicos.Interfaces;
using LocadoraWebApi.Controllers;
using LocadoraWebApi.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;

namespace LocadoraWebApi.Testes
{
    public class ApiLocacaoTest
    {
        private readonly Mock<ILocacaoServico> _ServicoMock;
        private readonly LocacaoController _Controller;

        public ApiLocacaoTest()
        {
            _ServicoMock = new Mock<ILocacaoServico>();
            _Controller = new LocacaoController(_ServicoMock.Object);
        }

        [Fact]
        public void ObterTodasLocacao_ReturnsExpectedStatusCode()
        {
            var actionResult = _Controller.ObterTodasLocacao().Result;

            actionResult.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public void ObterTodasLocacaoPorCliente_ReturnsExpectedStatusCode()
        {
            var actionResult = _Controller.ObterTodasLocacaoPorCliente(MemoriaContexto.MemoriaClientes[1].Id).Result;

            actionResult.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        //TODO: Implementar testes p/ métodos AlugarFilme, DevolverFilme, ObterTodasLocacaoPendentePorCliente

    }
}

