using RecaldeNExamen3.ViewModel;
namespace RecaldeNExamen3.Views;

public partial class Registro : ContentPage
{
    private VehiculoViewModel ViewModel => BindingContext as VehiculoViewModel;

    public Registro()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (ViewModel != null)
        {
            await ViewModel.GuardarVehiculo();
        }
    }
}