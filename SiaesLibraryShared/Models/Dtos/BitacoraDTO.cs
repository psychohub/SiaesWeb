using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class BitacoraDTO
    {
        public int IdBitacora { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Accion { get; set; }
        public int? IdRegistroAfectado { get; set; }
        public string NombreTabla { get; set; }
        public string ValoresAnteriores { get; set; }
        public string ValoresNuevos { get; set; }
        public string IP { get; set; }
        public string Host { get; set; }
        public string NombreEquipo { get; set; }
        public string RemoteIPAddress { get; set; }
        public string RemoteHostIPAddress { get; set; }
        public string Geolocalizacion { get; set; }
    }
}
