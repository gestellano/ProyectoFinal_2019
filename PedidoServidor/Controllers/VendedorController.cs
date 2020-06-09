using PedidoServidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;


namespace PedidoServidor.Controllers
{
    public class VendedorController : ApiController
    {
        //Buscar Vendedor
        [HttpGet]
        public string BuscarVendedor(string nickname)
        {
            using (var context = new BaseDeDatosContext())
            {
                var vend = context.Vendedores.Find(nickname);
                if (vend == null)
                {
                    return string.Empty;
                }
                else
                {
                    return "nickname=" + vend.Nickname + ";" +
                           "nombre=" + vend.Nombre + ";" +
                           "celular=" + vend.Celular + ";" +
                           "zonatrabajo=" + vend.ZonaTrabajo + ";" +
                           "tienevechiulo=" + vend.TieneVehiculo + ";" +
                           "mail=" + vend.Mail + ";" +
                           "password=" + vend.Password;
                }
            }
        }

        //AltaVendedor
        [HttpGet]
        public void AgregarVendedor(string nombre, string mail, string celular, string nickname, string password,string zonaTrabajo, bool tieneVehiculo)
        {
            BaseDeDatosContext context = new BaseDeDatosContext();
            context.Vendedores.Add(new Vendedor() { Nombre = nombre, Mail=mail,Celular=celular,Nickname=nickname,Password=password,ZonaTrabajo=zonaTrabajo,TieneVehiculo=tieneVehiculo });
            context.SaveChanges();

        }


        //Modificar Vendedor
        [HttpGet]
        public void ModificarVendedor(string nombre, string mail, string celular, string nickname, string password, string zonaTrabajo, bool tieneVehiculo, string modificar)
        {
            BaseDeDatosContext context2 = new BaseDeDatosContext();
            var VendModif = context2.Vendedores.Find(nickname);
            
            VendModif.Celular = celular;
            VendModif.Mail = mail;
            VendModif.Nombre = nombre;
            VendModif.Password = password;
            VendModif.TieneVehiculo = tieneVehiculo;
            VendModif.ZonaTrabajo = zonaTrabajo;
            context2.SaveChanges();
        }

        //Cambiar Contraseña Vendedor
        [HttpGet]
        public void CambiarContrasena(string nickname, string password)
        {
            BaseDeDatosContext context = new BaseDeDatosContext();
            var VendModif = context.Vendedores.First<Vendedor>();
            VendModif.Nickname = nickname;
            VendModif.Password = password;
            context.SaveChanges();
        }



    }
}
