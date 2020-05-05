using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.RegistroVendedor
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CodigoSeguridadRegistro : ContentPage
	{
		public CodigoSeguridadRegistro ()
		{
            try
            {
                InitializeComponent();
                btnContinuar.Clicked += BtnContinuar_Clicked;
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
			

            
		}

        private void BtnContinuar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(lblCodigo.Text.Trim() == "")
                {
                    DisplayAlert("", "Debe de ingresar el código de seguridad.", "Aceptar");
                }
                else { 
                LogicaServicios obj = new LogicaServicios();
                string result = obj.CodigoSeguridad("1");
                 result = result.Remove(0, 1);
                 string result1 = result.Remove(result.Length - 1);
                    
                 if (result1 == lblCodigo.Text.Trim())
                {
                    Navigation.PushAsync(new BuscarVendedor());
                }
                else
                {
                    DisplayAlert("", "Código de seguridad incorrecto.", "Aceptar");
                }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}