using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelo
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }

        public bool Estado { get; set; }
    }
}
