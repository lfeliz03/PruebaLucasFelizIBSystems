using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaLucasFelizIBSystems.Models
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext() : base("name=PruebaLucasFelizIBSystemsCS")
        {
            
        }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ImagenesProducto> ImagenesProducto { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
    }
}