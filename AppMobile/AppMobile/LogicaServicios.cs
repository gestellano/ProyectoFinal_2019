using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMobile
{
    public class LogicaServicios
    {
        private String baseUrl = "http://localhost:4425";
        
        //Buscar Cliente
        public async Task BuscarCliente(int Rut)
        {
            string rut = Convert.ToString(Rut);

            String json = null;
            try
            {
                using (var client = new HttpClient())
                {

                    //client.BaseAddress = new Uri(baseUrl);
                    Console.WriteLine("gaston" + "WriteLine");
                    var response = client.GetAsync("https://jsonplaceholder.typicode.com/todos/1").Result;
                    Console.WriteLine("jimena"+response + "jimena");

                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            
        }

        

        //Agregar Cliente
        public async Task AgregarCliente(String Rut, String NombreEmp, String Direccion, String Telefono, String Ciudad) 
        { 
            if (string.IsNullOrEmpty(NombreEmp) || string.IsNullOrEmpty(Direccion)
                     || string.IsNullOrEmpty(Telefono) || string.IsNullOrEmpty(Ciudad))
            {
                throw new Exception("Todos los campos son obligatorios");
            }
            else
            {
                try
                {
                    using (var client = new HttpClient())
                    {

                        string url = baseUrl + "/api/Cliente?rut=" + Rut + "&nombre=" + NombreEmp + "&direccion=" + Direccion + "&ciudad=" + Ciudad + "&telefono=" + Telefono;
                     //   client.BaseAddress = new Uri(url);

                        HttpContent text = new StringContent("", Encoding.UTF8, "application/json");

                       var pepe = client.PostAsync(url, text);

                    }
                }
                catch (Exception ex)
                {

                    throw new Exception( ex.ToString());

                }

            }
        }

        

    }
}
