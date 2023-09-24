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
    public class DisciplinaRepositorySqlServer : IDisciplinaRepository
    {

        private readonly SqlServerContext _context;

        public DisciplinaRepositorySqlServer(SqlServerContext context)
        {
            _context = context;
        }

        public void DeleteDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Set<Disciplina>().Remove(disciplina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Disciplina GetDisciplinaById(int id)
        {
            return _context.Disciplinas.Find(id);
        }

        public List<Disciplina> GetDisciplinas()
        {

            var list = _context.Disciplinas.ToList();
            return list;

        }

        public void InsertDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Disciplinas.Add(disciplina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Entry(disciplina).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
