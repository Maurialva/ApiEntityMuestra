using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UberViajesApiEntity.Models;

namespace UberViajesApiEntity.Data
{
    public class UberViajesApiEntityContext : DbContext
    {
        public UberViajesApiEntityContext (DbContextOptions<UberViajesApiEntityContext> options)
            : base(options)
        {
        }

        public DbSet<Auto> Autos{ get; set; }
        public DbSet<DatosPersonales> DatosPersonales { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Entrega> entregas { get; set; }
        public DbSet<MetodoDePago> MetodosDePago { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<ClaseDeRegistro> ClasesRegistros { get; set; }
    }
}
