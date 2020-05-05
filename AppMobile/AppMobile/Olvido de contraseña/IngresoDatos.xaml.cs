using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Olvido_de_contraseña
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IngresoDatos : ContentPage
	{
		public IngresoDatos ()
		{
            try
            {
                InitializeComponent();
                btnEnviar.Clicked += BtnEnviar_Clicked;
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
			
		}

        private void BtnEnviar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (lblNickName.Text.Trim() == null || lblemail.Text.Trim() == null)
                {
                    DisplayAlert("", "Todos los campos son obligatorios", "Aceptar");
                }
                else
                {
                    LogicaServicios obj = new LogicaServicios();
                    string result = obj.BuscarVendedor(lblNickName.Text.Trim());

                    if (result.Length > 1)
                    {
                        result = result.Substring(1, result.Length - 2);
                    }

                    if (result.Length == 0)
                    {
                        DisplayAlert("", "No se encontro usuario con Nickname: " + lblNickName.Text, "Aceptar");
                    }
                    else
                    {
                        Dictionary<string, string> dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);
                        string nickname = dictionary["nickname"];
                        string email = dictionary["mail"];
                        if (lblNickName.Text.Trim() == nickname && (lblemail.Text.Trim() == email))
                        {
                            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                            MailMessage message = new MailMessage();
                            message.From = new MailAddress("estellano.gaston@gmail.com", "Oscal SRL - noreply");
                            message.To.Add(email);
                            message.Subject = "Restauración de contraseña – OSCAL S.R.L";
                            message.IsBodyHtml = true;
                            message.Body = "Estimado/a: " + lblNickName.Text + "<br><br>" +
                                "Hemos recibido tu solicitud de recuperación de contraseña. <br><br>" +
                                "Su nueva contraseña será: 12345678 , debe de ingresar al sistema y cambiarla mediante Datos Personales para su mayor seguridad. <br><br>" +
                                "Atentamente,<br>" +
                                "Oscal SRL.";
                            client.EnableSsl = true;                            
                            client.Credentials = new System.Net.NetworkCredential(App.direccionEnvioMail, App.passwordEnvioMail);
                            client.Send(message);


                            obj.CambiarContrasena(lblNickName.Text.Trim(), "12345678");
                            Navigation.PushAsync(new PantallExitoExterna());
                        }
                        else
                        {
                            DisplayAlert("", "Nickname y e-mail no coinciden.", "Aceptar");
                        }
                    }
                }
            }
            catch (Exception )
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }            
        }
    }
}