using System.ComponentModel.DataAnnotations;

namespace LocadadoraWebApi.Servicos.Dto
{
    public class FilmeDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Genero { get; set; }
    }
}
