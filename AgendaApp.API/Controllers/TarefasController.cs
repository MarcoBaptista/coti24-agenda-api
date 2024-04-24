using AgendaApp.API.Models;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Entities.Enums;
using AgendaApp.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaDomainService _tarefaDomainService;
        private readonly IMapper _mapper;


        //construtor para injecao de dependencia das interfaces de domainservice
        public TarefasController(ITarefaDomainService tarefaDomainService, IMapper mapper)
        {
            _tarefaDomainService = tarefaDomainService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 201)]
        public IActionResult Post(TarefasPostRequestModel model)
        {
            var tarefa = _mapper.Map<Tarefa>(model);    
            tarefa.Id = Guid.NewGuid();
            tarefa.CadastradoEm = DateTime.Now;
            tarefa.UltimaAtualizacaoEm = DateTime.Now;
            tarefa.Ativo = true;
            
            _tarefaDomainService.Adicionar(tarefa);

            var response = _mapper.Map<TarefasPostRequestModel>(tarefa);
            return StatusCode( 201, response);

        }

        [HttpPut]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Put(TarefasPutRequestModel model)
        {
            var tarefa = _mapper.Map<Tarefa>(model);
            tarefa.UltimaAtualizacaoEm = DateTime.Now;
            
            _tarefaDomainService.Atualizar(tarefa);

            var response = _mapper.Map<TarefasGetResponseModel>(tarefa);
            return StatusCode(200, response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            var tarefa = _tarefaDomainService.ObterPorId(id);
            tarefa.Ativo = false;

            _tarefaDomainService.Excluir(id);

            var response = _mapper.Map<TarefasGetResponseModel>(tarefa);

            return StatusCode(200, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Get(Guid id)
        {
            var tarefa = _tarefaDomainService.ObterPorId(id);
            var response = _mapper.Map<TarefasGetResponseModel>(tarefa);

            return StatusCode(200, response);
        }

        [HttpGet ("{dataMin}/{dataMax}")]
        [ProducesResponseType(typeof(List<TarefasGetResponseModel>), 200)]
        public IActionResult Get(DateTime dataMin, DateTime dataMax) 
        {
            var tarefas = _tarefaDomainService.Consultar(dataMin, dataMax);

            var response = new List<TarefasGetResponseModel>(); 
            foreach (var tarefa in tarefas)
            {
               response.Add(_mapper.Map<TarefasGetResponseModel>(tarefa));
            };

            return StatusCode(200, response);
        }



    }
}
