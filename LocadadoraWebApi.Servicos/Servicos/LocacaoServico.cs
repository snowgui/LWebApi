using LocadadoraWebApi.Servicos.Dto;
using LocadadoraWebApi.Servicos.Interfaces;
using LocadoraWebApi.Entidades;
using LocadoraWebApi.Repositorio.Interfaces;
using System;
using System.Collections.Generic;

namespace LocadadoraWebApi.Servicos
{
    public class LocacaoServico : ILocacaoServico
    {
        private readonly ILocacaoRepositorio _LocacaoRepositorio;
        private readonly IFilmeRepositorio _FilmeRepositorio;
        private readonly IClienteRepositorio _ClienteRepositorio;

        public LocacaoServico(ILocacaoRepositorio _locacaoRepositorio,
                IFilmeRepositorio _filmeRepositorio,
                IClienteRepositorio _clienteRepositorio)
        {
            this._LocacaoRepositorio = _locacaoRepositorio;
            this._FilmeRepositorio = _filmeRepositorio;
            this._ClienteRepositorio = _clienteRepositorio;

        }
        public LocacaoDto AlugarFilme(LocacaoInserirDto locacaoInserir)
        {
            var filme = _FilmeRepositorio.GetById(locacaoInserir.FilmeId);
            var cliente = _ClienteRepositorio.GetById(locacaoInserir.ClientId);
            var locacao = new Locacao();

            if (filme == null || cliente == null) throw new ArgumentException("Cliente ou Filme não encontrado, informe (ClientId, FilmeId) Válidos!");

            if(!cliente.Ativo) throw new ArgumentException("Cliente inativo!");
            if(!filme.Ativo) throw new ArgumentException("filme inativo!");

            if (filme.Disponivel)
            {
                locacao.Id = Guid.NewGuid();
                locacao.Filme = filme;
                locacao.Locador = cliente;
                locacao.DataLocacao = DateTime.Now;
                locacao.DataPrevistaDevolucao = DateTime.Now.AddDays(3);

                _LocacaoRepositorio.AlugarFilme(locacao);
            }
            else
            {
                throw new ArgumentException($"Filme {filme.Nome} não disponível!");
            }

            return new LocacaoDto(
                nomeFilme: filme.Nome,
                nomeCliente: cliente.Nome,
                dataLocacao: locacao.DataLocacao,
                dataPrevistaDevolucao: locacao.DataPrevistaDevolucao,
                dataDevolucao: null
            );
        }

        public LocacaoDevolverDto DevolverFilme(Guid id)
        {
            var locacao = _LocacaoRepositorio.GetById(id);

            if (locacao.DateDevolucao != null) throw new ArgumentException("Filme já foi devolvido!");

            _LocacaoRepositorio.DevolverFilme(locacao);

            var locacaoDevolver = new LocacaoDevolverDto();
                locacaoDevolver.Locacao = new LocacaoDto(
                nomeFilme: locacao.Filme.Nome,
                nomeCliente: locacao.Locador.Nome,
                dataLocacao: locacao.DataLocacao,
                dataPrevistaDevolucao: locacao.DataPrevistaDevolucao,
                dataDevolucao: locacao.DateDevolucao
          );

            if(locacao.DateDevolucao > locacao.DataPrevistaDevolucao)
            {
                locacaoDevolver.Msg = $"Devolução do filme: {locacao.Filme.Nome} está com atraso!";
            }
            else
            {
                locacaoDevolver.Msg = $"Devolução do filme: {locacao.Filme.Nome} concluída com sucesso!";
            }

            return locacaoDevolver;
        }

        public List<Locacao> ObterTodasLocacao() => _LocacaoRepositorio.ObterTodasLocacao();
    
        public List<Locacao> ObterTodasLocacaoPorCliente(Guid id) => _LocacaoRepositorio.ObterTodasLocacaoPorCliente(id);

        public List<Locacao> ObterTodasLocacaoPendentePorCliente(Guid id) => _LocacaoRepositorio.ObterTodasLocacaoPendentePorCliente(id); 

    }
}
