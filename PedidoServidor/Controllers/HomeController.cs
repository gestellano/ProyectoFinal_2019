using PedidoServidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PedidoServidor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            /*
            BaseDeDatosContext context = new BaseDeDatosContext();
            context.Clientes.Add(new Cliente() { Rut = "5554445", NombreEmp = "Casp",Direccion = "Ale", Telefono ="123123", Ciudad = "ddd"});
            context.SaveChanges();
            */

            return View();
        }



    }
}
