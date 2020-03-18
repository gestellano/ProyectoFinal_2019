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
	public partial class BuscarVendedor : ContentPage
	{
		public BuscarVendedor ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);

        }
	}
}