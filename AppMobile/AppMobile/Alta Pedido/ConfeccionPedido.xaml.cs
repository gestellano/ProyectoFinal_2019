using System;
using System.Collections.Generic;
using System.Linq;
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
        int cantidadArticulos;
        Dictionary<string, int> listaArticulos = new Dictionary<string, int>();

        public ConfeccionPedido(string rut, string nombreEmp)
        {
			InitializeComponent ();

            lblRut.Text = "RUT: "+rut;
            lblNombreEmpresa.Text = "Nombre Empresa: "+nombreEmp;
            rutEmpresa = rut;

            btnBuscar.Clicked += BtnBuscar_Clicked;
            btnAgregarAlPedido.IsVisible = false;
            btnAgregarAlPedido.Clicked += BtnAgregarAlPedido_Clicked;
            btnEnviarPedido.Clicked += BtnEnviarPedido_Clicked;

            List<string> TipoEnvio = new List<string>();
            TipoEnvio.Add("Normal");
            TipoEnvio.Add("Express");
            TipoEnvio.Add("Consultar");
            Seleccione.ItemsSource = TipoEnvio;

        }

        
        private void BtnAgregarAlPedido_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (lblCodigo.Text == null  )
                {
                    DisplayAlert("", "Debe de buscar un articulo para agregar al pedido.", "Aceptar");
                }
                else if(lblCantidad.Text == null)
                {
                    DisplayAlert("", "Debe de ingresar la cantidad de articulos.", "Aceptar");
                }
                else
                {
                    cantidadArticulos = Convert.ToInt32(lblCantidad.Text);
                    listaArticulos.Add(codigoProducto, cantidadArticulos);
                    lblCantidad.IsVisible = false;
                    lblCodigo.IsVisible = false;
                    lblArticulo.IsVisible = false;

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

                    DisplayAlert("Alerta", "Codigo de producto obligatorio", "Aceptar");
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
                        DisplayAlert("", "Articulo no registrado", "Aceptar");                       
                    }
                    else
                    {
                        Dictionary<string, string> dictionary = result.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);
                        lblCodigo.Text = "Codigo: "+dictionary["codigo"];
                        lblArticulo.Text = "Nombre: "+dictionary["nombre"];
                        btnAgregarAlPedido.IsVisible = true;            
                        codigoProducto = dictionary["codigo"];

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
                //cambiarlo para tomar usuario logueado
                string vendedor = "Vendedor1";                

                if(Seleccione.SelectedItem == null)
                {
                    DisplayAlert("", "Debe de seleccionar un Tipo de Envio", "Aceptar");
                    
                }
                else
                {
                    tipoEnvioSeleccionado = Seleccione.SelectedItem.ToString();
                    DateTime fechaActual = DateTime.Now;
                    int estadoImpresionPedido = 0;
                    LogicaServicios obj = new LogicaServicios();
                    obj.AltaPedido(rutEmpresa, fechaActual, estadoImpresionPedido, vendedor, tipoEnvioSeleccionado);
                }
                
            }
            catch (Exception ex)
            {
                DisplayAlert("", "Ha ocurrido al enviar los datos,intente nuevamente la operativa.", "Aceptar");
            }
        }



    }
}