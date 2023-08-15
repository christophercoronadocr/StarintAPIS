using Abstracciones.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Abstracciones
{
    public interface IClientes
    {
        Task<List<Clientes>> GetClientes();
        Task<List<Clientes>> GetClientePorId(int id);
        Clientes UpdateCliente(Clientes clientes);
        bool DeleteCliente(int id);

        Respuestas<Clientes> CreateCliente(Clientes cliente);

        Respuestas<Clientes> GetClienteByEmailContrasena(string email, string contrasena);
    }
}
