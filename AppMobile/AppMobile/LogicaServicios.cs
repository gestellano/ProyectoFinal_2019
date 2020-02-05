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
        public async void BuscarCliente(int Rut)
        {


            try
            {
                string rutString = Convert.ToString(Rut);
                string url = baseUrl + "/api/Cliente/BuscarCliente/" + rutString;

                using (var client = new HttpClient())
                {

                    string result = await client.GetStringAsync(url);
                    //Q' hacemos ahora con result?                    
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
                        
                        Dictionary<string, string> jsonValues = new Dictionary<string, string>();
                        jsonValues.Add("Rut", Rut);
                        jsonValues.Add("Nombre", NombreEmp);
                        jsonValues.Add("Direccion", Direccion);
                        jsonValues.Add("Ciudad", Ciudad);
                        jsonValues.Add("Telefono", Telefono);
                     
                        HttpContent sc = new StringContent(JsonConvert.SerializeObject(jsonValues), UnicodeEncoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync("http://localhost:4425/api/Cliente/AgregarCliente/", sc);
                        
                        Console.WriteLine("Resultado: " + response.StatusCode);
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
