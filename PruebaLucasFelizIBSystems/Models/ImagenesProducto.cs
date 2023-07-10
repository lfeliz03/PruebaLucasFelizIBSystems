using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaLucasFelizIBSystems.Models
{
    public class ImagenesProducto
    {
        [Key]
        public int IdImagenProducto { get; set; }
        public Productos Producto { get; set; }
        [Column(TypeName = "image")]
        public byte[] Imagen { get; set; }
    }
}