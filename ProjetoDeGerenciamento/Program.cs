using System;
using GerenciamentoDeEscola;

namespace ProjetoDeGerenciamento
{
    class Program
    {
        static void Main(string[] args)
        {

            // CRIAR UM MENU INTERATIVO
            Console.WriteLine("--- SISTEMA DE GERENCIAMENTO ---\n");
            Console.WriteLine("O que você deseja fazer?\n" +
                "1 - Gerenciar Alunos\n" +
                "2 - Gerenciar Professores\n" +
                "3 - Gerenciar Turmas\n" +
                "4 - Sair do Sistema");

            int repostaMenu = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (repostaMenu)
            {
                case 1:
                    
                    Console.WriteLine("--- GERENCIAMENTO DE ALUNOS ---\n");
                    Console.WriteLine("O que você deseja fazer?\n" +
                "1 - Cadastrar aluno\n" +
                "2 - Remover aluno\n" +
                "3 - Verificar nota do aluno\n" +
                "4 - Verificar se passou de ano\n" +
                "5 - Voltar para o menu");

                    int repostaAluno = int.Parse(Console.ReadLine());
                    if(repostaAluno == 1)
                    {
                        
                    }
                    break;
                case 2:
                    Console.WriteLine("--- GERENCIAMENTO DE PROFESSORES ---\n");
                    Console.WriteLine("O que você deseja fazer?\n" +
                "1 - Cadastrar professor\n" +
                "2 - Remover professor\n" +
                "3 - Atribuir disciplina\n" +
                "4 - Atribuir turma\n" +
                "5 - Voltar para o menu");
                    break;
                case 3:
                    Console.WriteLine("--- GERENCIAMENTO DE TURMAS ---\n");
                    Console.WriteLine("O que você deseja fazer?\n" +
                "1 - Adicionar aluno da turma\n" +
                "2 - Remover aluno da turma\n" +
                "3 - Listar alunos\n" +
                "4 - Listar professores\n" +
                "5 - Voltar para o menu");
                    break;
                case 4:
                    Console.WriteLine("SISTEMA ENCERRADO!");
                    break;
            }




            Turma turma1 = new Turma();
            Turma turma2 = new Turma();
            Turma turma3 = new Turma();

            while (true)
            {
                Console.WriteLine("Deseja adicionar um professor? (sim/nao)");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() != "sim")
                {
                    break;
                }

                Console.Clear();

                Disciplina disciplinaProfessor = new Disciplina();
                Professor professor = new Professor();

                Console.WriteLine("Insira o nome do professor:");
                professor.Nome = Console.ReadLine();
                Console.WriteLine("Qual disciplina ele ira ministrar?: ");
                disciplinaProfessor.NomeDaDisciplina = Console.ReadLine();
                professor.AtribuirDisciplina(disciplinaProfessor);

                Console.WriteLine("Em qual turma(s) voce ira ministrar aula? (Digite números separados por vírgula, ex: 1,3)");
                string respostaProfessor = Console.ReadLine();

                string[] turmasEscolhidas = respostaProfessor.Split(',');

                foreach (string t in turmasEscolhidas)
                {
                    if (int.TryParse(t.Trim(), out int turmaNum))
                    {
                        if (turmaNum == 1)
                            turma1.AdicionarProfessor(professor);
                        else if (turmaNum == 2)
                            turma2.AdicionarProfessor(professor);
                        else if (turmaNum == 3)
                            turma3.AdicionarProfessor(professor);
                        else
                            Console.WriteLine($"Turma {turmaNum} não existe!");
                    }
                }

                professor.Apresentar();

            }

            Console.WriteLine("Deseja ver a lista de professores? (sim/nao)");
            string verLista = Console.ReadLine();

            if (verLista == "sim" || verLista == "Sim")
            {

                Console.WriteLine("\n=== Lista de professores ===");
                Console.WriteLine("\n1º Ano:");
                turma1.ListarProfessores();

                Console.WriteLine("\n2º Ano:");
                turma2.ListarProfessores();

                Console.WriteLine("\n3º Ano:");
                turma3.ListarProfessores();
            }

            while (true)
            {
                // Pergunta se o usuário quer adicionar um aluno
                Console.WriteLine("Deseja adicionar um aluno? (sim/nao)");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() != "sim")
                {
                    break; // Sai do loop se o usuário não quiser adicionar
                }

                Console.Clear();

                // Cria o objeto Aluno e preenche os dados
                Aluno aluno = new Aluno();
                Console.WriteLine("Insira o nome do aluno:");

                aluno.Nome = Console.ReadLine();
                Console.WriteLine("Insira a idade do aluno:");

                aluno.Idade = int.Parse(Console.ReadLine());
                int anoAluno;

                Console.WriteLine("Insira a turma do aluno (1, 2 ou 3):");
                if (int.TryParse(Console.ReadLine(), out anoAluno))
                {
                    aluno.Ano = anoAluno;
                }
                else
                {
                    Console.WriteLine("Entrada invalida.Por favor, insira um número");
                }


                // Adiciona o aluno na turma correspondente, verificando vagas
                if (aluno.Ano == 1)
                {
                    if (turma1.QuantidadeDeVagas())
                    {
                        turma1.AdicionarAluno(aluno);
                        aluno.Matricula = turma1.GerarMatricula(aluno.Ano);
                        Console.WriteLine("Aluno cadastrado!");
                    }
                    else
                    {
                        Console.WriteLine("A turma 1º ano está cheia!");
                    }
                }
                else if (aluno.Ano == 2)
                {
                    if (turma2.QuantidadeDeVagas())
                    {
                        turma2.AdicionarAluno(aluno);
                        aluno.Matricula = turma2.GerarMatricula(aluno.Ano);
                        Console.WriteLine("Aluno cadastrado!");
                    }
                    else
                    {
                        Console.WriteLine("A turma 2º ano está cheia!");
                    }
                }
                else if (aluno.Ano == 3)
                {
                    if (turma3.QuantidadeDeVagas())
                    {
                        turma3.AdicionarAluno(aluno);
                        aluno.Matricula = turma3.GerarMatricula(aluno.Ano);
                        Console.WriteLine("Aluno cadastrado!");
                    }
                    else
                    {
                        Console.WriteLine("A turma 3º ano está cheia!");
                    }
                }
                else
                {
                    Console.WriteLine("Insira uma turma valida!");
                }


            }
            // Lista todos os alunos cadastrados na turma

            Console.WriteLine("Deseja ver a lista de alunos? (sim/nao)");
            verLista = Console.ReadLine();

            if (verLista == "sim" || verLista == "Sim")
            {
                Console.WriteLine("\n=== Lista de alunos ===");
                Console.WriteLine("\n1º Ano:");
                turma1.ListarAlunos();

                Console.WriteLine("\n2º Ano:");
                turma2.ListarAlunos();

                Console.WriteLine("\n3º Ano:");
                turma3.ListarAlunos();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Programa encerrado!");
            }

        }
    }
}
