using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class TDetalleProcesoSubArea
    {
        [Key]
         public int IdDetalleProcesoSubArea { get; set; }

        [Required]
        public int IdDetalleProceso { get; set; }

        [Required]
        public int IdSubArea { get; set; }

        [Required]
        public bool Activo { get; set; }

        // Propiedades de navegación
        public virtual TDetalleProceso DetalleProceso { get; set; }
        public virtual SubArea SubArea { get; set; }
    }
}
