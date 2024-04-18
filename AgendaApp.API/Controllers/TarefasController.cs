using AgendaApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Post(TarefasPostRequestModel model)
        {
            //todo desenvolver
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Put(TarefasPutRequestModel model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Get(Guid id)
        {
            return Ok();
        }

        [HttpGet ("{dataMin}/{dataMax}")]
        [ProducesResponseType(typeof(List<TarefasGetResponseModel>), 200)]
        public IActionResult Get(DateTime dataMin, DateTime dataMax) 
        {
            return Ok(); 
        }



    }
}
