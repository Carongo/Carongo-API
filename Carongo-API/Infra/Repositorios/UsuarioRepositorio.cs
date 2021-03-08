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
            return Contexto
                .Usuarios
                .Include(i => i.UsuariosInstituicoes)
                .FirstOrDefault(i => i.Id == id);
        }

        public Usuario Buscar(string email)
        {
            return Contexto
                .Usuarios
                .Include(i => i.UsuariosInstituicoes)
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
            var usuario = Buscar(id);
            Contexto.Usuarios.Remove(usuario);
            Contexto.SaveChanges();
        }
    }
}