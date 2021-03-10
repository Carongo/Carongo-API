using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IAlunoRepositorio
    {
        Aluno Adicionar(Aluno aluno);
        Aluno Alterar(Aluno aluno);
        Aluno BuscarPorId(Guid id);
        Aluno BuscarPorNome(string nome);
        void Deletar(Guid id);
        ICollection<Aluno> Listar();

    }
}
