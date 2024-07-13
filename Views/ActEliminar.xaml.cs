
using acolumbaS6.Modelos;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace acolumbaS6.Views
{
    public partial class ActEliminar : ContentPage
    {
        private const string urlWS = "http://192.168.17.22/semana6/estudiantews.php";
        private readonly HttpClient cliente = new HttpClient();
        public ActEliminar(estudiante estudiante)
        {
            InitializeComponent();
            txtCodigo.Text = estudiante.codigo.ToString();
            txtNombre.Text = estudiante.nombre;
            txtApellido.Text = estudiante.apellido;
            txtEdad.Text = estudiante.edad.ToString();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var estudiante = new
            {
                codigo = txtCodigo.Text,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                edad = txtEdad.Text
            };
            var json = JsonConvert.SerializeObject(estudiante);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync(urlWS, content);
            string respuesta = await response.Content.ReadAsStringAsync();
            DisplayAlert("Alerta", respuesta, "OK");
            Navigation.PushAsync(new vEstudiante());
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var codigo = txtCodigo.Text;
            var response = await cliente.DeleteAsync($"{urlWS}?codigo={codigo}");
            string respuesta = await response.Content.ReadAsStringAsync();
            Navigation.PushAsync(new vEstudiante());

        }
    }
}