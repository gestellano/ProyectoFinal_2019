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
	public partial class ModificarCliente : ContentPage
	{
		public ModificarCliente (int Rut, String NombreEmp, String Direccion, String Telefono, String Ciudad)
		{
            try
            {
                InitializeComponent();
                int RutConv = Convert.ToInt32(pRut.Text);
                RutConv = Rut;
                pRut.Text = Convert.ToString(Rut.ToString());
               
                pNombreEmp.Text = NombreEmp;
                pDireccion.Text = Direccion;
                pTelefono.Text = Telefono;
                pCiudad.Text = Ciudad;

                btnConfirmar.Clicked += BtnConfirmar_Clicked;
                btnCancelar.Clicked += BtnCancelar_Clicked;
            }
            catch
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
         
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new MenuHamburguesa());
            }
            catch (Exception ex)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnConfirmar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(pNombreEmp.Text) || string.IsNullOrEmpty(pDireccion.Text)
              || string.IsNullOrEmpty(pTelefono.Text) || string.IsNullOrEmpty(pCiudad.Text))
                {
                    DisplayAlert("Error", "Todos los campos son obligatorios", "Aceptar");

                }
                else
                {

                    LogicaServicios obj = new LogicaServicios();
                    obj.ModificarCliente(pRut.Text, pNombreEmp.Text, pDireccion.Text, pTelefono.Text, pCiudad.Text);                    
                   Navigation.PushAsync(new PantallaExito());
                }
            }
            catch
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }

          
        }
    }
}