using System.ComponentModel.DataAnnotations;

namespace LocadadoraWebApi.Servicos.Dto
{
    public  class ClienteDto
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }
    }
}
