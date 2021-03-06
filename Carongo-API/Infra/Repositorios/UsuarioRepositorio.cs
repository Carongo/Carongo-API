using Dominio.Entidades;
using Dominio.Repositorios;
using System;
using System.Collections.Generic;

namespace Infra.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public List<Usuario> Listar(string nome = null)
        {
            throw new NotImplementedException();
        }

        public Usuario Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario Buscar(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}