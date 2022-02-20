using System;

namespace LocadoraWebApi.Entidades
{
    public class Cliente
    {
        #region Atributes

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }

        #endregion

        public Cliente() { }
        public Cliente(string nome, string cpf, bool ativo)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Cpf = cpf;
            this.Ativo = ativo;
        }
       
    }

    
}
