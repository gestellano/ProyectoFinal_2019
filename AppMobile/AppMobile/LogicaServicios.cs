﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMobile
{
    public class LogicaServicios
    {
        private String baseUrl = "http://192.168.1.45:4425";
        
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
        public async void AgregarCliente(String Rut, String NombreEmp, String Direccion, String Telefono, String Ciudad) 
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

                  string url = baseUrl + "/api/Cliente";
                        //String datos =rut=" + Rut + "&nombre=" + NombreEmp + "&direccion=" + Direccion + "&ciudad=" + Ciudad + "&telefono=" + Telefono;
                        // client.BaseAddress = new Uri(url);

                        // HttpContent text = new StringContent("{\"Rut\": \"999999999\", \"Nombre\": \"asdf\",\"Direccion\": \"adsfasdf\",\"Ciudad\": \"fffffff\",\"Telefono\": \"123\"}", Encoding.UTF8, "application/json");

                        //   var pepe = await client.PostAsync(url, text);

                        Dictionary<string, string> jsonValues = new Dictionary<string, string>();
                        jsonValues.Add("Rut", "12341234");
                        jsonValues.Add("Nombre", "pepe");
                        jsonValues.Add("Direccion", "pepe");
                        jsonValues.Add("Ciudad", "pepe");
                        jsonValues.Add("Telefono", "099345674");

                        //HttpClient client = new HttpClient();


                        HttpContent sc = new StringContent(JsonConvert.SerializeObject(jsonValues), UnicodeEncoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(url + "/AgregarCliente", sc);

                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Resultado: " + content);

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
