using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class UsuarioRolSubArea
    {
        public int Id { get; set; } 
        public Usuario Usuario { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }

        public int SubAreaId { get; set; }
        public SubArea SubArea { get; set; }
    }
}
