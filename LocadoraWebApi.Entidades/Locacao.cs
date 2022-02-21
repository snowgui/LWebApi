using System;

namespace LocadoraWebApi.Entidades
{
    public class Locacao
    {
        // LocadorId = Cliente
        public Guid Id { get; set; }
        public Cliente Locador { get; set; }
        public Filme Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public DateTime? DateDevolucao { get; set; }

    }
}
