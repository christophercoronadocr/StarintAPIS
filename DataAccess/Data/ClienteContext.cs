using Abstracciones.Modelo;
using System.Configuration;
using System.Data.Entity;

namespace DataAccess.Data
{
    public class ClienteContext: DbContext
    {
        public ClienteContext() : base(@"Server=DESKTOP-GUGL761\SQLEXPRESS;Database=Starint;Trusted_Connection=True;") { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Planes> Planes { get; set; }
        public DbSet<PlanDescripcion> PlanDescripciones { get; set; }
        public DbSet<Suscripcion> Suscripcion { get; set; }

    }
}
