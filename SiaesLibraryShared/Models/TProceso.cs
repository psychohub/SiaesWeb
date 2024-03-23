using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class TProceso
    {
        [Key]
        public int IdProceso { get; set; }

        [Required]
        [StringLength(150)]
        public string DescripcionProceso { get; set; }

        // Propiedad de navegación
        public virtual ICollection<TDetalleProceso> DetallesProcesos { get; set; }
    }
}
