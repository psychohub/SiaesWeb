using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class UsuarioLoginRespuestaDTO
    {
        public Usuario Usuario { get; set; }
        public string Token { get; set; }
    }
}
