
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

                      if(  String.IsNullOrEmpty(result))
                       {
                            Navigation.PushAsync(new AltaCliente1(rutEmpresa));
                    }
                    else
                    {               
                        Dictionary<string, string> dictionary = result.Substring(1,result.Length -2).TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);
    
                        Navigation.PushAsync(new ClienteEncontrado(dictionary["rut"], dictionary["nombreEmp"], dictionary["direccion"], dictionary["telefono"], dictionary["ciudad"]));
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }

            
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaInicioxaml());
        }
    }
}