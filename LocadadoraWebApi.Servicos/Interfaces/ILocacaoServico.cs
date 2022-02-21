using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadadoraWebApi.Servicos.Interfaces
{
    public interface ILocacaoServico
    {
        LocacaoDto AlugarFilme(LocacaoInserirDto locacaoInserir);
        LocacaoDto DevolverFilme(Guid id);
        List<Locacao> ObterTodasLocacao();
    }
}
