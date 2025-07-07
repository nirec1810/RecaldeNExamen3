using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RecaldeNExamen3.Models
{
    [Table("Vehiculo")]
    internal class Vehiculo
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Marca { get; set; }
        [MaxLength(100)]
        public string Modelo { get; set; }
        public int AnioFabricacion { get; set; }
        [MaxLength(10)]
        public string Placa { get; set; }
    }
}
