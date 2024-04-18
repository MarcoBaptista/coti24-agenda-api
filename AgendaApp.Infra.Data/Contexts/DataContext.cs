using AgendaApp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de contexto para conexão do EF com bd
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método para configurar o tipo de conexao com bd
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BDAgendaApp");
        }

        /// <summary>
        /// Método para adicionara as classes de mapeamento do projeto
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }

    }
}
