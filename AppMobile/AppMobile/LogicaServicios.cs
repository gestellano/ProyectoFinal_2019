using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMobile
{
    public class LogicaServicios
    {
        private String baseUrl = "http://localhost:4425";
        //Buscar Cliente
        public String BuscarCliente(int Rut)
        {
            string rut = Convert.ToString(Rut);

            String json = null;

            //INVOCAR SERVICIO REST

            return json;
            
        }


        //Agregar Cliente
        public void AgregarCliente(int Rut, String NombreEmp, String Direccion, String Telefono, String Ciudad)
        {
            if (string.IsNullOrEmpty(NombreEmp) || string.IsNullOrEmpty(Direccion)
                     || string.IsNullOrEmpty(Telefono) || string.IsNullOrEmpty(Ciudad))
            {
                throw new Exception("Todos los campos son obligatorios");
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl + "/api/Base?rut=8888&nombre=sol&direccion=ignacionunez&ciudad=montevideo&telefono=099");

                  //  var cliente = new {Rut=Rut, NombreEmp = NombreEmp, Direccion = Direccion, Telefono = Telefono, Ciudad = Ciudad};
                  //  client.BaseAddress = new Uri(baseUrl + "/api/Cliente");
                 //   var postTask = client.PostAsJsonAsync("cliente", cliente);
                    // var postTask = client.PostAsync("cliente");
               //     postTask.Wait();


                    //var result = postTask.Result;
                    //if (result.IsSuccessStatusCode)
                    //{

                  //  }
                }
            }
        }

        

    }
}
