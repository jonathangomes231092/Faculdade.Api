using FaculdadeApi.Infra.Data.Entities;
using FaculdadeApi.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeApi.Infra.Data.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext (DbContextOptions<SqlServerContext> optins) : base(optins)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new FaculdadeMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
        //REGRA 4) Declarar uma propriedade DbSet para cada entidade
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Faculdad> Faculdade { get; set; }

    }
}
