using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class TSubProceso
    {
        [Key]
        public int IdSubProceso { get; set; }

        [Required]
        [StringLength(150)]
        public string DescripcionSubProceso { get; set; }

        // Propiedad de navegación
        public virtual ICollection<TDetalleProceso> DetallesProcesos { get; set; }
    }
}
