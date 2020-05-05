
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ABMClientes : ContentPage
	{
        string usuario;
		public ABMClientes ()
		{
            try
            {
                InitializeComponent();  
                btnCancelar.Clicked += BtnCancelar_Clicked;
                btnBuscar.Clicked += BtnBuscar_Clicked;
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }

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

                    if(result.Length == 0)
                    { 
                            Navigation.PushAsync(new AltaCliente1(rutEmpresa, usuario));
                    }
                    else
                    {               
                        Dictionary<string, string> dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);
    
                        Navigation.PushAsync(new ClienteEncontrado(dictionary["rut"], dictionary["nombreEmp"], dictionary["direccion"], dictionary["telefono"], dictionary["ciudad"]));
                    }
                }
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new MenuHamburguesa());
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}