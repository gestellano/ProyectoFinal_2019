using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.DatosVendedor       
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModificarDatos : ContentPage
    {
        Dictionary<string, string> dictionary;
        bool tieneVeh;
        public ModificarDatos()
        {
            try
            {
                InitializeComponent();
                lblNickName.Text = App.Usuario;
                btnModificar.Clicked += BtnModificar_Clicked;

                if(lblNickName.Text == null)
                {
                    DisplayAlert("", "Ha ocurrido un error. Por favor cerrar sesión y vuelva a ingresar.", "Aceptar");
                }
                else
                {
                    List<string> TieneVehiculoList = new List<string>();
                    TieneVehiculoList.Add("Si");
                    TieneVehiculoList.Add("No");
                    TieneVehiculo.ItemsSource = TieneVehiculoList;

                    LogicaServicios obj = new LogicaServicios();
                    string result = obj.BuscarVendedor(App.Usuario.ToString());
                    dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);

                    lblCelular.Text = dictionary["celular"];
                    lblmail.Text = dictionary["mail"];
                    lblNombre.Text = dictionary["nombre"];
                    lblzonatrabajo.Text = dictionary["zonatrabajo"];
                    lblpassword.Text = App.Password.ToString();

                    string tienvehi = dictionary["tienevechiulo"]; ;

                    if (tienvehi == "True")
                    {
                        TieneVehiculo.SelectedItem = "Si";
                    }
                    else if (tienvehi == "False")
                    {
                        TieneVehiculo.SelectedItem = "No";
                    }
                }

            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }

        }

        private void BtnModificar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (TieneVehiculo.SelectedItem.ToString() == "Si")
                {
                    tieneVeh = true;
                }
                else
                {
                    tieneVeh = false;
                }                
                    LogicaServicios obj = new LogicaServicios();
                    obj.ModificarVendedor(lblNombre.Text.Trim(), lblmail.Text.Trim(), lblCelular.Text.Trim(), lblNickName.Text.Trim(), lblpassword.Text.Trim(), lblzonatrabajo.Text.Trim(), tieneVeh, "S");
                    Navigation.PushAsync(new PantallaExito());               

            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}