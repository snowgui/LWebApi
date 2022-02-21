using System;

namespace LocadadoraWebApi.Servicos.Dto
{
    public class LocacaoInserirDto
    {                
        public Guid ClientId { get; set; }        
        public Guid FilmeId { get; set; }        
    }
}
