using FaculdadeApi.Infra.Data.Contexts;
using FaculdadeApi.Infra.Data.Entities;
using FaculdadeApi.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeApi.Infra.Data.Repositories
{
    public class FaculdadeRepository : BaseRepository<Faculdad>, IFaculdadeRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        
        public FaculdadeRepository(SqlServerContext sqlServerContext)
            :base (sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public void Alterar(Faculdad entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();

        }

        public List<Faculdad> Consultar()
        {
            return _sqlServerContext.Faculdade.OrderBy(e => e.Aluno).ToList();

        }

        public void Excluir(Faculdad entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Deleted;
            _sqlServerContext.SaveChanges();
        }

        public void Inserir(Faculdad entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Added;
            _sqlServerContext.SaveChanges();

        }

        public Faculdad Obter(string Turma)
        {
            return _sqlServerContext.Faculdade.Where(e => e.Turma.Equals(Turma)).FirstOrDefault();

        }

        public Faculdad ObterPorId(Guid id)
        {
            return _sqlServerContext.Faculdade.Where(e => e.IdAluno == id).FirstOrDefault();
        }
    }
}
