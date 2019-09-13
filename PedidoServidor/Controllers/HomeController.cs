using PedidoServidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PedidoServidor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //BaseDeDatosContext context = new BaseDeDatosContext();
            //context.ListadoUsuario.Add(new Usuario() { Numero = 345, Nickname = "Casp", Nombre = "Ale", Celular = "099", Mail = "ddd", Password = "ggggg" });
            //context.SaveChanges();
            return View();
        }



    }
}
