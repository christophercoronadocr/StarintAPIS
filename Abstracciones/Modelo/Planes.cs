using Abstracciones.Abstracciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelo
{
    public class Planes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int IdServicio { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public string Informacion { get; set; }
        [JsonIgnore]
        public Servicios Servicios { get; set; }
        public List<PlanDescripcion> Descripciones { get; set; } = new List<PlanDescripcion>();
    }
}
