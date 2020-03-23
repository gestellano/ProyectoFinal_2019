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
        public BuscarVendedor()
        {
            InitializeComponent();
            btnBuscar.Clicked += BtnBuscar_Clicked;

        }

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
            LogicaServicios obj = new LogicaServicios();
            string result = obj.BuscarVendedor(lblNickName.Text.Trim());

            if (result.Length > 1)
            {
                result = result.Substring(1, result.Length - 2);
            }

            if (result.Length == 0)
            {

                Navigation.PushAsync(new RegistroVendedorIngresoDatos(lblNickName.Text.Trim()));

            }
            else
            {
                DisplayAlert("", "Nickname ya se encuentra registrado.", "Aceptar");

            }

            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;

        }
    }
}