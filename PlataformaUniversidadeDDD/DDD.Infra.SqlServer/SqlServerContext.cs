using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SqlServer
{
    public class SqlServerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matricula>().HasKey(m => new {m.AlunoId, m.DisciplinaId});
            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Professor> Professores { get; set; }
    }
}