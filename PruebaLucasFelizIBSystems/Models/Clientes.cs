using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaLucasFelizIBSystems.Models
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }

        public string Nombres { get; set; } 

        public string Apellidos { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public bool Inactivo { get; set; }
    }
}