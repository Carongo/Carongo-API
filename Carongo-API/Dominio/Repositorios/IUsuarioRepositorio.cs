using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> Listar(string nome = null);
        Usuario Buscar(Guid id);
        Usuario Buscar(string email);
        Usuario Cadastrar(Usuario usuario);
        Usuario Alterar(Usuario usuario);
        void Deletar(Guid id);
    }
}