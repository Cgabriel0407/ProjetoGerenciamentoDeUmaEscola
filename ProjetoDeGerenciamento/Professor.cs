using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDeEscola;

namespace ProjetoDeGerenciamento
{
    public class Professor
    {
        // Propriedades
        public List<Turma> Turmas { get; set; } = new List<Turma> { };

        private string _nome;
        private static int contadorProfessor = 5000;

        public Professor()
        {
            Matricula = contadorProfessor++;
        }
        public string Nome
        {
            get => _nome;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("O nome nao pode ser vazio!");
                }
                _nome = value;
            }
        }
        private string _disciplina;
        public string Disciplina { 
            get => _disciplina;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("A disciplina nao pode ser vazia!");
                }

                if(value.ToString().Length < 3 || value.ToString().Length> 50)
                {
                    throw new ArgumentException("Quantidade de caracteres invalida!");
                }

                _disciplina = value;
            }
        }
        public int Matricula { get; set; }

        // Metodos

        public void AtribuirDisciplina(Disciplina disciplina)
        {
            disciplina.ProfessorResponsavel = this;
            this.Disciplina = disciplina.NomeDaDisciplina;
        }

        public override string ToString()
        {
            return ($"Professor: {Nome}");
        }

        public void ListarTurmas()
        {
            if(Turmas.Count == 0)
            {
                Console.WriteLine("Nenhuma turma listada!");
            }
            else
            {   
                foreach (Turma turma in Turmas)
                {
                    Console.WriteLine(turma.ToString());
                }
            }

        }

        public void Apresentar()
        {
            if (!string.IsNullOrEmpty(Disciplina))
            {
                Console.WriteLine($"Nome: {Nome}, Disciplina: {Disciplina}, Matricula: {Matricula} (Professor responsável)");
            }
            else
            {
                Console.WriteLine($"Nome: {Nome}, Sem disciplina atribuída, Matricula: {Matricula}");
            }
        }

    }
}
