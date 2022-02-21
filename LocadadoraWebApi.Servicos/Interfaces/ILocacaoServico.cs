using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadadoraWebApi.Servicos.Interfaces
{
    public interface ILocacaoServico
    {
        LocacaoDto AlugarFilme(LocacaoInserirDto locacaoInserir);
        LocacaoDevolverDto DevolverFilme(Guid id);
        List<Locacao> ObterTodasLocacao();
        List<Locacao> ObterTodasLocacaoPorCliente(Guid id);
        List<Locacao> ObterTodasLocacaoPendentePorCliente(Guid id);

    }
}
