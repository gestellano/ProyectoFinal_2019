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
            InitializeComponent();

            try
            {
                //App.Usuario = null;
                //App.Password = null;
                //App.Mail = null;
                //App.NumeroCelular = null;
                Navigation.PushAsync(new Acceso.Acceso());
            }
            catch (Exception ex)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
	}
}