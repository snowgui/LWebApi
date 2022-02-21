using LocadoraWebApi.Entidades;
using LocadoraWebApi.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraWebApi.Repositorio.Repositorios
{
    public class LocacaoRepositorio : ILocacaoRepositorio
    {
        public void AlugarFilme(Locacao locacao)
        {
            MemoriaContexto.MemoriaLocacao.Add(locacao);
            MemoriaContexto.MemoriaFilmes.Where(x => x.Id == locacao.Filme.Id).FirstOrDefault().Disponivel = false;
        }

        public void DevolverFilme(Locacao locacao)
        {
            MemoriaContexto.MemoriaLocacao.Where(x => x.Id == locacao.Id).FirstOrDefault().DateDevolucao = DateTime.Now;
            MemoriaContexto.MemoriaFilmes.Where(x => x.Id == locacao.Filme.Id).FirstOrDefault().Disponivel = true;
        }
        public Locacao GetById(Guid id) => MemoriaContexto.MemoriaLocacao.FirstOrDefault(x => x.Id == id);

        public List<Locacao> ObterTodasLocacao() => MemoriaContexto.MemoriaLocacao;
        public List<Locacao> ObterTodasLocacaoPorCliente(Guid idCliente) => MemoriaContexto.MemoriaLocacao.Where(x => x.Locador.Id == idCliente).ToList();                           

        public List<Locacao> ObterTodasLocacaoPendentePorCliente(Guid idCliente)
        {
            return MemoriaContexto.MemoriaLocacao.Where(x => x.Locador.Id == idCliente && x.DateDevolucao == null).ToList();
        }
    }
}
