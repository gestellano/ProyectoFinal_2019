using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Acceso.Acceso());
            //Usuario logueado
            App.Usuario = null;
            App.password = null;
            App.celular = null;
            App.mail = null;
            App.nombre = null;
            App.zonatrabajo = null;
            App.tieneVehiculo = null;

            //Credencias para envio de mail
            App.direccionEnvioMail = "estellano.gaston@gmail.com";
            App.passwordEnvioMail = "tajamar1";
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static string Usuario { get; set; }

        public static string nombre { get; set; }
        public static string celular { get; set; }
        public static string mail { get; set; }

        public static string password { get; set; }
        public static string zonatrabajo { get; set; }

        public static string tieneVehiculo { get; set; }

        public static string direccionEnvioMail { get; set; }

        public static string passwordEnvioMail { get; set; }
    }
}
