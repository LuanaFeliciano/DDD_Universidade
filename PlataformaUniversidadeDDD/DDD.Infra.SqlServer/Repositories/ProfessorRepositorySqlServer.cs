using DDD.Domain.SecretariaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Repositories
{
    public class ProfessorRepositorySqlServer : IProfessorRepository
    {

        private readonly SqlServerContext _context;

        public ProfessorRepositorySqlServer(SqlServerContext context)
        {
            _context = context;
        }

        public void DeleteProfessor(Professor professor)
        {
            try
            {
                _context.Set<Professor>().Remove(professor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Professor GetProfessorById(int id)
        {
            return _context.Professores.Find(id);
        }

        public List<Professor> GetProfessores()
        {

            var list = _context.Professores.Include(x => x.Disciplinas).ToList();
            return list;

        }

        public void InsertProfessor(Professor professor)
        {
            try
            {
                _context.Professores.Add(professor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateProfessor(Professor professor)
        {
            try
            {
                _context.Entry(professor).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
