using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDeEscola;

namespace ProjetoDeGerenciamento
{
    public class Turma
    {
        public List<Aluno> Alunos { get; set; } = new List<Aluno> { };
        public List<Professor> Professores { get; set; } = new List<Professor> { };

        private int _matricula;

        public int contadorT1 { get; set; } = 1000;
        public int contadorT2 { get; set; } = 2000;
        public int contadorT3 { get; set; } = 3000;

        public int Matricula
        {
            get
            {
                return _matricula;
            }
            set
            {
                if (value.ToString().Length <= 4 && value.ToString().Length > 0)
                {
                    _matricula = value;
                }
                else
                {
                    throw new ArgumentException("Matricula invalida!");
                }
            }
        }

        public int GerarMatricula(int ano)
        {
            int matricula = 0;  
            if(ano == 1)
            {
                matricula = contadorT1++;
            } else if(ano == 2)
            {
                matricula = contadorT2++;
            } else if(ano == 3)
            {
                matricula = contadorT3++;
            }
            else
            {
                Console.WriteLine("Ano invalido!");
            }


                return matricula;
        }

        public void ListarAlunos()
        {
            foreach (Aluno aluno in Alunos)
            {
                aluno.Apresentar();
            }
        }


        public void ListarProfessores()
        {
            foreach (Professor professor in Professores)
            {
                professor.Apresentar();
            }
        }
     
        public void AdicionarAluno(Aluno aluno)
        {
            Alunos.Add(aluno);
        }

        public void RemoverAluno(Aluno aluno)
        {
            Alunos.Remove(aluno);
        }

        public void AdicionarProfessor(Professor professor)
        {
            Professores.Add(professor);
            professor.Turmas.Add(this);
        }

        public void RemoverProfessor(Professor professor)
        {
            Professores.Remove(professor);
        }

        public bool QuantidadeDeVagas()
        {
            int vagasPorTurma = 40;
            int vagasDisponiveis = vagasPorTurma - Alunos.Count;

            // Apenas retorna se há vaga ou não
            return Alunos.Count < vagasPorTurma;
        }

    }

}


