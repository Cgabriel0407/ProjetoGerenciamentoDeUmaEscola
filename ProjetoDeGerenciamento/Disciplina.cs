using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeGerenciamento
{
    public class Disciplina
    {
        private string _disciplina;
        public string NomeDaDisciplina
        {
            get => _disciplina;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("A disciplina nao pode ser vazia!");
                }

                if (value.ToString().Length < 3 || value.ToString().Length > 50)
                {
                    throw new ArgumentException("Quantidade de caracteres invalida!");
                }

                _disciplina = value;
            }       
        }
        public Professor ProfessorResponsavel { get; set; }

    }
}
