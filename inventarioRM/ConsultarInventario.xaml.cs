using inventarioRM.WS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inventarioRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarInventario : ContentPage
    {
        private const string Url = "http://192.168.2.128/inventarioRM/post.php";
        private readonly HttpClient cliente= new HttpClient();
        private ObservableCollection<inventarioRM.WS.Inventario> post;
        public ConsultarInventario()
        {
            InitializeComponent();
            Obtener();
        }
        public async void Obtener()
        {
            var content = await cliente.GetStringAsync(Url);
            post = new ObservableCollection<WS.Inventario>(JsonConvert.DeserializeObject<List<inventarioRM.WS.Inventario>>(content));
            ListaProductos.ItemsSource = post;


        }

        private void ListaProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objt = (WS.Inventario)e.SelectedItem;
            var item = objt.codigo.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(objt));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bntRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu());
        }

        private void bntAgregarP_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CrearProducto());
        }
    }
}