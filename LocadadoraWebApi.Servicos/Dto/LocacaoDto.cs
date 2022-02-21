using System;

namespace LocadadoraWebApi.Servicos.Dto
{
    public class LocacaoDto
    {
        public string NomeFilme { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public LocacaoDto(string nomeFilme, string nomeCliente, DateTime dataLocacao, DateTime dataPrevistaDevolucao, DateTime? dataDevolucao)
        {
            NomeFilme = nomeFilme;
            NomeCliente = nomeCliente;
            DataLocacao = dataLocacao;
            DataPrevistaDevolucao = dataPrevistaDevolucao;
            DataDevolucao = dataDevolucao;
        }

        public LocacaoDto()
        {

        }
    }
}
