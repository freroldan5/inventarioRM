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
	public partial class IngresoProv : ContentPage
	{
		public IngresoProv ()
		{
			InitializeComponent ();
		}

        private void bntAgregarProveedor_Clicked(object sender, EventArgs e)
        {

        }

        private void bntRegresarProv_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu());
        }

        private void ListaProveedores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ListaProv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}