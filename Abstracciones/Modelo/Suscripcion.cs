using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelo
{
    [Table("Suscripcion")]
    public class Suscripcion
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Clientes")]
        public int IdCliente { get; set; }
        [ForeignKey("Planes")]
        public int IdPlan { get; set; }

        public DateTime FechaExpiracion { get; set; } = DateTime.Now.AddYears(1);

        public Planes Planes { get; set; }
        public Clientes Clientes { get; set; }
    }
}
