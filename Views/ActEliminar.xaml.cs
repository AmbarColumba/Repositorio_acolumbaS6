using acolumbaS6.Modelos;
using System.Net;

namespace acolumbaS6.Views
{
    public partial class ActEliminar : ContentPage
    {
        private Modelos.estudiante estudianteActual;

        public ActEliminar(Modelos.estudiante estudiante)
        {
            InitializeComponent();
            estudianteActual = estudiante;

            txtCodigo.Text = estudianteActual.codigo.ToString();
            txtNombre.Text = estudianteActual.nombre;
            txtApellido.Text = estudianteActual.apellido;
            txtEdad.Text = estudianteActual.edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("id", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues("http://192.168.17.22/semana6/estudiantews.php", "PUT", parametros);
                DisplayAlert("Éxito", "Registro actualizado correctamente", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("id", txtCodigo.Text);

                cliente.UploadValues("http://192.168.17.22/semana6/estudiantews.php", "DELETE", parametros);
                DisplayAlert("Éxito", "Registro eliminado correctamente", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }
    }
}
