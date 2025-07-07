using RecaldeNExamen3.Interface;
using RecaldeNExamen3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RecaldeNExamen3.Repository
{
    internal class VehiculoSQLiteAltoNivel : IVehiculoService
    {
        private SQLiteAsyncConnection _connSQLite;
        private string _rutaBD = FileSystem.AppDataDirectory + "/vehiculos.db3";

        public VehiculoSQLiteAltoNivel()
        {
            Init();
        }

        public async void Init()
        {
            if (_connSQLite != null)
            {
                return;

            }

            _connSQLite = new SQLiteAsyncConnection(_rutaBD);
            await _connSQLite.CreateTableAsync<Vehiculo>();
        }

        public async Task<bool> EliminarVehiculo(int id)
        {
            try
            {
                await _connSQLite.DeleteAsync(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> GuardarVehiculo(Vehiculo vehiculo)
        {
            try
            {
                if (vehiculo.AnioFabricacion < 1990 || vehiculo.AnioFabricacion > DateTime.Now.Year)
                    throw new ArgumentException("Año de fabricación inválido.");

                await _connSQLite.InsertAsync(vehiculo);

                string rutaLog = FileSystem.AppDataDirectory + "/Logs_Recalde.txt";
                string log = $"Se incluyó el registro {vehiculo.Marca} el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
                File.AppendAllText(rutaLog, log);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Vehiculo>> ObtenerVehiculos()
        {
            try
            {
                List<Vehiculo> vehiculos = await _connSQLite.Table<Vehiculo>().ToListAsync();
                return vehiculos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
