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
	public partial class PantallaExito : ContentPage
	{
		public PantallaExito ()
		{
			InitializeComponent ();
            btnInicio.Clicked += BtnInicio_Clicked;

            NavigationPage.SetHasBackButton(this, false);
        }

        private void BtnInicio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaInicioxaml());
        }
    }
}