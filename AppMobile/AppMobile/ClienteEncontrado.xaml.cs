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
		public ClienteEncontrado(int Rut, String NombreEmp, String Direccion, String Telefono, String Ciudad)
        {
            try
            {
                InitializeComponent();
                
                lblRut.Text = Convert.ToString(Rut);
                lblNombreEmp.Text = NombreEmp;
                lblDireccion.Text = Direccion;
                lblTelefono.Text = Telefono;
                lblCiudad.Text = Ciudad;


                btnCancelar.Clicked += BtnCancelar_Clicked;
                btnModificar.Clicked += BtnModificar_Clicked;
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }
   

        }

        private void BtnModificar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new ModificarCliente((Convert.ToInt32(lblRut.Text)), lblNombreEmp.Text, lblDireccion.Text, lblTelefono.Text, lblCiudad.Text));
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }

            
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {

        }

    }
}