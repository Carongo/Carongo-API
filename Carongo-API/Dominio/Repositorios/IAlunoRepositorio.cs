using Dominio.Entidades;
using System;

namespace Dominio.Repositorios
{
    public interface IAlunoRepositorio
    {
        Aluno Buscar(Guid id);
        Aluno Adicionar(Aluno aluno);
        Aluno Alterar(Aluno aluno);
        void Deletar(Guid id);
    }
}