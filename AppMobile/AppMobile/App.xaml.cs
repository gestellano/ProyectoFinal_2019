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
            App.Password = null;
            App.Mail = null;
            

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

        
        public static string Password { get; set; }
        public static string Mail { get; set; }
        public static string direccionEnvioMail { get; set; }

        public static string passwordEnvioMail { get; set; }
    }
}
