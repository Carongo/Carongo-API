using Dominio.Entidades;
using Dominio.Repositorios;
using Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private CarongoContexto Context { get; set; }

        public AlunoRepositorio(CarongoContexto context)
        {
            Context = context;
        }

        public Aluno Adicionar(Aluno aluno)
        {
            Context.Alunos.Add(aluno);
            Context.SaveChanges();
            return aluno;
        }

        public Aluno Alterar(Aluno aluno)
        {
            Context.Entry(aluno).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return aluno;
        }

        public Aluno BuscarPorNome(string nome)
        {
            return Context.Alunos.AsNoTracking().FirstOrDefault(p => p.Nome == nome);
        }

        public Aluno BuscarPorId(Guid id)
        {
            return Context.Alunos.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public void Deletar(Guid id)
        {
            var aluno = BuscarPorId(id);
            Context.Alunos.Remove(aluno);
            Context.SaveChanges();
        }

        public ICollection<Aluno> Listar()
        {
            return Context.Alunos.AsNoTracking().OrderBy(x => x.Nome).ToList();
        }
    }
}
