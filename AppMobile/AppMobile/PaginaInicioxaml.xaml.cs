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
	public partial class PaginaInicioxaml : ContentPage
	{
		public PaginaInicioxaml ()
		{
            try
            {
                InitializeComponent();
                NavigationPage.SetHasNavigationBar(this, true);

                lblIngreso.Text = "Bienvenido/a: " + App.Usuario;

                lblp1.Text = "Misión:";
                lblp1p.Text = "Acercarles a las jugueterías y papelería de todo el país la mayor variedad de artículos al mejor precio.";

                lblp2.Text = "Visión: ";
                lblp2p.Text = "Ser importadores líderes en el país en juguetería y artículos escolares.";

                lblp3.Text = "Valores:";
                lblp3p.Text = "Respeto, Calidad, Compromiso, Agilidad.";

                lblReporte.Text = "En caso de constatar un error en la aplicación o sugerir una mejora por favor contactarse " +
                    "por mail a estellano.gaston@gmail.com o marfabant@gmail.com. Tu opinión nos interesa.";

            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
			


        }
	}
}