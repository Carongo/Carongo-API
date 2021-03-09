using Dominio.Entidades;
using Dominio.Repositorios;
using Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositorios
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private CarongoContexto Contexto { get; set; }

        public TurmaRepositorio(CarongoContexto contexto)
        {
            Contexto = contexto;
        }

        public Turma Buscar(Guid id)
        {
            return Contexto
                .Turmas
                .FirstOrDefault(t => t.Id == id);
        }

        public Turma Adicionar(Turma turma)
        {
            Contexto
                .Turmas
                .Add(turma);
            Contexto
                .SaveChanges();
            return turma;
        }

        public Turma Alterar(Turma turma)
        {
            Contexto
                .Entry(turma)
                .State = EntityState.Modified;
            Contexto
                .SaveChanges();
            return turma;
        }

        public void Deletar(Guid id)
        {
            var turma = Buscar(id);
            Contexto
                .Turmas
                .Remove(turma);
            Contexto
                .SaveChanges();
        }
    }
}