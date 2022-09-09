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
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public UsuarioRepository (SqlServerContext sqlServerContext): base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }


        public void Alterar(Usuario entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();

        }

        public List<Usuario> Consultar()
        {
            return _sqlServerContext.Usuario.OrderBy(u => u.Nome).ToList();
        }

        public void Excluir(Usuario entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Deleted;
            _sqlServerContext.SaveChanges();

        }

        public void Inserir(Usuario entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Added;
            _sqlServerContext.SaveChanges();

        }

        public Usuario Obter(string login, string senha)
        {
            return _sqlServerContext.Usuario.Where(u => u.Login.Equals(login) && 
            u.Senha.Equals(senha)).FirstOrDefault();

        }

        public Usuario ObterPorId(Guid id)
        {
            return _sqlServerContext.Usuario.Where(u => u.IdUsuario == id).FirstOrDefault();

        }
    }
}
