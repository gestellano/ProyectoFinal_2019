using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuHamburguesa : MasterDetailPage
	{
		public MenuHamburguesa()
		{
            InitializeComponent();
            Init();
		}

        void Init()
        {
            try
            {
                List<Menu> menu = new List<Menu>
            {
                new Menu{MenuTitle = "Inicio", Page = new PaginaInicioxaml()},
                new Menu{MenuTitle = "Perfil", Page = new Perfil()},
                new Menu{MenuTitle = "Contactos", Page = new Contactos()},
                new Menu{MenuTitle = "ABM Clientes", Page = new ABMClientes()},
                new Menu{MenuTitle = "Buscar Articulo", Page = new BuscarProducto()},          
                new Menu{MenuTitle = "Realizar Pedido", Page = new Alta_Pedido.AltaPedido_BuscarCliente()}
            };

                ListMenu.ItemsSource = menu;
                Detail = new NavigationPage(new PaginaInicioxaml());
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var menu = e.SelectedItem as Menu;
                if (menu != null)
                {
                    IsPresented = false;
                    Detail = new NavigationPage(menu.Page);
                }
            }
            catch
            {
                throw new Exception("Ha ocurrido un error en App y debe cerrase");
            }

        }
    }


    public class Menu
    {
        public string MenuTitle
        {
            get;
            set;
        }

        public string MenuDetail
        {
            get;
            set;
        }

        public Page Page
        {
            get;
            set;
        }
        
 
    } 


}