using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Abstracciones.Modelo
{
    [Table("PlanDescripcion")]
    public class PlanDescripcion
    {
        [Key]
        public int IdDescripcion { get; set; }
        [ForeignKey("Plan")]
        public int IdPlan { get; set; }
        public string Descripcion { get; set; }

        [JsonIgnore]
        public Planes Plan { get; set; }

    }
}
