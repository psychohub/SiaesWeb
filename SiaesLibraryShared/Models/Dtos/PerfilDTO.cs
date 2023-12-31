using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class PerfilDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<UsuarioPerfilDTO> UsuarioPerfiles { get; set; }
    }
}
