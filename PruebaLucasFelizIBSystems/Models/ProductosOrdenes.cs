using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaLucasFelizIBSystems.Models
{
    public class ProductosOrdenes
    {
        [Key]
        public int IdProductoOrden { get; set; }
        public Ordenes Orden { get; set; }
        public Productos Producto { get; set; }
    }
}