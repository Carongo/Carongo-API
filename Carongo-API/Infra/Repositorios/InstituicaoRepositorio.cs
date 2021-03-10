using Dominio.Entidades;
using Dominio.Repositorios;
using Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositorios
{
    public class InstituicaoRepositorio : IInstituicaoRepositorio
    {
        private CarongoContexto Contexto { get; set; }

        public InstituicaoRepositorio(CarongoContexto contexto)
        {
            Contexto = contexto;
        }

        public Instituicao Buscar(Guid id)
        {
            return Contexto
                .Instituicoes
                .Include(i => i.UsuariosInstituicoes)
                .Include(i => i.Turmas)
                .FirstOrDefault(i => i.Id == id);
        }

        public Instituicao Buscar(string codigo)
        {
            return Contexto
                .Instituicoes
                .Include(i => i.UsuariosInstituicoes)
                .Include(i => i.Turmas)
                .FirstOrDefault(i => i.Codigo == codigo);
        }

        public Instituicao Adicionar(Instituicao instituicao)
        {
            Contexto
                .Instituicoes
                .Add(instituicao);
            Contexto
                .SaveChanges();
            return instituicao;
        }

        public Instituicao Alterar(Instituicao instituicao)
        {
            Contexto
                .Entry(instituicao)
                .State = EntityState.Modified;
            Contexto
                .SaveChanges();
            return instituicao;
        }

        public void Deletar(Guid id)
        {
            var instituicao = Buscar(id);
            Contexto
                .Instituicoes
                .Remove(instituicao);
            Contexto
                .SaveChanges();
        }

        public void AdicionarUsuario(UsuarioInstituicao usuarioInstituicao)
        {
            Contexto
                .UsuariosInstituicoes
                .Add(usuarioInstituicao);
            Contexto
                .SaveChanges();
        }

        public void AlterarUsuario(UsuarioInstituicao usuarioInstituicao)
        {
            Contexto
                .Entry(usuarioInstituicao)
                .State = EntityState.Modified;
            Contexto
                .SaveChanges();
        }

        public void DeletarUsuario(Guid id)
        {
            var usuarioInstituicao = Contexto.UsuariosInstituicoes.Find(id);
            Contexto
                .UsuariosInstituicoes
                .Remove(usuarioInstituicao);
            Contexto
                .SaveChanges();
        }
    }
}