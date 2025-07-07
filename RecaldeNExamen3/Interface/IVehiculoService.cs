using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecaldeNExamen3.Models;

namespace RecaldeNExamen3.Interface
{
    internal interface IVehiculoService
    {
        void Init();
        Task<List<Vehiculo>> ObtenerVehiculos();
        Task<bool> GuardarVehiculo(Vehiculo vehiculo);
        Task<bool> EliminarVehiculo(int id);
    }
}
