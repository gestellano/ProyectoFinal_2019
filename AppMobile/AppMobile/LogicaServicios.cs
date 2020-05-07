using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMobile
{
    public class LogicaServicios
    {
        //ip Emulador
        private string baseUrl = "http://10.0.2.2:4425";
      


        //Buscar Cliente
        public string BuscarCliente(int Rut)
        {
            string response = "";
            try
            {
                string rutString = Convert.ToString(Rut);

                using (var client = new HttpClient())
                {
                    
                    string BuscarCliente = baseUrl+"/api/Cliente/BuscarCliente?" + "rut=" + rutString;
                    WebClient wc = new WebClient();

                    response = wc.DownloadString(BuscarCliente);
               
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            return response;
        }



        //Agregar Cliente
        public void AgregarCliente(string rut, string nombreEmp, string direccion, string telefono, string ciudad) 
        { 
            if (string.IsNullOrEmpty(nombreEmp) || string.IsNullOrEmpty(direccion)
                     || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(ciudad))
            {
                throw new Exception("Todos los campos son obligatorios");
            }
            else
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        string urlAgregarCliente = baseUrl+"/api/Cliente/AgregarCliente?" + "rut=" + rut +
                                                                                            "&nombre=" + nombreEmp + 
                                                                                            "&direccion=" + direccion +
                                                                                            "&ciudad=" + ciudad + 
                                                                                            "&telefono=" + telefono;

                        WebClient wc = new WebClient();
                        wc.DownloadString(urlAgregarCliente);
                       
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception( ex.ToString());

                }

            }
        }


        //BuscarArticulo
        public string BuscarArticulio(string codigo)
        {
            string response = "";
            try
            {
             
                using (var client = new HttpClient())
                {
                    string urlBuscarArticulo = baseUrl +"/api/EspecificacionArticulo/BuscarArticulo?" + "codigo=" + codigo;
                    WebClient wc = new WebClient();

                    response = wc.DownloadString(urlBuscarArticulo);

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            return response;
        }
        
        //AltaPedido
        public void AltaPedido(string rut, DateTime fecha, int estadoImpresion, string vendedor, string tipoEnvio, Dictionary<string,int> listaArt)
        {            
                try
                {
                    using (var client = new HttpClient())
                    {                    
                     string urlAltaPedido = baseUrl + "/api/Pedido/AltaPedido?" + "rutCliente=" + rut +
                                                                                       "&fecha=" + fecha +
                                                                                       "&estadoImpresion=" + estadoImpresion +
                                                                                       "&vendedor=" + vendedor +
                                                                                       "&tipoEnvio=" + tipoEnvio;

                     WebClient wc = new WebClient();
                     wc.DownloadString(urlAltaPedido);


                    foreach (KeyValuePair<string, int> entry in listaArt)
                    {
                        int cantidadArticulo = Convert.ToInt32(entry.Value.ToString());
                        string codigoArticulo = entry.Key.ToString();
                        int idPedido = 1;

                        string urlAltaLineaPedido = baseUrl + "/api/Pedido/AltaLineaPedido?" + "codigo=" + codigoArticulo +
                                                                                      "&cantidad=" + cantidadArticulo +
                                                                                      "&idPedido=" + idPedido;

                        
                        wc.DownloadString(urlAltaLineaPedido);
                    }

                }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }            
        }



        //Modificar Cliente
        public void ModificarCliente(string rut,string nombreEmp, string direccion, string telefono, string ciudad)
        {
            if (string.IsNullOrEmpty(nombreEmp) || string.IsNullOrEmpty(direccion)
                     || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(ciudad))
            {
                throw new Exception("Todos los campos son obligatorios");
            }
            else
            {
                try
                {
                    using (var client = new HttpClient())
                    {                       
                        string modificar = "S";
                        string urlModificarCliente = baseUrl +"/api/Cliente/ModificarCliente?" + "&rut=" + rut +
                                                                                            "&nombre=" + nombreEmp +
                                                                                            "&direccion=" + direccion +
                                                                                            "&ciudad=" + ciudad +
                                                                                            "&telefono=" + telefono +
                                                                                            "&modificar="+ modificar;

                        WebClient wc = new WebClient();
                        wc.DownloadString(urlModificarCliente);

                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.ToString());

                }

            }
        }


        //Buscar Vendedor
        public string BuscarVendedor(string nickname)
        {
            string response = "";
            try
            {
             
                using (var client = new HttpClient())
                {
                    string LoginVendedor = baseUrl + "/api/Vendedor/Login?" + "nickname=" + nickname;
                    WebClient wc = new WebClient();

                    response = wc.DownloadString(LoginVendedor);

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            return response;
        }

        //Agregar Vendedor
        public void AgregarVendedor(string nombre, string mail, string celular, string nickname, string password, string zonaTrabajo, bool tieneVehiculo)
        {
            try
                {
                    using (var client = new HttpClient())
                    {

                        string urlAltaVendedor = baseUrl + "/api/Vendedor/AgregarVendedor?" + "Nombre=" + nombre +
                                                                                            "&Mail=" + mail +
                                                                                            "&Celular=" + celular +
                                                                                            "&NickName=" + nickname +
                                                                                            "&Password=" + password+
                                                                                            "&ZonaTrabajo="+zonaTrabajo+
                                                                                            "&TieneVehiculo="+tieneVehiculo;

                        WebClient wc = new WebClient();
                        wc.DownloadString(urlAltaVendedor);

                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.ToString());

                }            
        }

        //Modificar Vendedor
        public void ModificarVendedor(string nombre, string mail, string celular, string nickname, string password, string zonaTrabajo, bool tieneVehiculo, string modificar)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    

                    string urlModificarVendedor = baseUrl + "/api/Vendedor/ModificarVendedor?" + "Nombre=" + nombre +
                                                                                        "&Mail=" + mail +
                                                                                        "&Celular=" + celular +
                                                                                        "&NickName=" + nickname +
                                                                                        "&Password=" + password +
                                                                                        "&ZonaTrabajo=" + zonaTrabajo +
                                                                                        "&TieneVehiculo=" + tieneVehiculo +
                                                                                        "&Modificar="+modificar;

                    WebClient wc = new WebClient();
                    wc.DownloadString(urlModificarVendedor);

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }
        }


        //ModificarCliente
        public void CambiarContrasena(string nickname, string password)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    string urlCambiarContrasena = baseUrl + "/api/Vendedor/CambiarContrasena?" + "&NickName=" + nickname +
                                                                                                    "&Password=" + password;

                    WebClient wc = new WebClient();
                    wc.DownloadString(urlCambiarContrasena);

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }
        }


        //Buscar Codigo Seguridad
        public string CodigoSeguridad(string numCodigo)
        {
            string response = "";
            try
            {
                using (var client = new HttpClient())
                {
                    string BuscarCodigo = baseUrl + "/api/CodigoSeguridad/BuscarCodigoSeguridad?" + "numCodigo=" + numCodigo;
                    WebClient wc = new WebClient();

                    response = wc.DownloadString(BuscarCodigo);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            return response;
        }


    }
}
