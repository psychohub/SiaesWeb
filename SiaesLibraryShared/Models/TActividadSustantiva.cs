using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class TActividadSustantiva
    {
        [Key]
        public int IdActividad { get; set; }

        [Required]
        [StringLength(1000)]
        public string DescripcionActividad { get; set; }

        // Propiedad de navegación
        public virtual ICollection<TDetalleProceso> DetallesProcesos { get; set; }
    }
}
