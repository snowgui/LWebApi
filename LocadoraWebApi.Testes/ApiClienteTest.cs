using FluentAssertions;
using LocadoraWebApi.Controllers;
using LocadoraWebApi.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;

namespace LocadoraWebApi.Testes
{
    public class ApiClienteTest
    {
        private readonly Mock<IClienteServico> _ServicoMock;
        private readonly ClientesController _Controller;

        public ApiClienteTest()
        {
            _ServicoMock = new Mock<IClienteServico>();
            _Controller = new ClientesController(_ServicoMock.Object);
        }

        [Fact]
        public void ListaTodosLocador_ReturnsExpectedStatusCode()
        {
            var actionResult = _Controller.ListaTodosLocador().Result;

            actionResult.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public void ListaLocadorAtivos_ReturnsExpectedStatusCode()
        {
            var actionResult = _Controller.ListaLocadorAtivos().Result;

            actionResult.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        //TODO: Implementar testes p/ métodos SalvarCliente, DeletarLocador, ObterLocadorPorId.


    }
}

