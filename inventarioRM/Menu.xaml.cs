using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inventarioRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnProducto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CrearProducto());
        }

        private void btnInventarioP_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultarInventario());

        }

        private void btnIngresoProv_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IngresoProv());
        }

        private void BtnCerrarApp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}