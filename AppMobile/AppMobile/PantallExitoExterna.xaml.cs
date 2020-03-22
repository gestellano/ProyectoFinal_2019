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
	public partial class PantallExitoExterna : ContentPage
	{
		public PantallExitoExterna ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
            btnIngresar.Clicked += BtnIngresar_Clicked;
        }

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Acceso.Acceso());
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

    }
}