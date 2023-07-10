using PruebaLucasFelizIBSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLucasFelizIBSystems.ViewModels
{
    public class ProductoImagenesViewModel
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public float Cantidad { get; set; }
        public bool Inactivo { get; set; }
        public IEnumerable<HttpPostedFileBase> Imagenes { get; set; }
        public IEnumerable<ImagenesProducto> ImagenesProducto { get; set; }
    }
}