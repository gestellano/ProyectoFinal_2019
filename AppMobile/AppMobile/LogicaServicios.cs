using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobile
{
    public class LogicaServicios
    {
        public void AgregarCliente(int Rut, String NombreEmp, String Direccion, String Telefono, String Ciudad)
        {
            if (string.IsNullOrEmpty(NombreEmp) || string.IsNullOrEmpty(Direccion)
                     || string.IsNullOrEmpty(Telefono) || string.IsNullOrEmpty(Ciudad))
            {
                throw new Exception("Todos los campos son obligatorios");
            }
            else
            {
               
                //INVOCAR SERVICIO REST
            }
        }

    }
}
