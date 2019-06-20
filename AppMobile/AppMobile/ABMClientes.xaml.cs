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
	public partial class ABMClientes : ContentPage
	{
		public ABMClientes ()
		{
            try
            {
                InitializeComponent();
             

                btnCancelar.Clicked += BtnCancelar_Clicked;
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

                if (lblRut.Text == null || lblRut.Text.Trim() == "")
                {
                    DisplayAlert("Error", "RUT es obligatorios", "Aceptar");
                }
                else
                {
                    int rutEmpresa = Convert.ToInt32(lblRut.Text.Trim());

                    // Datos de prueba para dar de alta pedido
                    String nombreEmprea = "Estellano S.A";
                    String direccion = "Tacuarembo 1361";
                    String telefono = "098977344";
                    String ciudad = "Durazno";

                    //INVOCAR A SERVICIO DE BUSCAR CLIENTE

                  

                  //  if (Cliente != null)
                 //   {
                //        Navigation.PushAsync(new ClienteEncontrado(rutEmpresa, nombreEmprea, direccion, telefono, ciudad));
//
               //     }
               //     else
                //    {
               //         Navigation.PushAsync(new AltaCliente1(rutEmpresa));
              //      }

                }
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
    }
}