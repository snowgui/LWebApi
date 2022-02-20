using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Servico.Interfaces
{
    public interface ILocadorServico
    {
        void SalvarLocador(LocadorDto obj);               
        List<Locador> ListaLocadorAtivos();
        List<Locador> ListaTodosLocador();
        void DeletarLocador(Guid id);
    }
}
