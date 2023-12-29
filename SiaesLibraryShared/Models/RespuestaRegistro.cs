using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class RespuestaRegistro
    {
        public bool registroCorrecto { get; set; }
        public IEnumerable<string>? Errores { get; set; }
    }
}
