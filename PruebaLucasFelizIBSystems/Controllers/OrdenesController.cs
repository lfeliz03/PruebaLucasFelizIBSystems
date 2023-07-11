using PruebaLucasFelizIBSystems.Models;
using PruebaLucasFelizIBSystems.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaLucasFelizIBSystems.Controllers
{
    public class OrdenesController : Controller
    {
        AplicationDbContext context = new AplicationDbContext();
        // GET: Ordenes
        public ActionResult Index()
        {
            //var ordenes = ;
            //List<OrdenesViewModel> ordenesViewModel = new List<OrdenesViewModel>();
            //foreach (var orden in ordenes)
            //{
            //    OrdenesViewModel ordenViewModel = new OrdenesViewModel();
            //    ordenViewModel.Orden = orden;
            //    ordenViewModel.EstatusOrden = "";
            //    ordenesViewModel.Add(ordenViewModel);
            //}
            return View(context.Ordenes.ToList());
        }
        public ActionResult Detalles(int? idOrden)
        {
            return View();
        }
        public ActionResult Crear()
        {
            var clientes = context.Clientes.Where(c => !c.Inactivo).ToList();
            List<SelectListItem> lstClientes = new List<SelectListItem>();
            foreach (var cliente in clientes)
            {
                lstClientes.Add(new SelectListItem()
                {
                    Text = cliente.Nombres + " " + cliente.Apellidos,
                    Value = cliente.IdCliente.ToString()
                });
            }
            ViewBag.Clientes = lstClientes;
            return View();
        }
        //public ActionResult Crear()
        //{
        //    return View();
        //}
    }
}