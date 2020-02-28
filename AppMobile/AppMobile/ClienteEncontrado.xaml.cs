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
		public ClienteEncontrado(String rut, String nombreEmp, String direccion, String telefono, String ciudad)
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