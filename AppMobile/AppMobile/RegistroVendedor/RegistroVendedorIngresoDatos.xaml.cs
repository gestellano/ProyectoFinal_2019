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
	public partial class RegistroVendedorIngresoDatos : ContentPage
	{
		public RegistroVendedorIngresoDatos (string nickname)
		{
            try
            {
                InitializeComponent();
                lblNickName.IsEnabled = false;
                lblNickName.Text = nickname;

                List<string> TieneVehiculoList = new List<string>();
                TieneVehiculoList.Add("Si");
                TieneVehiculoList.Add("No");
                TieneVehiculo.ItemsSource = TieneVehiculoList;

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
                bool tieneVeh;

                if (string.IsNullOrEmpty(lblNombre.Text.Trim()) || string.IsNullOrEmpty(lblemail.Text.Trim())
                    || string.IsNullOrEmpty(lblcelular.Text.Trim()) || string.IsNullOrEmpty(lblZonaTrabajo.Text.Trim())
                    || string.IsNullOrEmpty(lblPassword.Text.Trim()) || string.IsNullOrEmpty(lblPassword1.Text.Trim()))
                {
                    DisplayAlert("", "Todos los campos son obligatorios *", "Aceptar");
                }
                else if(TieneVehiculo.SelectedItem == null)
                {
                    DisplayAlert("", "Debe de seleccionar si posee vehíclo o no.", "Aceptar");
                }
                else if(lblPassword.Text.Trim().Length < 8)
                {
                    DisplayAlert("", "La contraseña debe de contener al menos 8 caracteres.", "Aceptar");
                }
                else if (lblPassword.Text.Trim() != lblPassword1.Text.Trim())
                {
                    DisplayAlert("", "Las contraseñas ingresadas no coinciden.", "Aceptar");
                }
                else
                {
                    if (TieneVehiculo.SelectedItem.ToString() == "Si")
                    {
                        tieneVeh = true;
                    }
                    else
                    {
                        tieneVeh = false;
                    }                    
                    LogicaServicios obj = new LogicaServicios();
                    obj.AgregarVendedor(lblNombre.Text.Trim(), lblemail.Text.Trim(), lblcelular.Text.Trim(), lblNickName.Text.Trim(), lblPassword.Text.Trim(), lblZonaTrabajo.Text.Trim(), tieneVeh);
                    Navigation.PushAsync(new PantallExitoExterna());
                }
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}