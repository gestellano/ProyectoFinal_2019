﻿using Newtonsoft.Json;
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
        public String BuscarCliente(int Rut)
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
                        client.BaseAddress = new Uri("http://10.0.2.2/api");
                        
                        Dictionary<string, string> jsonValues = new Dictionary<string, string>();
                        jsonValues.Add("Rut", Rut);
                        jsonValues.Add("Nombre", NombreEmp);
                        jsonValues.Add("Direccion", Direccion);
                        jsonValues.Add("Ciudad", Ciudad);
                        jsonValues.Add("Telefono", Telefono);

                        var serialized = JsonConvert.SerializeObject(jsonValues);
                        //HttpContent sc = new StringContent(JsonConvert.SerializeObject(jsonValues), UnicodeEncoding.UTF8, "application/json");
                        var result = await client.PostAsJsonAsync("/Cliente/AgregarCliente/", jsonValues);
                        int a = 0;
                        //HttpResponseMessage response = await client.PostAsync("/Cliente/AgregarCliente/", sc);                       
                  
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
