using Dominio.Entidades;
using Dominio.Repositorios;
using Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infra.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private CarongoContexto Contexto { get; set; }

        public AlunoRepositorio(CarongoContexto contexto)
        {
            Contexto = contexto;
        }

        public Aluno Buscar(Guid id)
        {
            return Contexto.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public Aluno Adicionar(Aluno aluno)
        {
            Contexto.Alunos.Add(aluno);
            Contexto.SaveChanges();
            return aluno;
        }

        public Aluno Alterar(Aluno aluno)
        {
            Contexto.Entry(aluno).State = EntityState.Modified;
            Contexto.SaveChanges();
            return aluno;
        }

        public void Deletar(Guid id)
        {
            var aluno = Buscar(id);
            Contexto.Alunos.Remove(aluno);
            Contexto.SaveChanges();
        }
    }
}