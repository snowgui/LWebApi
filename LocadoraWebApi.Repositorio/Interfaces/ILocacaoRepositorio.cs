using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Repositorio.Interfaces
{
    public interface ILocacaoRepositorio
    {
        void AlugarFilme(Locacao locacao);
        void DevolverFilme(Locacao locacao);
        Locacao GetById(Guid id);
        List<Locacao> ObterTodasLocacao();
    }
}
