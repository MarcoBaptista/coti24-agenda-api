using System.ComponentModel.DataAnnotations;

namespace AgendaApp.API.Models
{

    /// <summary>
    /// MOdelo de dados para a requisicao de edição da tarefa
    /// </summary>
    public class TarefasPutRequestModel
    {
        [Required(ErrorMessage ="Id da tarefa é obrigatório.")]
        public Guid? Id { get; set; }

        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor infome o nome da tarefa.")]
        public string? Nome { get; set; }

        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(250, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor infome o descrição  da tarefa.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Por favor infome data e hora da tarefa.")]
        public DateTime? DataHora { get; set; }


        [Required(ErrorMessage = "Por favor infome a prioridade da tarefa.")]
        public int? Prioridadade { get; set; }
    }
}
