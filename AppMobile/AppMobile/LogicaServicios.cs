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
        private string baseUrl = "http://10.0.2.2:4425/api";

        //Buscar Cliente
        public string BuscarCliente(int Rut)
        {
            string response = "";
            try
            {
                string rutString = Convert.ToString(Rut);
                //string url = "/Cliente/BuscarCliente?rut=54";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    string BuscarCliente = "http://10.0.2.2:4425/api/Cliente/BuscarCliente?" + "rut=" + rutString;
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

                        string url = baseUrl + "/api/Cliente";
                        client.BaseAddress = new Uri("http://10.0.2.2/api");
                        
                     
                        client.BaseAddress = new Uri(baseUrl);
                        string urlAgregarCliente = "http://10.0.2.2:4425/api/Cliente/AgregarCliente?" + "rut=" + rut +
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
                    client.BaseAddress = new Uri(baseUrl);
                    string urlBuscarArticulo = "http://10.0.2.2:4425/api/EspecificacionArticulo/BuscarArticulo?" + "codigo=" + codigo;
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
                     client.BaseAddress = new Uri(baseUrl);
                     string urlAltaPedido = "http://10.0.2.2:4425/api/Pedido/AltaPedido?" + "rutCliente=" + rut +
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

                        string urlAltaLineaPedido = "http://10.0.2.2:4425/api/Pedido/AltaLineaPedido?" + "codigo=" + codigoArticulo +
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

                        string url = baseUrl + "/api/Cliente";
                        client.BaseAddress = new Uri("http://10.0.2.2/api");

                        string modificar = "S";
                        client.BaseAddress = new Uri(baseUrl);
                        string urlModificarCliente = "http://10.0.2.2:4425/api/Cliente/ModificarCliente?" + "&rut=" + rut +
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


    }
}
