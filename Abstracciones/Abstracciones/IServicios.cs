using Abstracciones.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Abstracciones
{
    public interface IServicios
    {
        Respuestas<Servicios> GetServices();
        Respuestas<Servicios> GetServiceById();
        Respuestas<Planes> GetPlanesByServiceId(int Id);
        Respuestas<Planes> GetDetailsPlanByIdServicio(int IdServicio);
        Respuestas<bool> CreateASubscriptions(int IdPlan, int IdCliente);
        Respuestas<Suscripcion> GetSubscriptions(int IdCliente);
    }
}
