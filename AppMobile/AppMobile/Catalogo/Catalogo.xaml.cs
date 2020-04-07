using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Catalogo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Catalogo : ContentPage
    {
        public Catalogo()
        {
            InitializeComponent();
            btnCatalogo.Clicked += BtnCatalogo_Clicked;
        }

        private void BtnCatalogo_Clicked(object sender, EventArgs e)
        {
            try
            {
                Device.OpenUri(new Uri("https://drive.google.com/drive/folders/1jGZygFcL5fxIC4oHCAQnnYMZ2i7urQBD?usp=sharing"));
            }
            catch (Exception)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}