using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Repositorios
{
    public interface IInstituicaoRepositorio
    {
        List<Instituicao> Listar(string nome = null);
        Instituicao Buscar(Guid id);
        Instituicao Buscar(string codigo);
        Instituicao Adicionar(Instituicao instituicao);
        Instituicao Alterar(Instituicao instituicao);
        void Deletar(Guid id);
        void AdicionarUsuario(UsuarioInstituicao usuarioInstituicao);
        void AlterarUsuario(UsuarioInstituicao usuarioInstituicao);
        void DeletarUsuario(Guid id);
    }
}