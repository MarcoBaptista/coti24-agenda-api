using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Services
{
    public class TarefaDomainService : ITarefaDomainService
    {
        #region Atributos
        private readonly ITarefaRepository _tarefaRepository;

        //metodo construtor injeção de dependencia da inteface ITarefaRepository
        public TarefaDomainService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        #endregion

        public void Adicionar(Tarefa tarefa)
        {
            _tarefaRepository.Add(tarefa);
        }

        public void Atualizar(Tarefa tarefa)
        {
            _tarefaRepository.Update(tarefa);
        }

        public List<Tarefa> Consultar(DateTime dataMin, DateTime dataMax)
        {
            return _tarefaRepository.Get(dataMin, dataMax); 
        }

        public void Excluir(Guid id)
        {
            var tarefa = _tarefaRepository.GetById(id);
            _tarefaRepository.Delete(tarefa);
        }

        public Tarefa? ObterPorId(Guid id)
        {
            return _tarefaRepository.GetById(id);
        }
    }
}
