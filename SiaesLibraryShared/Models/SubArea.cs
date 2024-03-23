using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class SubArea
    {
        [Key]
        public int IdSubArea { get; set; }
        public string DescripcionSubArea { get; set; }
   
        public List<UsuarioRolSubArea> UsuarioRolesSubAreas { get; set; }
     
        
    }
}
