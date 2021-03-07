using Dominio.Entidades;
using Dominio.Repositorios;
using Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private CarongoContexto Contexto { get; set; }

        public UsuarioRepositorio(CarongoContexto contexto)
        {
            Contexto = contexto;
        }

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
            return Contexto
                .Usuarios
                .FirstOrDefault(u => u.Email == email);
        }

        public Usuario Adicionar(Usuario usuario)
        {
            Contexto.Usuarios.Add(usuario);
            Contexto.SaveChanges();
            return usuario;
        }

        public Usuario Alterar(Usuario usuario)
        {
            Contexto.Entry(usuario).State = EntityState.Modified;
            Contexto.SaveChanges();
            return usuario;
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}