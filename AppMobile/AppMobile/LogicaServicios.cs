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
                    string urlRe = "http://10.0.2.2:4425/api/Cliente/BuscarCliente?" + "rut=" + rutString;
                    WebClient wc = new WebClient();

                    response = wc.DownloadString(urlRe);
               
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
                        string urlRe = "http://10.0.2.2:4425/api/Cliente/AgregarCliente?" + "rut=" + rut +
                                                                                            "&nombre=" + nombreEmp + 
                                                                                            "&direccion=" + direccion +
                                                                                            "&ciudad=" + ciudad + 
                                                                                            "&telefono=" + telefono;

                        WebClient wc = new WebClient();
                        wc.DownloadString(urlRe);
                       
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
                    string urlRe = "http://10.0.2.2:4425/api/EspecificacionArticulo/BuscarArticulo?" + "codigo=" + codigo;
                    WebClient wc = new WebClient();

                    response = wc.DownloadString(urlRe);

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            return response;
        }
        
        //AltaPedido
        public void AltaPedido(string rut, string fecha, string estadoImpresion, string vendedor, string tipoEnvio)
        {            
                try
                {
                    using (var client = new HttpClient())
                    {  
                        client.BaseAddress = new Uri(baseUrl);
                        string urlRe = "http://10.0.2.2:4425/api/Pedido/AltaPedido?" + "rutCliente=" + rut +
                                                                                            "&fecha=" + fecha +
                                                                                            "&estadoImpresion=" + estadoImpresion +
                                                                                            "&vendedor=" + vendedor +
                                                                                            "&tipoEnvio=" + tipoEnvio;
                        WebClient wc = new WebClient();
                        wc.DownloadString(urlRe);

                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.ToString());

                }

            
        }


    }
}
