using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AppMobile.PaginPrueba
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Prueba : ContentPage
    {
        public Prueba()
        {
            InitializeComponent();

            btnSi.Clicked += BtnSi_Clicked;

        }

        private void BtnSi_Clicked(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadFile("https://drive.google.com/file/d/11iHF_aawiSmwICkBW97B4tL-ll00yNak/view?usp=sharing","Catalogo_OSCAL");
            DisplayAlert("Archivo Descargado", "El archivo ha sido descargado", "OK");
        }
    }
}
