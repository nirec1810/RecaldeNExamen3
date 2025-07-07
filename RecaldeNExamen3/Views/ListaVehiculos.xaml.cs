using RecaldeNExamen3.ViewModel;
namespace RecaldeNExamen3.Views;

public partial class ListaVehiculos : ContentPage
{
    private VehiculoViewModel ViewModel => BindingContext as VehiculoViewModel;

    public ListaVehiculos()
	{
		InitializeComponent();
        _ = ViewModel?.CargarVehiculos();
    }

    private async void RecargarPagina(object sender, EventArgs e)
    {
        await ViewModel.CargarVehiculos();   
    }
}