using RecaldeNExamen3.Interface;
using RecaldeNExamen3.Models;
using RecaldeNExamen3.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecaldeNExamen3.ViewModel
{
    internal class VehiculoViewModel : INotifyPropertyChanged
    {
        private readonly IVehiculoService _repo;
        private readonly string _rutaLog;
        private string _marca;
        private string _modelo;
        private int _anioFabricacion;
        private string _placa;

        public VehiculoViewModel()
        {
            _repo = new VehiculoSQLiteAltoNivel();
            _rutaLog = FileSystem.AppDataDirectory + "/Logs_Recalde.txt";
            ListaVehiculos = new ObservableCollection<Vehiculo>();
            _ = CargarVehiculos();
        }

        public string Marca
        {
            get => _marca;
            set { 
                _marca = value; OnPropertyChanged(); 
            }
        }

        public string Modelo
        {
            get => _modelo;
            set { 
                _modelo = value; OnPropertyChanged(); 
            }
        }

        public int AnioFabricacion
        {
            get => _anioFabricacion;
            set { 
                _anioFabricacion = value; OnPropertyChanged(); 
            }
        }
        
        public string Placa
        {
            get => _placa;
            set { 
                _placa = value; OnPropertyChanged(); 
            }
        }

        private ObservableCollection<Vehiculo> _listaVehiculos;
        public ObservableCollection<Vehiculo> ListaVehiculos
        {
            get => _listaVehiculos;
            set { _listaVehiculos = value; OnPropertyChanged(); }
        }

        public async Task GuardarVehiculo()
        {
            var nuevo = new Vehiculo { Marca = Marca, Modelo = Modelo, AnioFabricacion = AnioFabricacion, Placa = Placa };
            var comprobar = await _repo.GuardarVehiculo(nuevo);

            if (!comprobar)
                await App.Current.MainPage.DisplayAlert("Error", "No se pudo guardar. Verifique los datos.", "OK");
            else
                await App.Current.MainPage.DisplayAlert("Éxito", "Vehículo guardado.", "OK");

            await CargarVehiculos();
        }

        public async Task CargarVehiculos()
        {
            var lista = await _repo.ObtenerVehiculos();
            ListaVehiculos = new ObservableCollection<Vehiculo>(lista);
        }

        public string LeerLogs() => File.Exists(_rutaLog) ? File.ReadAllText(_rutaLog) : "Sin registros.";

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
