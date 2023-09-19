using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public class Matricula
    {
        public int Id { get; set; }

        public int AlunoId { get; set; } // Chave estrangeira para o aluno
        public Aluno Aluno { get; set; } // Propriedade de navegação para o aluno

        public int DisciplinaId { get; set; } // Chave estrangeira para a disciplina
        public Disciplina Disciplina { get; set; } // Propriedade de navegação para a disciplina

        public DateTime DataMatricula { get; set; } // Data da matrícula
        public bool Ativa { get; set; } // Status da matrícula

    }
}
