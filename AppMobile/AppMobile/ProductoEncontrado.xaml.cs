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
	public partial class ProductoEncontrado : ContentPage
	{
		public ProductoEncontrado (string codigo, string nombre, string descripcion, string imagen)
		{
			InitializeComponent ();

            lblCodigo.Text = codigo;
            lblNombre.Text = nombre;
            lblDescripcion.Text = descripcion;
            lblImagen.Text = imagen;

            btnBuscarOtroProducto.Clicked += BtnBuscarOtroProducto_Clicked;
            btnInicio.Clicked += BtnInicio_Clicked;
		}

        private void BtnInicio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaInicioxaml());
        }

        private void BtnBuscarOtroProducto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BuscarProducto());
        }
    }
}