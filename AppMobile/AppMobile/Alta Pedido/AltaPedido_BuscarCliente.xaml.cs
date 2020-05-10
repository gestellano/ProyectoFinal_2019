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
	public partial class AltaPedido_BuscarCliente : ContentPage
	{
		public AltaPedido_BuscarCliente()
		{
            try
            {
                InitializeComponent();
                btnBuscar.Clicked += BtnBuscar_Clicked;
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
			     
		}

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (lblRut.Text == null || lblRut.Text.Trim() == "")
                {
                    DisplayAlert("", "RUT es obligatorio", "Aceptar");
                }
                else
                {
                    int rutEmpresa = Convert.ToInt32(lblRut.Text.Trim());

                    LogicaServicios obj = new LogicaServicios();
                    string result = obj.BuscarCliente(rutEmpresa);

                    if (result.Length > 1)
                    {
                        result = result.Substring(1, result.Length - 2);
                    }

                    if (result.Length == 0)
                    {
                        DisplayAlert("", "No existe el cliente", "Aceptar");
                    }
                    else
                    {
                        Dictionary<string, string> dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);

                        Navigation.PushAsync(new ConfeccionPedido(dictionary["rut"], dictionary["nombreEmp"] ));
                    }
                }
            }
            catch (Exception )
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}