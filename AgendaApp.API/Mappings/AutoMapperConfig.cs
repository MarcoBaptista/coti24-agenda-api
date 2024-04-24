using AgendaApp.API.Controllers;
using AgendaApp.API.Models;
using AgendaApp.Domain.Entities;
using AutoMapper;

namespace AgendaApp.API.Mappings
{
    /// <summary>
    /// Mapeamento das transferencias de dados realizados pelo automapper
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TarefasPostRequestModel, Tarefa>();
            CreateMap<Tarefa, TarefasGetResponseModel>();
        }
    }
}
