using Abstracciones.Abstracciones;
using Abstracciones.Modelo;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementacion
{
    public class ServiciosBL : IServicios
    {
        public Respuestas<Servicios> GetServiceById()
        {
            ServiciosDA serviciosDA = new();

           return serviciosDA.GetServices();
        }

        public Respuestas<Planes> GetPlanesByServiceId(int Id)
        {
            return new ServiciosDA().GetPlanesByServiceId(Id);
        }

        public Respuestas<Servicios> GetServices()
        {
            return new ServiciosDA().GetServices();
        }

        public Respuestas<Planes> GetDetailsPlanByIdServicio(int IdServicio)
        {
            return new ServiciosDA().GetDetailsPlanByIdServicio(IdServicio);
        }

        public Respuestas<bool> CreateASubscriptions(int IdPlan, int IdCliente)
        {
            return new ServiciosDA().CreateASubscriptions(IdPlan, IdCliente);
        }

        public Respuestas<Suscripcion> GetSubscriptions(int IdCliente)
        {
            return new ServiciosDA().GetSubscriptions(IdCliente);
        }
    }
}
