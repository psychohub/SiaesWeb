using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string Descripcion_Rol { get; set; }

        public List<UsuarioRolSubArea> UsuarioRolesSubAreas { get; set; }
    }
}
