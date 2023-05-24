using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inventarioRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearProducto : ContentPage
    {
        public CrearProducto()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient producto = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtnombre.Text);
                parametros.Add("nombre", txtnombre.Text);
                parametros.Add("descripcion", txtdescripcion.Text);
                parametros.Add("cantidad", txtcantidad.Text);
                parametros.Add("precio", txtprecio.Text);
                parametros.Add("fechaIngreso", txtfechaIngreso.Text);
                parametros.Add("proveedor", txtproveedor.Text);
                producto.UploadValues("http://192.168.2.128/inventarioRM/post.php", "POST", parametros);
                DisplayAlert("ALERTA", "producto correctamente ingresado", "cerrar");
                Navigation.PushAsync(new ConsultarInventario());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }
    }
}