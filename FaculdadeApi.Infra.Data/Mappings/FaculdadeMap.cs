using FaculdadeApi.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeApi.Infra.Data.Mappings
{
    public class FaculdadeMap : IEntityTypeConfiguration<Faculdad>
    {
        public void Configure(EntityTypeBuilder<Faculdad> builder)
        {
            
            builder.ToTable("DADOSFACULDADE");
            
            builder.HasKey(e => e.IdAluno);
            
            builder.Property(e => e.IdAluno)
                .HasColumnName("IDALUNO")
                .IsRequired();
            
            builder.Property(e => e.Aluno)
                .HasColumnName("ALUNO")
                .HasMaxLength(150)
                .IsRequired();
            
            builder.Property(e => e.Turma)
                .HasColumnName("TURMA")
                .HasMaxLength(150)
                .IsRequired();
            
            builder.Property(e => e.Professor)
                .HasColumnName("PROFESSOR")
                .HasMaxLength(150)
                .IsRequired();
            
            builder.Property(e => e.Materias)
                .HasColumnName("MATERIAS")
                .HasMaxLength(150)
                .IsRequired();
            
            
        }
    }
}
