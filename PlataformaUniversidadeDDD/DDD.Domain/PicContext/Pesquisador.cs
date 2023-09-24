using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PicContext
{
    public class Pesquisador : User
    {
      
        public string Titulacao { get; set; }

        public IList<Projeto> Projetos { get; set; }

    }
    
}
