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
	public partial class DetalleProductoEncontrado : ContentPage
	{
		public DetalleProductoEncontrado (String id, String descripcion, String imagen)
		{
			InitializeComponent ();
		}
	}
}