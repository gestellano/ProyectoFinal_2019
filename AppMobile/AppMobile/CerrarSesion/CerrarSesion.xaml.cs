using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.CerrarSesion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CerrarSesion : ContentPage
	{
        public CerrarSesion()
        {
            try
            {
                InitializeComponent();
                btnNo.Clicked += BtnNo_Clicked;
                btnSi.Clicked += BtnSi_Clicked;
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnSi_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Mail = null;
                App.Usuario = null;
                App.NumeroCelular = null;
                App.Password = null;
                
                Navigation.PushAsync(new Acceso.Acceso());
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnNo_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new PaginaInicioxaml());
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}