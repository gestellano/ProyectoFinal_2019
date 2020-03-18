using Plugin.Messaging;
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
	public partial class Contactos : ContentPage
	{
		public Contactos ()
		{
			InitializeComponent ();
            var call = CrossMessaging.Current.PhoneDialer;
            
                call.CanMakePhoneCall("098977344");
            


        }
	}
}