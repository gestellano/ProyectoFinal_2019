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
	public partial class ProductoEncontrado : ContentPage
	{
		public ProductoEncontrado (string codigo, string nombre, string descripcion)
		{
			InitializeComponent ();

            lblCodigo.Text = codigo;
            lblNombre.Text = nombre;
            lblDescripcion.Text = descripcion;


            btnBuscarOtroProducto.Clicked += BtnBuscarOtroProducto_Clicked;
            btnInicio.Clicked += BtnInicio_Clicked;
		}

        private void BtnInicio_Clicked(object sender, EventArgs e)
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

        private void BtnBuscarOtroProducto_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new BuscarProducto());
            }
            catch (Exception ex)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
           
        }
    }
}