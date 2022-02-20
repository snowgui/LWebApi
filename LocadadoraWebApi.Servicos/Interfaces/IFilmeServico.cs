using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Servico.Interfaces
{
    public interface IFilmeServico
    {
        void SalvarFilme(FilmeDto obj);
        void AtualizarFilme(FilmeDto obj, Guid id);
        List<Filme> ListaFilmesAtivos();
        List<Filme> ListaTodosFilmes();

    }
}
