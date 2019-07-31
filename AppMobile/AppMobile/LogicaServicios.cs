using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobile
{
    public class LogicaServicios
    {
        //Buscar Cliente
        public String BuscarCliente(int Rut)
        {
            string rut = Convert.ToString(Rut);

            //INVOCAR SERVICIO REST

            String json = null;


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
                object[] cliente = new object[] { Rut, NombreEmp, Direccion,Telefono,Ciudad};

                string json = JsonConvert.SerializeObject(cliente);

                //INVOCAR SERVICIO REST

                
            }
        }

        

    }
}
