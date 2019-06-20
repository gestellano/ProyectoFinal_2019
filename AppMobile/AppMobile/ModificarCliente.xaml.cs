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
               
                pNombreEmp.Text = NombreEmp;
                pDireccion.Text = Direccion;
                pTelefono.Text = Telefono;
                pCiudad.Text = Ciudad;

                btnConfirmar.Clicked += BtnConfirmar_Clicked;
                btnCancelar.Clicked += BtnCancelar_Clicked;
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }
         
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            
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
                    //Inovocar a servicio
                    //Entidades.Cliente EmpresaModificada = new Entidades.Cliente((Convert.ToInt32(pRut.Text)), pNombreEmp.Text, pDireccion.Text, pTelefono.Text, pCiudad.Text);

                    Navigation.PushAsync(new PantallaExito());
                }
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }

          
        }
    }
}