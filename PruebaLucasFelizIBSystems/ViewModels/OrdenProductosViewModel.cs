using PruebaLucasFelizIBSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLucasFelizIBSystems.ViewModels
{
    public class OrdenProductosViewModel
    {
        public Ordenes Orden { get; set; }
        public string EstatusOrden { get; set; }
        public ProductoImagenesViewModel ProductoImagenesViewModel { get; set; }
    }
}