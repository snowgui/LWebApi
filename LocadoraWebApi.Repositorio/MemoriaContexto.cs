using LocadoraWebApi.Entidades;
using System;
using System.Collections.Generic;

namespace LocadoraWebApi.Repositorio
{
    public static class MemoriaContexto
    {
        public static List<Filme> MemoriaFilmes = MemoriaContexto.SeedMemoriaFilmes();

        public static List<Cliente> MemoriaClientes = MemoriaContexto.SeedMemoriaClientes();

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

            lst.Add(f1);
            lst.Add(f2);
            lst.Add(f3);
            lst.Add(f4);

            return lst;
        }

        private static List<Cliente> SeedMemoriaClientes()
        {
            var lst = new List<Cliente>();

            var l1 = new Cliente(
                nome: "Maria",
                cpf: "98072941003",
                ativo: true
             );

            var l2 = new Cliente(
                nome: "João",
                cpf: "34969138001",
                ativo: true
            );

            var l3 = new Cliente(
                nome: "Pedro",
                cpf: "11191769054",
                ativo: false
            );

            lst.Add(l1);
            lst.Add(l2);
            lst.Add(l3);

            return lst;

        }
    }
}
