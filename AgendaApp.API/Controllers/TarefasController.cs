using AgendaApp.API.Models;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Entities.Enums;
using AgendaApp.Domain.Exceptions;
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
            try
            {
                var tarefa = _tarefaDomainService.Adicionar(_mapper.Map<Tarefa>(model));
                var response = _mapper.Map<TarefasGetResponseModel>(tarefa);
                return StatusCode(201, response);
            }
            catch (DomainException ex)
            {
                //http 422 (UNPROCESSABLE CONTENT)
                return StatusCode(422, new { message = ex.Message });
            }
            catch (Exception e)
            {
                //http 500 (internal server error)
                return StatusCode(500, new { message = e.Message});

            }
                    
        }

        [HttpPut]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Put(TarefasPutRequestModel model)
        {
            try
            {
                var tarefa = _tarefaDomainService.Atualizar(_mapper.Map<Tarefa>(model));

                var response = _mapper.Map<TarefasGetResponseModel>(tarefa);
                return StatusCode(200, response);

            }
            catch (DomainException ex)
            {
                //http 422 (UNPROCESSABLE CONTENT)
                return StatusCode(422, new { message = ex.Message });
            }
            catch (Exception e)
            {

                //htttp 500 (internal server error;
                return StatusCode(500, new { message = e.Message });

            }
           
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var tarefa = _tarefaDomainService.Excluir(id);
                var response = _mapper.Map<TarefasGetResponseModel>(tarefa);

                return StatusCode(200, response);

            }
            catch (DomainException ex)
            {
                //http 422 (UNPROCESSABLE CONTENT)
                return StatusCode(422, new { message = ex.Message });
            }
            catch (Exception e)
            {
                //htttp 500 (internal server error;
                return StatusCode(500, new { message = e.Message });
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Get(Guid id)
        {
            try
            {
                var tarefa = _tarefaDomainService.ObterPorId(id);
                if (tarefa == null)
                    return StatusCode(204);
                
                var response = _mapper.Map<TarefasGetResponseModel>(tarefa);

                return StatusCode(200, response);
            }
            catch (Exception e)
            {

                //htttp 500 (internal server error;
                return StatusCode(500, new { message = e.Message });
            }
            
          
        }

        [HttpGet ("{dataMin}/{dataMax}")]
        [ProducesResponseType(typeof(List<TarefasGetResponseModel>), 200)]
        public IActionResult Get(DateTime dataMin, DateTime dataMax) 
        {
            try
            {
                var tarefas = _tarefaDomainService.Consultar(dataMin, dataMax);

                if (!tarefas.Any())
                    return StatusCode(204);//no content

                var response = _mapper.Map<List<TarefasGetResponseModel>>(tarefas);
                return StatusCode(200, response);

            }
            catch (Exception e)
            {

                //htttp 500 (internal server error;
                return StatusCode(500, new { message = e.Message });
            }

           
        }



    }
}
