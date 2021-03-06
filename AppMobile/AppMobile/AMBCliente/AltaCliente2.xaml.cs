﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AltaCliente2 : ContentPage
	{
        string usuario;
		public AltaCliente2 (int Rut, String NombreEmp, String Direccion, String Telefono, String Ciudad, string nickname)
		{
            try
            {
                InitializeComponent();
                usuario = nickname;
                lblRut.Text = Convert.ToString(Rut);                
                lblNombreEmp.Text = NombreEmp;
                lblDireccion.Text = Direccion;
                lblTelefono.Text = Telefono;
                lblCiudad.Text = Ciudad;

                btnCancelar.Clicked += BtnCancelar_Clicked;
                btnConfirmar.Clicked += BtnConfirmar_Clicked;
            }
            catch
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnConfirmar_Clicked(object sender, EventArgs e)
        {
            try
            {            
                LogicaServicios obj = new LogicaServicios();
                obj.AgregarCliente(lblRut.Text,lblNombreEmp.Text,lblDireccion.Text,lblTelefono.Text,lblCiudad.Text);               
                Navigation.PushAsync(new PantallaExito());
            }
            catch(Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");

            }
            
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new MenuHamburguesa());
            }
            catch (Exception)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}