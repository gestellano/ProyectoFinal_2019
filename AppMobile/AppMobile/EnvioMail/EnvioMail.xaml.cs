﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.EnvioMail
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EnvioMail : ContentPage
	{
        string mailDesde;
        string usu;
        string celular;

        public EnvioMail ()
		{

			InitializeComponent ();
            lblMailAdmin.Text =  App.direccionEnvioMail;
            btnEnviar.Clicked += BtnEnviar_Clicked;
            mailDesde = App.Mail;
            usu = App.Usuario;
            celular = App.NumeroCelular;
        }

        private void BtnEnviar_Clicked(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage();
                message.From = new MailAddress(mailDesde.ToString(), "Oscal SRL - noreply");
                message.To.Add(App.direccionEnvioMail);
                message.Subject = "Contacto vía mail: "+usu+" – OSCAL S.R.L";
                message.IsBodyHtml = true;
                message.Body = "<b>Mail enviado desde la app por: </b>"+usu+"<br>" +
                    "<b>Número de contacto: </b>"+celular+"<br>"+
                    "-----------------------------<br><br>" +
                     txtContenido.Text;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential(App.direccionEnvioMail, App.passwordEnvioMail);
                client.Send(message);
                Navigation.PushAsync(new PantallaExito());
            }
            catch (Exception ex)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}