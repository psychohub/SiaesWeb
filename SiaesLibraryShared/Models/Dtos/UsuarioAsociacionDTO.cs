using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class UsuarioAsociacionDTO
    {
        public string NombreUsuario { get; set; }
        public int CodEstablecimiento { get; set; }
        public int Perfil { get; set; }
    }
}
