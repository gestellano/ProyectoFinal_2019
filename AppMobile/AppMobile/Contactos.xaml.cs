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
          
            btnOscal.Clicked += BtnOscal_Clicked;
            btnAdmin.Clicked += BtnAdmin_Clicked;            
            btnCelularOscar.Clicked += BtnCelularOscar_Clicked;
            btnAnaliaGonzalez.Clicked += BtnAnaliaGonzalez_Clicked;
            btnGonzaloLopez.Clicked += BtnGonzaloLopez_Clicked;
        }

        private void BtnGonzaloLopez_Clicked(object sender, EventArgs e)
        {
            try
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                    phoneDialer.MakePhoneCall("094258369");
            }
            catch (Exception)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnAnaliaGonzalez_Clicked(object sender, EventArgs e)
        {
            try
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                    phoneDialer.MakePhoneCall("098452145");
            }
            catch (Exception)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnCelularOscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                    phoneDialer.MakePhoneCall("25023696");
            }
            catch (Exception)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnAdmin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                    phoneDialer.MakePhoneCall("25023696");
            }
            catch (Exception)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnOscal_Clicked(object sender, EventArgs e)
        {
            try
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                    phoneDialer.MakePhoneCall("24004020");
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
           
        }

       
    }
}