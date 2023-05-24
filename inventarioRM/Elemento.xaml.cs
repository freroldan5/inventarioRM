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
    public partial class Elemento : ContentPage
    {
        private WS.Inventario Dato { get; set; }  
        public Elemento(WS.Inventario objt)
        {
            InitializeComponent();
            Dato = objt;
            CargarDatos();
        }

         private void CargarDatos()
        {
           txtcodigo.Text = Dato.codigo.ToString();
            txtnombre.Text = Dato.nombre.ToString();
            txtdescripcion.Text = Dato.descripcion.ToString();
            txtcantidad.Text = Dato.cantidad.ToString();
            txtprecio.Text = Dato.precio.ToString();
            txtfecha.Text = Dato.fechaIngreso.ToString();
            txtproveedor.Text = Dato.proveedor.ToString();
                
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient producto = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                producto.UploadValues("http://192.168.2.128/inventarioRM/post.php?codigo= " + txtcodigo.Text + "&nombre=" + txtnombre.Text + "&descripcion=" + txtdescripcion.Text + "&cantidad=" + txtcantidad.Text + "&precio=" + txtprecio.Text + "&fechaIngreso=" + txtfecha.Text + "&proveedor=" + txtproveedor.Text, "PUT", parametros);
                DisplayAlert("Alerta", "Producto correctamente actualizado", "OK");
                Navigation.PushAsync(new ConsultarInventario());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient producto = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                byte[] res = producto.UploadValues("http://192.168.2.128/inventarioRM/post.php?codigo=" + txtcodigo.Text, "DELETE", parametros);
                var r = System.Text.ASCIIEncoding.UTF8.GetString(res);
                DisplayAlert("Alerta", "Producto eliminado", "OK");
                Navigation.PushAsync(new ConsultarInventario());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }
    }
}