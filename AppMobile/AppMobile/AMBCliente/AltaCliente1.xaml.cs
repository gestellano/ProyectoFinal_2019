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
    public partial class AltaCliente1 : ContentPage
    {
        string usuario;
        public AltaCliente1(int pRut, string nickname)
        {
            try
            {
                InitializeComponent();
                usuario = nickname;
                lblRut.Text = Convert.ToString(pRut);
                btnCancelar.Clicked += BtnCancelar_Clicked;
                btnSiguiente.Clicked += BtnSiguiente_Clicked;
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }
        }


        private void BtnSiguiente_Clicked(object sender, EventArgs e)
        {
            try
            {
                String NombreEmpresa = lblNombreEmp.Text;
                String Direccion = lblDireccion.Text;
                String Telefono = lblTelefono.Text;
                String Ciudad = lblCiudad.Text;
                int RutConv = Convert.ToInt32(lblRut.Text);

                if (string.IsNullOrEmpty(NombreEmpresa) || string.IsNullOrEmpty(Direccion)
                    || string.IsNullOrEmpty(Telefono) || string.IsNullOrEmpty(Ciudad))
                {
                    DisplayAlert("", "Todos los campos son obligatorios", "Aceptar");
                }

                else
                {
                    Navigation.PushAsync(new AltaCliente2(RutConv, NombreEmpresa, Direccion, Telefono, Ciudad, usuario));
                }
            }
            catch
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