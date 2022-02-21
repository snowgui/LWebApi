using AutoMapper;
using LocadadoraWebApi.Servicos.Dto;
using LocadoraWebApi.Entidades;
using LocadoraWebApi.Repositorio.Interfaces;
using LocadoraWebApi.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadadoraWebApi.Servicos
{
    public class FilmeServico : IFilmeServico
    {
        private readonly IFilmeRepositorio _FilmeRepositorio;
        private readonly IMapper _Mapper;
        public FilmeServico(IFilmeRepositorio _filmeRepositorio, IMapper mapper)
        {
            this._FilmeRepositorio = _filmeRepositorio;
            this._Mapper = mapper;
        }
        
        public List<Filme> ListaFilmesAtivos()
        {
            var lst = _FilmeRepositorio.GetAll();
            return lst.Where(x => x.Ativo == true).ToList();
        }

        public List<Filme> ListaTodosFilmes()
        {
            return _FilmeRepositorio.GetAll();
        }

        public void SalvarFilme(FilmeDto obj)
        {
            var filme = _Mapper.Map<Filme>(obj);
            filme.Ativo = true;
            filme.Disponivel = true;
            filme.Id = Guid.NewGuid();

            _FilmeRepositorio.Add(filme);
        }

        public Filme ObterFilmePorId(Guid id)
        {
            return _FilmeRepositorio.GetById(id);
        }

        public void DeletarFilme(Guid id)
        {
            _FilmeRepositorio.Delete(id);
        } 

        public void AtualizarFilme(FilmeDto obj, Guid id)
        {
            throw new NotImplementedException();
        }
       
    }
}
