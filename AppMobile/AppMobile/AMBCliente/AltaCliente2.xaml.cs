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
		public AltaCliente2 (int Rut, String NombreEmp, String Direccion, String Telefono, String Ciudad)
		{
            try
            {
                InitializeComponent();

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
                //control que rut sea solo numerico

                LogicaServicios obj = new LogicaServicios();
                obj.AgregarCliente(lblRut.Text,lblNombreEmp.Text,lblDireccion.Text,lblTelefono.Text,lblCiudad.Text);               
                Navigation.PushAsync(new PantallaExito());
            }
            catch(Exception ex)
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
            catch (Exception ex)
            {

                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}