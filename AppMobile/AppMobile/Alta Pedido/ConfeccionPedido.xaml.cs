using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Alta_Pedido
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfeccionPedido : ContentPage
	{
		public ConfeccionPedido(string rut, string nombreEmp)
        {
			InitializeComponent ();

            lblRut.Text = "RUT: "+rut;
            lblNombreEmpresa.Text = "Nombre Empresa: "+nombreEmp;

           
            string rutEmpresa = rut;

            btnBuscar.Clicked += BtnBuscar_Clicked;
            btnAgregarAlPedido.IsVisible = false;
            btnAgregarAlPedido.Clicked += BtnAgregarAlPedido_Clicked;
            btnEnviarPedido.Clicked += BtnEnviarPedido_Clicked;



		}

       
        private void BtnAgregarAlPedido_Clicked(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido un error en la app,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (lblCodigoBuscar.Text == null || lblCodigoBuscar.Text.Trim() == "")
                {

                    DisplayAlert("Alerta", "Codigo de producto obligatorio", "Aceptar");
                }
                else
                {

                    LogicaServicios obj = new LogicaServicios();
                    string result = obj.BuscarArticulio(lblCodigoBuscar.Text.Trim());

                    if (result.Length > 1)
                    {
                        result = result.Substring(1, result.Length - 2);
                    }

                    if (result.Length == 0)
                    {
                        DisplayAlert("", "Articulo no registrado", "Aceptar");                       
                    }
                    else
                    {
                        Dictionary<string, string> dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);
                        lblCodigo.Text = "Codigo: "+dictionary["codigo"];
                        lblArticulo.Text = "Nombre: "+dictionary["nombre"];
                        btnAgregarAlPedido.IsVisible = true;            
                        string codigoProducto = dictionary["codigo"];

                    }
                }
            }
            catch (Exception)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnEnviarPedido_Clicked(object sender, EventArgs e)
        {
            try
            {
                 string tipoEnvio = "express";
                string fechaActual = DateTime.Now.ToString();                
                bool estadoImpresionPedido = false;
                LogicaServicios obj = new LogicaServicios();
                obj.AltaPedido("222", fechaActual, estadoImpresionPedido, "10", tipoEnvio);
            }
            catch (Exception ex)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }



    }
}