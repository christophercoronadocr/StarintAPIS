using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelo
{
    public class Servicios
    {
        [Key]
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Planes> Planes { get; set; } = new List<Planes>();
    }
}
