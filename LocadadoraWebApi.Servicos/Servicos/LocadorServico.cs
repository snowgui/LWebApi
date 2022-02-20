using AutoMapper;
using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;
using LocadoraWebApi.Repositorio.Interfaces;
using LocadoraWebApi.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadadoraWebApi.Servicos.Servicos
{
    public class LocadorServico : ILocadorServico
    {

        private readonly ILocadorRepositorio _RepositorioLocador;
        private readonly IMapper _mapper;

        public LocadorServico(ILocadorRepositorio _repositorio, IMapper mapper)
        {
            this._RepositorioLocador = _repositorio;
            this._mapper = mapper;
        }
        public List<Locador> ListaLocadorAtivos()
        {
            var lst = _RepositorioLocador.GetAll();
            return lst.Where(x => x.Ativo == true).ToList();
        }

        public List<Locador> ListaTodosLocador()
        {
            return _RepositorioLocador.GetAll();
        }

        public void SalvarLocador(LocadorDto obj)
        {
            var locador = _RepositorioLocador.GetByCpf(obj.Nome);

            if(locador == null)
            {
                locador = _mapper.Map<Locador>(obj);
                locador.Id = Guid.NewGuid();
                locador.Ativo = true;
                
                _RepositorioLocador.Add(locador);
            }
            else
            {
                throw new ArgumentException("Já existe um Locador com esse Cpf");
            }
            
        }
        public void DeletarLocador(Guid id)
        {
            _RepositorioLocador.Delete(id);
        }

    }
}
