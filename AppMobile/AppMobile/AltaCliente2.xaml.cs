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
	public partial class AltaCliente2 : ContentPage
	{
		public AltaCliente2 (int Rut, String NombreEmp, String Direccion, String Telefono, String Ciudad)
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
                btnConfirmar.Clicked += BtnConfirmar_Clicked;
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }
     
 
        }

        private void BtnConfirmar_Clicked(object sender, EventArgs e)
        {
            try
            {              

                //LLAMAR AL logica
                Navigation.PushAsync(new AltaClienteExito());
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