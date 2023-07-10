using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaLucasFelizIBSystems.Models
{
    public class Ordenes
    {
        [Key]
        public int IdOrden { get; set; }
        public Clientes Cliente { get; set; }
        public DateTime FechaHoraOrden { get; set; }
    }
}