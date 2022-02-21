using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Repositorio
{
    public static class MemoriaContexto
    {
        public static List<Filme> MemoriaFilmes = MemoriaContexto.SeedMemoriaFilmes();

        public static List<Cliente> MemoriaClientes = MemoriaContexto.SeedMemoriaClientes();

        public static List<Locacao> MemoriaLocacao = MemoriaContexto.SeedMemoriaLocacao();

        private static List<Locacao> SeedMemoriaLocacao()
        {
            var lst = new List<Locacao>();

            MemoriaContexto.MemoriaFilmes[0].Disponivel = false;

            var l1 = new Locacao();
            l1.Id = Guid.NewGuid();
            l1.Filme = MemoriaContexto.MemoriaFilmes[0];
            l1.Locador = MemoriaContexto.MemoriaClientes[0];
            l1.DataLocacao = DateTime.Now;
            l1.DataPrevistaDevolucao = DateTime.Now.AddDays(1000);

            lst.Add(l1);

            MemoriaContexto.MemoriaFilmes[1].Disponivel = false;

            var l2 = new Locacao();
            l2.Id = Guid.NewGuid();
            l2.Filme = MemoriaContexto.MemoriaFilmes[1];
            l2.Locador = MemoriaContexto.MemoriaClientes[0];
            l2.DataLocacao = Convert.ToDateTime("2022-01-20");
            l2.DataPrevistaDevolucao = Convert.ToDateTime("2022-01-23");

            lst.Add(l2);

            return lst;
        }

        private static List<Filme> SeedMemoriaFilmes()
        {
            var lst = new List<Filme>();

            var f1 = new Filme(
                nome: "As Aventuras de Pollyana!",
                genero: "Aventura",
                ativo: true
            );

            var f2 = new Filme(
               nome: "Tropas Liberadas",
               genero: "Ação",
               ativo: true
           );

            var f3 = new Filme(
                 nome: "James e o Pêssego Gigante",
                 genero: "Aventura",
                 ativo: true
             );

            // Filme Inativo.
            var f4 = new Filme(
                nome: "Tropa de Elite",
                genero: "Policial",
                ativo: false
            );

            var f5 = new Filme(
                nome: "It: A Coisa",
                genero: "Terror",
                ativo: true
            );

            var f6 = new Filme(
                nome: "A Terra Mágica do.NET",
                genero: "Documentário",
                ativo: true
            );

            lst.Add(f1);
            lst.Add(f2);
            lst.Add(f3);
            lst.Add(f4);
            lst.Add(f5);
            lst.Add(f6);

            return lst;
        }

        private static List<Cliente> SeedMemoriaClientes()
        {
            var lst = new List<Cliente>();

            var c1 = new Cliente(
                nome: "Maria",
                cpf: "98072941003",
                ativo: true
             );

            var c2 = new Cliente(
                nome: "João",
                cpf: "34969138001",
                ativo: true
            );

            var c3 = new Cliente(
                nome: "Pedro",
                cpf: "11191769054",
                ativo: false
            );

            lst.Add(c1);
            lst.Add(c2);
            lst.Add(c3);

            return lst;

        }
    }
}
