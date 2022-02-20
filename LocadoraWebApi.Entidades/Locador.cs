using System;

namespace LocadoraWebApi.Entidades
{
    public class Locador
    {
        #region Atributes

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }

        #endregion

        public Locador() { }
        public Locador(string nome, string cpf, bool ativo)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Cpf = cpf;
            this.Ativo = ativo;
        }
       
    }

    
}
