using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public class Professor : User
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public List<Disciplina> Disciplinas { get; set; }

    }
}
