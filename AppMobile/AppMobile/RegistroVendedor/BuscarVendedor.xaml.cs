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
            try
            {
               if(lblNickName.Text.Trim() == "")
                {
                    DisplayAlert("", "Debe de ingresar el usuario.", "Aceptar");
                }
                else
                {
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
                        DisplayAlert("", "Usuario ya se encuentra registrado.", "Aceptar");
                    }
                }
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
            
        }
    }
}