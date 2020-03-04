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
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }


        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaInicioxaml());
        }

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (lblCodigo.Text == null || lblCodigo.Text.Trim() == "")
                {

                    DisplayAlert("Error", "Codigo de producto obligatorio", "Aceptar");
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
                        DisplayAlert("", "Articulo no registrado", "Aceptar");
                        Navigation.PushAsync(new BuscarProducto());
                    }
                    else
                    {
                        Dictionary<string, string> dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);

                        Navigation.PushAsync(new ProductoEncontrado(dictionary["codigo"], dictionary["nombre"], dictionary["descripcion"], dictionary["imagen"]));
                    }                    
                   
                }
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }
        }
    }
}