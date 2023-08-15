using Abstracciones.Modelo;
using DataAccess.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ClientesDA
    {
        private ClienteContext _dbContext;
        public ClientesDA()
        {
            _dbContext = new ClienteContext();
        }
        public bool DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Clientes>> GetClientes()
        {
            List<Clientes> clientes =  _dbContext.Clientes.ToList();
            return Task.FromResult(clientes);
        }
        public Task<List<Clientes>> GetClientePorId(int id)
        {
            List<Clientes> clientes = _dbContext.Clientes.Where(c => c.Id.Equals(id) && c.Estado.Equals(true)).ToList();
            return Task.FromResult(clientes);
        }

        public Clientes UpdateCliente(Clientes clientes)
        {
            throw new NotImplementedException();
        }

        public Respuestas<Clientes> GetClienteByEmailContrasena(string email, string contrasena)
        {
            Respuestas<Clientes> respuestas = new();
            Clientes? cliente = null;

             var result = _dbContext.Clientes.Where(c => c.Email.Equals(email) && c.Contrasena.Equals(contrasena)).ToList();

            if (result.Count > 0)
            {
                cliente = result.Last();
            }


            if (cliente == null)
            {
                respuestas.MensajeError = "Correo o contraseña invalidos";
                respuestas.CodigoRespuesta = 400;
                return respuestas;
            }

            List<Clientes> listaCliente = new()
            {
                cliente
            };

            respuestas.ObjetoRespuesta = listaCliente;
            respuestas.CodigoRespuesta = 200;

            return respuestas;
        }

        public Respuestas<Clientes> CreateCliente(Clientes cliente)
        {
            Respuestas<Clientes> respuesta = new Respuestas<Clientes>();

            Clientes clientes = new()
            {
                Id = 0,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                DNI = cliente.DNI,
                Telefono = cliente.Telefono,
                Pais = cliente.Pais,
                FechaNacimiento = cliente.FechaNacimiento,
                Email = cliente.Email,
                Contrasena = cliente.Contrasena,
                Estado = true
            };

            int existeCliente = _dbContext.Clientes.Where(_ => _.Email == cliente.Email).ToList().Count();
            if (existeCliente > 0)
            {
                respuesta.CodigoRespuesta = 400;
                respuesta.MensajeError = $"El correo electronico ya está registrado {cliente.Email}";
                return respuesta;
            }

            _dbContext.Clientes.Add(clientes);
            _dbContext.SaveChanges();

            Clientes clienteRetorno = _dbContext.Clientes.Where(c => c.Email.Equals(cliente.Email)).ToList().Last();

            if (clienteRetorno != null)
            {
                List<Clientes> listaCliente = new List<Clientes>();
                listaCliente.Add(clienteRetorno);

                respuesta.ObjetoRespuesta = listaCliente;
                respuesta.CodigoRespuesta = 200;
            } else
            {
                respuesta.ObjetoRespuesta.Add(cliente);
                respuesta.MensajeError = $"Se produjo un error al guardar el registro {cliente.Email}";
                respuesta.CodigoRespuesta = 400;
            }

            return respuesta;
        }
    }
}