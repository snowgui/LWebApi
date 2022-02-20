using LocadoraWebApi.Entidades;
using System.Collections.Generic;

namespace LocadoraWebApi.Repositorio
{
    public static class MemoriaContexto
    {
        public static List<Filme> MemoriaFilmes = MemoriaContexto.SeedMemoriaFilmes();
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
    }
}
