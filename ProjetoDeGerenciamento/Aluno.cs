    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace GerenciamentoDeEscola
    {
        public class Aluno
        {
            // Criando os Construtores

            public Aluno()
            {

            }

            public Aluno(string nome, int ano, int idade)
            {
                this.Nome = nome;
                this.Ano = ano;
                this.Idade = idade;
            }

            // Criando as propriedades
            private string _nome;
            private int _idade;
            private string _nomeDoCurso;
            private int _ano;
            public string Nome
            {
                get
                {
                    return _nome;
                }
                set
                {
                    if (value == "")
                    {
                        throw new ArgumentException("O nome nao pode ser vazio!");
                    }
                    _nome = value;
                }
            }

            public int Idade
            {
                get => _idade;

                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("A idade nao pode ser negativa");
                    }

                    if (value > 100)
                    {
                        throw new ArgumentException("A idade nao pode ser superior a 100");
                    }
                    _idade = value;
                }
            }
            public int Ano {
                get => _ano;
                set
                {
                    if (value != 1 && value !=2 && value != 3)
                    {
                        throw new ArgumentException("Insira o ano valido");
                    }
                    _ano = value;
                }
            }

        public int Matricula { get; set; }  
        // Criando os Metodos

        public void Apresentar()
            {
                Console.WriteLine($"Nome: {Nome}, Idade: {Idade},Ano: {Ano}, Matricula {Matricula}");
            }

        }
    }
