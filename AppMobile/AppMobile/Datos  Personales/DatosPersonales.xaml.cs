using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Datos__Personales
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DatosPersonales : ContentPage
	{
		public DatosPersonales ()
		{
			InitializeComponent ();
            lblCelular.Text = App.celular;
            lblmail.Text = App.mail;
            lblNickName.Text = App.Usuario;
            lblNombre.Text = App.nombre;
            lblzonatrabajo.Text = App.zonatrabajo;
        
		}
	}
}