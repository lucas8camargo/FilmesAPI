using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FilmesApi.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Diretor { get; set; }

        [Required]
        [Column(TypeName = "date")] // SQL Server salva como apenas yyyy-MM-dd
        [JsonConverter(typeof(JsonDateOnlyConverter))]
        public DateTime AnoLancamento { get; set; }

        [Column(TypeName = "datetime2(0)")] // yyyy-MM-dd HH:mm:ss (sem milissegundos)
        [JsonConverter(typeof(JsonDateTimeNoSecondsConverter))]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
