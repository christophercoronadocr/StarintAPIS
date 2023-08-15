using Abstracciones.Abstracciones;
using Abstracciones.Modelo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarintAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClientes Clientes { get; set; }
        public ClientesController(IClientes clientes)
        {
            Clientes = clientes;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public Task<List<Clientes>> Get()
        {
            return Clientes.GetClientes();
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public Task<List<Clientes>> Get(int id)
        {
            return Clientes.GetClientePorId(id);
        }

        // GET api/<ClientesController>/5
        [HttpPost("GetClienteByEmailContrasena")]
        public Respuestas<Clientes> GetClienteByEmailContrasena([FromBody] Clientes cliente)
        {
            try
            {
                return Clientes.GetClienteByEmailContrasena(cliente.Email, cliente.Contrasena);
            }
            catch (Exception e)
            {

                return new Respuestas<Clientes>()
                {
                    MensajeError = e.Message,
                    CodigoRespuesta = 500
                };
            }
        }

        // POST api/<ClientesController>
        [HttpPost]
        public Respuestas<Clientes> Post([FromBody] Clientes cliente)
        {
            try
            {
                return Clientes.CreateCliente(cliente);
            }
            catch (Exception e)
            {
                return new Respuestas<Clientes>()
                {
                    MensajeError = e.Message,
                    CodigoRespuesta = 500
                };
            }
        }

        // DELETE api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Delete(int id)
        {
        }
    }
}
