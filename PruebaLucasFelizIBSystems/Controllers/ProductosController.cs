using System.Data.Entity;
using PruebaLucasFelizIBSystems.Models;
using PruebaLucasFelizIBSystems.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PruebaLucasFelizIBSystems.Controllers
{
    public class ProductosController : Controller
    {

        private AplicationDbContext context = new AplicationDbContext();

        // GET: Productos
        public ActionResult Index()
        {
            return View(context.Productos.ToList());
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ProductoImagenesViewModel producto)
        {
            if (ModelState.IsValid)
            {
                Productos productoAInsertar = new Productos()
                {
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Costo = producto.Costo,
                    Precio = producto.Precio,
                    Cantidad = producto.Cantidad,
                    Inactivo = producto.Inactivo
                };
                context.Productos.Add(productoAInsertar);
                context.SaveChanges();
                if (producto.Imagenes.ToList().Count > 0)
                {
                    foreach (var imagen in producto.Imagenes)
                    {
                        ImagenesProducto imagenProducto = new ImagenesProducto();
                        byte[] imagenBytes;
                        using (var reader = new BinaryReader(imagen.InputStream))
                        {
                            imagenBytes = reader.ReadBytes(imagen.ContentLength);
                            imagenProducto.Producto = productoAInsertar;
                            imagenProducto.Imagen = imagenBytes;
                        }
                        context.ImagenesProducto.Add(imagenProducto);
                        context.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            return View(producto);
        }
        public ActionResult Editar(int? idProducto)
        {
            if (idProducto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos producto = context.Productos.Find(idProducto);
            if (producto == null)
            {
                return HttpNotFound();
            }
            IEnumerable<ImagenesProducto> imagenesProducto = context.ImagenesProducto.Where(i => i.Producto.IdProducto == idProducto).ToList();
            ProductoImagenesViewModel productoImagenesViewModel = new ProductoImagenesViewModel();
            productoImagenesViewModel.IdProducto = producto.IdProducto;
            productoImagenesViewModel.Nombre = producto.Nombre;
            productoImagenesViewModel.Descripcion = producto.Descripcion;
            productoImagenesViewModel.Costo = producto.Costo;
            productoImagenesViewModel.Precio = producto.Precio;
            productoImagenesViewModel.Cantidad = producto.Cantidad;
            productoImagenesViewModel.Inactivo = producto.Inactivo;
            productoImagenesViewModel.ImagenesProducto = imagenesProducto;
            return View(productoImagenesViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ProductoImagenesViewModel producto)
        {
            if (ModelState.IsValid)
            {
                Productos productoAInsertar = new Productos()
                {
                    IdProducto = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Costo = producto.Costo,
                    Precio = producto.Precio,
                    Cantidad = producto.Cantidad,
                    Inactivo = producto.Inactivo
                };
                context.Entry(productoAInsertar).State = EntityState.Modified;
                context.SaveChanges();
                if (producto.Imagenes.ToList().Count > 0)
                {
                    if (producto.Imagenes.ToList()[0] != null)
                    {
                        var imagenesProducto = context.ImagenesProducto
                            .Where(i => i.Producto.IdProducto == producto.IdProducto).ToList();
                        context.ImagenesProducto.RemoveRange(imagenesProducto);
                        context.SaveChanges();
                        foreach (var imagen in producto.Imagenes)
                        {
                            ImagenesProducto imagenProducto = new ImagenesProducto();
                            byte[] imagenBytes;
                            using (var reader = new BinaryReader(imagen.InputStream))
                            {
                                imagenBytes = reader.ReadBytes(imagen.ContentLength);
                                imagenProducto.Producto = productoAInsertar;
                                imagenProducto.Imagen = imagenBytes;
                            }
                            context.ImagenesProducto.Add(imagenProducto);
                            context.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            return View(producto);
        }
        public ActionResult Detalles(int? idProducto)
        {
            if (idProducto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = context.Productos.Where(p => p.IdProducto == idProducto).FirstOrDefault();
            if (producto == null)
            {
                return HttpNotFound();
            }
            IEnumerable<ImagenesProducto> imagenesProducto = context.ImagenesProducto
                .Where(i => i.Producto.IdProducto == idProducto).ToList();
            ProductoImagenesViewModel productoImagenesViewModel = new ProductoImagenesViewModel();
            productoImagenesViewModel.IdProducto = producto.IdProducto;
            productoImagenesViewModel.Nombre = producto.Nombre;
            productoImagenesViewModel.Descripcion = producto.Descripcion;
            productoImagenesViewModel.Costo = producto.Costo;
            productoImagenesViewModel.Precio = producto.Precio;
            productoImagenesViewModel.Cantidad = producto.Cantidad;
            productoImagenesViewModel.Inactivo = producto.Inactivo;
            productoImagenesViewModel.ImagenesProducto = imagenesProducto;
            return View(productoImagenesViewModel);
        }
    }
}