using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace acolumbaS6.Views;

public partial class Estudiante : ContentPage
{ 

	public const string Url = "http://192.168.17.22/semana6/estudiantews.php";
    public readonly HttpClient cliente = new HttpClient();
    public ObservableCollection<Modelos.estudiante> estud;

	public Estudiante()
	{
		InitializeComponent();
		Obtener();
    }
	public async void Obtener()
	{
        var content = await cliente.GetStringAsync(Url);
        List<Modelos.estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Modelos.estudiante>>(content); 
		estud = new ObservableCollection<Modelos.estudiante>(mostrarEst);
        listaEstudiantes.ItemsSource = estud;
    }
}