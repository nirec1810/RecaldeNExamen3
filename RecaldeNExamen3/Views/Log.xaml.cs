using RecaldeNExamen3.ViewModel;

namespace RecaldeNExamen3.Views
{
    public partial class Log : ContentPage
    {
        private VehiculoViewModel ViewModel => BindingContext as VehiculoViewModel;

        public Log()
        {
            InitializeComponent();
        }

        private void RecargarPagina(object sender, EventArgs e)
        {
            ViewModel.CargarLogs(); 
        }
    }
}
