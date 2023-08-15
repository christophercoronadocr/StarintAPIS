using Abstracciones.Abstracciones;
using Abstracciones.Modelo;
using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ServiciosDA
    {
        private ClienteContext _dbContext;
        public ServiciosDA() {
            _dbContext = new ClienteContext();
        }

        public Respuestas<Servicios> GetServices()
        {
            Respuestas<Servicios> respuestas = new();


            List<Servicios> services = _dbContext.Servicios.ToList();

            if (services.Count <= 0)
            {
                respuestas.MensajeError = "No se encontraron servicios";
                respuestas.CodigoRespuesta = 500;
                return respuestas;
            }

            respuestas.ObjetoRespuesta = services;
            respuestas.CodigoRespuesta = 200;
            return respuestas;
        }

        public Respuestas<Planes> GetPlanesByServiceId(int id)
        {
            Respuestas<Planes> respuestas = new();

            List<Planes> plans = _dbContext.Planes.Where(p => p.IdServicio.Equals(id)).ToList();

            if (plans.Count <= 0)
            {
                respuestas.MensajeError = "No se encontraron planes asociados al servicio";
                respuestas.CodigoRespuesta = 500;
                return respuestas;
            }

            respuestas.ObjetoRespuesta = plans;
            respuestas.CodigoRespuesta = 200;
            return respuestas;

            throw new NotImplementedException();
        }

        public Respuestas<Planes> GetDetailsPlanByIdServicio(int IdServicio)
        {
            Respuestas<Planes> respuestas=new();

            var details = _dbContext.Planes.Where(p => p.IdServicio.Equals(IdServicio))
                .Include(d => d.Descripciones).ToList();


            if (details.Count <= 0)
            {
                respuestas.MensajeError = "No se encontraron planes para el servicio seleccionado";
                respuestas.CodigoRespuesta = 500;
                return respuestas;
            }

            respuestas.ObjetoRespuesta = details;
            respuestas.CodigoRespuesta = 200;
            return respuestas;

        }
        public Respuestas<bool> CreateASubscriptions(int IdPlan, int IdCliente)
        {
            Respuestas<bool> respuestas = new();

            try
            {

                var plan = _dbContext.Planes.Where(p => p.Id.Equals(IdPlan)).FirstOrDefault();

                if (plan != null)
                {
                    var subs = _dbContext.Suscripcion.Include(p => p.Planes).Include(s => s.Planes.Servicios).Where(s => s.Planes.IdServicio.Equals(plan.IdServicio) && s.IdCliente.Equals(IdCliente)).ToList();
                    if (subs.Count > 0)
                    {
                        respuestas.CodigoRespuesta = 500;
                        respuestas.MensajeError = "No puede suscribirse. Ya posee una suscripción de un plan para este servicio";
                        return respuestas;
                    }
                }


                Suscripcion suscripcion = new()
                {
                    Id=0,
                    IdPlan=IdPlan,
                    IdCliente=IdCliente
                };
                
                _dbContext.Suscripcion.Add(suscripcion);
                _dbContext.SaveChanges();

                respuestas.CodigoRespuesta = 200;
                respuestas.ObjetoRespuesta = new List<bool> { true };
                return respuestas;
            } 
            catch (Exception e)
            {
                respuestas.CodigoRespuesta = 500;
                respuestas.ObjetoRespuesta = new List<bool> { false };
                respuestas.MensajeError = e.Message;
                return respuestas; 

            }
        }

        public Respuestas<Suscripcion> GetSubscriptions(int IdCliente)
        {
            Respuestas<Suscripcion> respuestas=new();

            var suscripciones = _dbContext.Suscripcion.Where(s => s.IdCliente.Equals(IdCliente))
                .Include(p => p.Planes.Servicios).ToList();


            if (suscripciones.Count <= 0)
            {
                respuestas.MensajeError = "No se encontraron planes para el servicio seleccionado";
                respuestas.CodigoRespuesta = 500;
                return respuestas;
            }

            respuestas.ObjetoRespuesta = suscripciones;
            respuestas.CodigoRespuesta = 200;
            return respuestas;

        }
    }
}
