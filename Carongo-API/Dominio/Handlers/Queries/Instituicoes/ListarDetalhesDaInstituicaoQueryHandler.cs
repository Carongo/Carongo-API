using Comum.Handlers;
using Comum.Queries;
using Comum.Utils;
using Dominio.Entidades;
using Dominio.Queries.InstituicaoRequests;
using Dominio.Repositorios;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Handlers.Queries.Instituicoes
{
    public class ListarDetalhesDaInstituicaoQueryHandler : IHandlerQuery<ListarDetalhesDaInstituicaoQuery>
    {
        private IInstituicaoRepositorio Repositorio { get; set; }

        public ListarDetalhesDaInstituicaoQueryHandler(IInstituicaoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public IQueryResult Handle(ListarDetalhesDaInstituicaoQuery query)
        {
            var turmasDaInstituicao = Repositorio.Buscar(query.IdInstituicao).Turmas;

            if(turmasDaInstituicao.Count < 1)
                return new GenericQueryResult(false, "Esta instituição ainda está vazia!", null);

            var turmas = new List<Turma>();
            var imagens = new List<string>();
            string alunoUrlFoto = null;

            if (query.Nome != null)
            {
                turmasDaInstituicao.ForEach(
                    t => {
                        if(t.Alunos != null)
                        {
                            var alunosFiltrados = t.Alunos.FindAll(a => a.Nome.ToLower().Contains(query.Nome));
                            t.Alunos.Clear();
                            t.Alunos.AddRange(alunosFiltrados);
                            if (t.Alunos.Count > 0)
                                turmas.Add(t);
                        }
                    });

                if(turmas.Count > 0)
                {
                    var result = new
                    {
                        Turmas = 
                            turmas.Select(t =>
                            {
                                return new {
                                    IdTurma = t.Id,
                                    NomeTurma = t.Nome,
                                    Alunos =  t.Alunos.Select(a =>
                                        {
                                            return new
                                            {
                                                IdAluno = a.Id,
                                                NomeAluno = a.Nome,
                                                Email = a.Email,
                                                DataNascimento = a.DataNascimento,
                                                UrlFoto = a.UrlFoto,
                                                CPF = a.CPF
                                            };
                                        })
                                };
                            })
                        
                    };

                    return new GenericQueryResult(true, "Alunos da instituição filtrados!", result);
                }
                    
                return new GenericQueryResult(false, "Nenhum aluno encontrado!", null);
            }
                
            if (query.UrlImagem != null)
            {
                turmas = turmasDaInstituicao;
                turmas.ForEach(t =>
                {
                    if (t.Alunos != null)
                    {
                        t.Alunos.ForEach(a =>
                        {
                            imagens.Add(a.UrlFoto);
                        });
                    }
                });

                alunoUrlFoto = Azure.FindSimilar(query.UrlImagem, RecognitionModel.Recognition01, imagens).Result;

                if(alunoUrlFoto != null)
                {
                    turmas[0] = turmas.Find(t => t.Alunos.Find(a => a.UrlFoto == alunoUrlFoto) != null);
                    turmas[0].Alunos[0] = turmas[0].Alunos.Find(a => a.UrlFoto == alunoUrlFoto);

                    var result = new { 
                        Turmas = new[] {
                            new {
                                IdTurma = turmas[0].Id,
                                NomeTurma = turmas[0].Nome,
                                Alunos = new [] {
                                    new
                                    {
                                        IdAluno = turmas[0].Alunos[0].Id,
                                        NomeAluno = turmas[0].Alunos[0].Nome,
                                        Email = turmas[0].Alunos[0].Email,
                                        DataNascimento = turmas[0].Alunos[0].DataNascimento,
                                        UrlFoto = turmas[0].Alunos[0].UrlFoto,
                                        CPF = turmas[0].Alunos[0].CPF
                                    }
                                }
                            }
                        }
                    };

                    return new GenericQueryResult(true, "Aluno encontrado!", result);
                }

                return new GenericQueryResult(false, "Não existe ou não foi possível encontrar nenhum aluno parecido com a pessoa da foto!", null);
            }

            var resultado = new
            {
                Turmas =
                    turmasDaInstituicao.Select(t =>
                    {
                        return new
                        {
                            IdTurma = t.Id,
                            NomeTurma = t.Nome,
                            Alunos = t.Alunos.Select(a =>
                            {
                                return new
                                {
                                    IdAluno = a.Id,
                                    NomeAluno = a.Nome,
                                    Email = a.Email,
                                    DataNascimento = a.DataNascimento,
                                    UrlFoto = a.UrlFoto,
                                    CPF = a.CPF
                                };
                            })
                        };
                    })
            };

            return new GenericQueryResult(true, "Turmas da instituição e alunos delas!", resultado);
        }
    }
}