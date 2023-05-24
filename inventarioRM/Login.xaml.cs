using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inventarioRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        
        public Login()
        {
            InitializeComponent();
        }


        private void btnRegistro_Clicked(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            var Koneksi = new MySqlConnection(Properties.Resources.db_con);
            Koneksi.Open();

            var cmd = new MySqlCommand("SELECT * FROM seg_usuario where usuario = '" + usuario.Text + "' and pass = '" + contrasena.Text + "'", Koneksi);
            var rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                DisplayAlert("Información", "Usuario correcto Bienvenido", "OK");
                Navigation.PushAsync(new Menu());
                usuario.Text = "";
                contrasena.Text = "";
            }
            else
            {
                DisplayAlert("Información", "Usuario/correcto incorecto", "OK");
            }
        }
    }
}