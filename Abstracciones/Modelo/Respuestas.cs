using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelo
{
    public class Respuestas<T>
    {
        public string MensajeError { get; set; } = string.Empty;
        public List<T> ObjetoRespuesta { get; set; }
        public int CodigoRespuesta { get; set; } = 0;
    }
}
