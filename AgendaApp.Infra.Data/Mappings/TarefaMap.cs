using AgendaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            //chave primaria
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x=> x.Descricao)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.DataHora)
                .IsRequired();
            builder.Property(x=> x.Prioridade)
                .IsRequired();
            builder.Property(x=> x.CadastradoEm)
                .IsRequired();
            builder.Property(x=> x.UltimaAtualizacaoEm)
                .IsRequired();
            builder.Property(x=> x.Ativo)
                .IsRequired();
        }
    }
}
