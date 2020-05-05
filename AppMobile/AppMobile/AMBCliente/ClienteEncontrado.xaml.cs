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
	public partial class ClienteEncontrado : ContentPage
	{
        string usuario;
		public ClienteEncontrado(string rut, string nombreEmp, string direccion, string telefono, string ciudad)
        {
            try
            {
                InitializeComponent();
                lblRut.Text = Convert.ToString(rut);
                lblNombreEmp.Text = nombreEmp;
                lblDireccion.Text = direccion;
                lblTelefono.Text = telefono;
                lblCiudad.Text = ciudad;

                btnCancelar.Clicked += BtnCancelar_Clicked;
                btnModificar.Clicked += BtnModificar_Clicked;
            }
            catch
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnModificar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new ModificarCliente((Convert.ToInt32(lblRut.Text)), lblNombreEmp.Text, lblDireccion.Text, lblTelefono.Text, lblCiudad.Text, usuario));
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
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}