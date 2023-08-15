using Abstracciones.Abstracciones;
using Abstracciones.Modelo;
using DataAccess;

namespace BusinessLogic.Implementacion
{
    public class ClientesBL : IClientes
    {
        public Respuestas<Clientes> CreateCliente(Clientes cliente)
        {
           ClientesDA clientesDA = new();
           return clientesDA.CreateCliente(cliente);
        }

        public bool DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Respuestas<Clientes> GetClienteByEmailContrasena(string email, string contrasena)
        {
            Respuestas<Clientes> respuestas = new Respuestas<Clientes>();
            ClientesDA clientesDA = new();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasena))
            {
                respuestas.MensajeError = "Los campos no pueden ser vacíos";
                respuestas.CodigoRespuesta = 400;
                return respuestas;
            }

            return clientesDA.GetClienteByEmailContrasena(email, contrasena);
        }

        public Task<List<Clientes>> GetClientePorId(int id)
        {
            ClientesDA clientesDA = new();
            Task<List<Clientes>> clientesLista = clientesDA.GetClientePorId(id);
            return clientesLista;
        }

        public Task<List<Clientes>> GetClientes()
        {
            ClientesDA clientesDA = new();
            Task<List<Clientes>> clientesLista = clientesDA.GetClientes();
            return clientesLista;
        }

        public Clientes UpdateCliente(Clientes clientes)
        {
            throw new NotImplementedException();
        }
    }
}