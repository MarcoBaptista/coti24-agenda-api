using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Services
{
    /// <summary>
    /// Interface para serviços de domínio de tarefa
    /// </summary>
    public interface ITarefaDomainService
    {
        void Adicionar(Tarefa tarefa);
        void Atualizar(Tarefa tarefa);
        void Excluir(Guid Id);
        List<Tarefa> Consultar(DateTime dataMin, DateTime dataMax);
        Tarefa? ObterPorId(Guid id);


    }
}
