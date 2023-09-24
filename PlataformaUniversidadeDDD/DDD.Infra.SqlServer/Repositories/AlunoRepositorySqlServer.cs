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
    public class AlunoRepositorySqlServer : IAlunoRepository
    {

        private readonly SqlServerContext _context;

        public AlunoRepositorySqlServer(SqlServerContext context)
        {
            _context = context;
        }

        public void DeleteAluno(Aluno aluno)
        {
            try
            {
                _context.Set<Aluno>().Remove(aluno);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Aluno GetAlunoById(int id)
        {
            return _context.Alunos.Find(id);
        }

        public List<Aluno> GetAlunos()
        {

            var list = _context.Alunos.Include(x => x.Matriculas).ToList();
            return list;

        }

        public void InsertAluno(Aluno aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateAluno(Aluno aluno)
        {
            try
            {
                _context.Entry(aluno).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
