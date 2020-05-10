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
    public partial class BuscarProducto : ContentPage
    {
        string usuario;
        public BuscarProducto()
        {
            try
            {
                InitializeComponent();                
                btnBuscar.Clicked += BtnBuscar_Clicked;
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
            catch (Exception )
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (lblCodigo.Text == null || lblCodigo.Text.Trim() == "")
                {

                    DisplayAlert("", "Código de producto obligatorio", "Aceptar");
                }
                else
                {
                    LogicaServicios obj = new LogicaServicios();
                    string result = obj.BuscarArticulio(lblCodigo.Text.Trim());

                    if (result.Length > 1)
                    {
                        result = result.Substring(1, result.Length - 2);
                    }

                    if (result.Length == 0)
                    {
                        DisplayAlert("", "Artículo no registrado", "Aceptar");
                        Navigation.PushAsync(new BuscarProducto());
                    }
                    else
                    {
                        Dictionary<string, string> dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);

                        Navigation.PushAsync(new ProductoEncontrado(dictionary["codigo"], dictionary["nombre"], dictionary["descripcion"]));
                    }     
                }
            }
            catch
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}