using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Repositorios
{
    public interface ITurmaRepositorio
    {
        Turma Buscar(Guid id);
        Turma Adicionar(Turma turma);
        Turma Alterar(Turma turma);
        void Deletar(Guid id);
    }
}