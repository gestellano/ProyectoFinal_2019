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
    public partial class AltaCliente1 : ContentPage
    {
        public AltaCliente1(int pRut)
        {
            try
            {
                InitializeComponent();

                lblRut.Text = Convert.ToString(pRut);
               
                


                btnCancelar.Clicked += BtnCancelar_Clicked;
                btnSiguiente.Clicked += BtnSiguiente_Clicked;
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }

       
        }


        private void BtnSiguiente_Clicked(object sender, EventArgs e)
        {
            try
            {
                String NombreEmpresa = lblNombreEmp.Text;
                String Direccion = lblDireccion.Text;
                String Telefono = lblTelefono.Text;
                String Ciudad = lblCiudad.Text;
                int RutConv = Convert.ToInt32(lblRut.Text);

                if (string.IsNullOrEmpty(NombreEmpresa) || string.IsNullOrEmpty(Direccion)
                    || string.IsNullOrEmpty(Telefono) || string.IsNullOrEmpty(Ciudad))
                {
                    DisplayAlert("Error", "Todos los campos son obligatorios", "Aceptar");

                }

                else
                {
                    Navigation.PushAsync(new AltaCliente2(RutConv, NombreEmpresa, Direccion, Telefono, Ciudad));
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