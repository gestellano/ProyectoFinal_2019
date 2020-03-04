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
		public AltaPedido_BuscarCliente ()
		{
			InitializeComponent ();
            btnBuscar.Clicked += BtnBuscar_Clicked;
		}

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (lblRut.Text == null || lblRut.Text.Trim() == "")
                {
                    DisplayAlert("Error", "RUT es obligatorios", "Aceptar");
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
                        Navigation.PushAsync(new AltaCliente1(rutEmpresa));
                    }
                    else
                    {
                        Dictionary<string, string> dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);

                        Navigation.PushAsync(new ConfeccionPedido(dictionary["rut"], dictionary["nombreEmp"]));
                    }

                }
            }
            catch (Exception )
            {

                throw new Exception();
            }
        }
    }
}