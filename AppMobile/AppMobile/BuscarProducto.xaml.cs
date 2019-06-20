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
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }


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
                    int Codigo = (Convert.ToInt32(lblCodigo.Text.Trim()));
                    //invocar a servicio con CODIGO

                   // Entidades.EspecificacionArticulo ArticuloBuscar = new Entidades.EspecificacionArticulo();
                  //  ArticuloBuscar = null;

                    

                    
                        DisplayAlert("", "Producto no registrado", "Aceptar");
                    
                   
                }
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }
        }
    }
}