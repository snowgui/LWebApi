using System;
using System.ComponentModel.DataAnnotations;

namespace LocadadoraWebApi.Servicos.Dto
{
    public class LocacaoInserirDto
    {                
        [Required]
        public Guid ClientId { get; set; }        
        
        [Required] 
        public Guid FilmeId { get; set; }        
    }
}
