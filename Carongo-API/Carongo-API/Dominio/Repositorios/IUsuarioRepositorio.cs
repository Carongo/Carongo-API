using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario Buscar(Guid id);
        Usuario Buscar(string email);
        Usuario Adicionar(Usuario usuario);
        Usuario Alterar(Usuario usuario);
        void Deletar(Guid id);
    }
}