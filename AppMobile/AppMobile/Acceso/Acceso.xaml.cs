﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Acceso
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Acceso : ContentPage
	{
		public Acceso ()
		{
            InitializeComponent();
            btnAcceso.Clicked += BtnAcceso_Clicked;
            NavigationPage.SetHasBackButton(this, false);
        }

        private void BtnAcceso_Clicked(object sender, EventArgs e)
        {
            try
            {

                LogicaServicios obj = new LogicaServicios();
                string result = obj.BuscarVendedor(lblNickName.Text.Trim());

                if (result.Length > 1)
                {
                    result = result.Substring(1, result.Length - 2);
                }

                if (result.Length == 0)
                {
                    DisplayAlert("", "Usuario y/o Password incorrecto.", "Aceptar");
                }
                else
                {
                    Dictionary<string, string> dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);

                    if (lblPassword.Text.Trim() == dictionary["password"] & lblNickName.Text.Trim() == dictionary["nickname"])
                    {
                        App.Usuario = lblNickName.Text.Trim();
                        App.password = dictionary["password"];
                        App.nombre = dictionary["nombre"];
                        App.celular = dictionary["celular"];
                        App.mail = dictionary["mail"];
                        App.zonatrabajo = dictionary["zonatrabajo"];
                        App.tieneVehiculo = dictionary["tienevechiulo"];

                        Navigation.PushAsync(new MenuHamburguesa());
                    }
                    else
                    {
                        DisplayAlert("", "Usuario y/o Password incorrecto.", "Aceptar");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void registrarUsuario(object sender, EventArgs e)
            {
            try
            {
                Navigation.PushAsync(new RegistroVendedor.BuscarVendedor());
            }
            catch (Exception)
            {

                DisplayAlert("", "Funcionalidad no disponible.", "Aceptar");
            }

            }

        private void olvidoContraseña(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Olvido_de_contraseña.IngresoDatos());
            }
            catch (Exception)
            {

                DisplayAlert("", "Funcionalidad no disponible.", "Aceptar");
            }

        }


    }
}