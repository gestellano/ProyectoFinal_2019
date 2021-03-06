﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Alta_Pedido
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfeccionPedido : ContentPage
	{
   
        string rutEmpresa;
        string tipoEnvioSeleccionado;
        string codigoProducto;
        string nombreProducto;
        string usu;
        string celular;
        string mailDesde;
          int cantidadArticulos;
        Dictionary<string, int> listaArticulos = new Dictionary<string, int>();
        ObservableCollection<string> ListaArticulosString = new ObservableCollection<string>();
        ObservableCollection<string> ListEnvioMail = new ObservableCollection<string>();
        string articuloAgregado;
        string articuloAgregadoMail;
        string NombreEmpresaString;

        public ConfeccionPedido(string rut, string nombreEmp)
        {
            try
            {
                InitializeComponent();

                usu = App.Usuario;
                celular = App.NumeroCelular;
                mailDesde = App.Mail;
                NombreEmpresaString = nombreEmp;
                lblRut.Text = "RUT: " + rut;
                lblNombreEmpresa.Text = "Nombre Empresa: " + nombreEmp;
                rutEmpresa = rut;
                btnBuscar.Clicked += BtnBuscar_Clicked;
                btnAgregarAlPedido.IsVisible = false;
                lblCantidad.IsVisible = false;
                
                btnAgregarAlPedido.Clicked += BtnAgregarAlPedido_Clicked;
                btnEnviarPedido.Clicked += BtnEnviarPedido_Clicked;

                List<string> TipoEnvio = new List<string>();
                TipoEnvio.Add("Normal");
                TipoEnvio.Add("Express");
                TipoEnvio.Add("Consultar");
                Seleccione.ItemsSource = TipoEnvio;
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
            
        }


        private void BtnAgregarAlPedido_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (lblCodigo.Text == null  )
                {
                    DisplayAlert("", "Debe de buscar un artículo para agregar al pedido.", "Aceptar");
                }
                else if(lblCantidad.Text == null)
                {
                    DisplayAlert("", "Debe de ingresar la cantidad de artículos.", "Aceptar");
                }
                else
                {
                    cantidadArticulos = Convert.ToInt32(lblCantidad.Text);
                    listaArticulos.Add(codigoProducto, cantidadArticulos);
                    lblCantidad.IsVisible = false;
                    lblCodigo.IsVisible = false;
                    lblArticulo.IsVisible = false;
                    btnEnviarPedido.IsVisible = true;
                    btnEnviarPedido.IsEnabled = true;

                    articuloAgregado = "Cod.: "+codigoProducto +" - Cant.: " + cantidadArticulos;
                    articuloAgregadoMail = "Código: " + codigoProducto + " - Nombre: " + nombreProducto + " - Cantidad: " + cantidadArticulos;

                    ListaArticulosString.Add(articuloAgregado);
                    ListArticulos.ItemsSource = ListaArticulosString;

                    //List Envio de mail
                    ListEnvioMail.Add(articuloAgregadoMail);

                    lblCantidad.Text = null;
                    lblCodigo.Text = null;
                    lblArticulo.Text = null;
                    lblCodigoBuscar.Text = null;                    
                }                            
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido un error en la app,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (lblCodigoBuscar.Text == null || lblCodigoBuscar.Text.Trim() == "")
                {

                    DisplayAlert("", "Código de artículo es obligatorio", "Aceptar");
                }
                else
                {
                    LogicaServicios obj = new LogicaServicios();
                    string result = obj.BuscarArticulio(lblCodigoBuscar.Text.Trim());

                    if (result.Length > 1)
                    {
                        result = result.Substring(1, result.Length - 2);
                    }

                    if (result.Length == 0)
                    {
                        DisplayAlert("", "Artículo no registrado", "Aceptar");                       
                    }
                    else
                    {
                        Dictionary<string, string> dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);
                        lblCodigo.Text = "Código: "+dictionary["codigo"];
                        lblArticulo.Text = "Nombre: "+dictionary["nombre"];
                        btnAgregarAlPedido.IsVisible = true;            
                        codigoProducto = dictionary["codigo"];
                        nombreProducto = dictionary["nombre"];

                        lblCodigo.IsVisible = true;
                        lblArticulo.IsVisible = true;
                        lblCodigoBuscar.IsVisible = true;
                        lblCantidad.IsVisible = true;
                    }
                }
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }

        private void BtnEnviarPedido_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (usu == null)
                {
                    DisplayAlert("Error interno", "Por favor, cerrar app y volver a abrir.", "Aceptar");
                }
                else
                {
                    if (Seleccione.SelectedItem == null)
                    {
                        DisplayAlert("", "Debe de seleccionar un Tipo de Envío", "Aceptar");

                    }
                    else
                    {
                        if (listaArticulos.Count == 0)
                        {
                            DisplayAlert("", "Debe de agregar artículos al pedido", "Aceptar");
                        }
                        else
                        {
                            tipoEnvioSeleccionado = Seleccione.SelectedItem.ToString();
                            DateTime fechaActual = DateTime.Now;
                           
                            LogicaServicios obj = new LogicaServicios();
                            
                            //Envio mail del pedido al Administrador
                            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                            MailMessage message = new MailMessage();
                            message.From = new MailAddress(mailDesde.ToString(), "Oscal SRL - noreply");
                            message.To.Add(App.direccionEnvioMail);
                            message.To.Add(App.Mail);
                            message.Subject = "Nuevo Pedido: RUT: " + rutEmpresa+" Vendedor: "+usu+ " – OSCAL S.R.L";
                            message.IsBodyHtml = true;
                            message.Body = "<b>Pedido confeccionado por Vendedor: </b>" + usu + "<br>" +
                                "<b>Número de contacto: </b>" + App.NumeroCelular + "<br><br>" +
                                "-------------------------------------------------------------<br><br>" +
                                "<b>Cliente RUT: </b>" + rutEmpresa+"<br>"+
                                "<b>Nombre Empresa: </b>"+ NombreEmpresaString + "<br>"+                                
                                "<b>Tipo de Envío: </b>"+tipoEnvioSeleccionado.ToString()+"<br>"+
                                "<b>Fecha del Pedido: </b>"+fechaActual+"<br><br>";

                                foreach (var item in ListEnvioMail)
                            {
                                message.Body += item.ToString()+ "<br>";
                                
                            }

                            message.Body += "<br><br> <b>--------------------------------------------</b> <br>" +
                                "Fin del pedido<br>";

                            client.EnableSsl = true;
                            client.Credentials = new System.Net.NetworkCredential(App.direccionEnvioMail, App.passwordEnvioMail);
                            client.Send(message);
                            //Fin cuerpo mail

                            Navigation.PushAsync(new PantallaExito());
                        }
                    }
                }
            }
            catch (Exception)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }
    }
}