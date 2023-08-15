using Abstracciones.Abstracciones;
using Abstracciones.Modelo;
using BusinessLogic.Implementacion;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarintAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private IServicios Servicios { get; set; }
        public ServiciosController(IServicios Servicios)
        {
            this.Servicios = Servicios;
        }

        // GET: api/<ServiciosController>
        [HttpGet]
        public Respuestas<Servicios> Get()
        {
            return new ServiciosBL().GetServices();
        }

        // GET api/<ClientesController>/5
        [HttpGet("GetPlanesByServiceId/{id}")]
        public Respuestas<Planes> GetPlanesByServiceId(int id)
        {
            try
            {
                return Servicios.GetPlanesByServiceId(id);
            }
            catch (Exception e)
            {

                return new Respuestas<Planes>()
                {
                    MensajeError = e.Message,
                    CodigoRespuesta = 500
                };
            }
        }

        [HttpGet("GetDetailsPlanByIdServicio/{Id}")]
        public string GetDetailsPlanByIdServicio(int Id)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Servicios.GetDetailsPlanByIdServicio(Id));
                return json;
            }
            catch (Exception e)
            {
                string json = JsonConvert.SerializeObject(new Respuestas<Planes>()
                {
                    MensajeError = e.Message,
                    CodigoRespuesta = 500
                });
                return json;
            }
        }

        [HttpGet("GetSubscriptions/{IdCliente}")]
        public string GetSubscriptions(int IdCliente)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Servicios.GetSubscriptions(IdCliente));
                return json;
            }
            catch (Exception e)
            {
                string json = JsonConvert.SerializeObject(new Respuestas<Planes>()
                {
                    MensajeError = e.Message,
                    CodigoRespuesta = 500
                });
                return json;
            }
        }


        // POST api/<ServiciosController>
        [HttpPost("{IdPlan}/{IdCliente}")]
        public string Post(int IdPlan, int IdCliente)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Servicios.CreateASubscriptions(IdPlan,IdCliente));
                return json;
            }
            catch (Exception e)
            {
                string json = JsonConvert.SerializeObject(new Respuestas<Suscripcion>()
                {
                    MensajeError = e.Message,
                    CodigoRespuesta = 500
                });
                return json;
            }
        }
    }
}
