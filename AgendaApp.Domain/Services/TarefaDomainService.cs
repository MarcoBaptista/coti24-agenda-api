using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Exceptions;
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

        public Tarefa Adicionar(Tarefa tarefa)
        {
            tarefa.Id = Guid.NewGuid();
            tarefa.CadastradoEm = DateTime.Now;
            tarefa.UltimaAtualizacaoEm = DateTime.Now;
            tarefa.Ativo = true;

            _tarefaRepository.Add(tarefa);

            return tarefa;
        }

        public Tarefa Atualizar(Tarefa tarefa)
        {
            var tarefaEdicao = _tarefaRepository.GetById(tarefa.Id.Value);
            DomainException.When(tarefaEdicao == null,
               "Tarefa é inválida para edição! Verifique o ID informado.");

            tarefaEdicao.Nome = tarefa.Nome;
            tarefaEdicao.Descricao = tarefa.Descricao;
            tarefaEdicao.DataHora = tarefa.DataHora;
            tarefaEdicao.Prioridade = tarefa.Prioridade;
            tarefaEdicao.UltimaAtualizacaoEm = DateTime.Now;
            

            _tarefaRepository.Update(tarefaEdicao);

            return tarefaEdicao;
        }

        public List<Tarefa> Consultar(DateTime dataMin, DateTime dataMax)
        {
            return _tarefaRepository.Get(dataMin, dataMax); 
        }

        public Tarefa Excluir(Guid id)
        {
            var tarefaExclusao = _tarefaRepository.GetById(id);
            DomainException.When(tarefaExclusao == null,
               "Tarefa é inválida para exclusão! Verifique o ID informado.");
                       
            _tarefaRepository.Delete(tarefaExclusao);

            return tarefaExclusao;
        }

        public Tarefa? ObterPorId(Guid id)
        {
            return _tarefaRepository.GetById(id);
        }
    }
}
