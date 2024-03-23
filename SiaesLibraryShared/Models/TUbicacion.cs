using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class TUbicacion
    {
        [Key]
         public int IdUbicacion { get; set; }

        [Required]
        [StringLength(150)]
        public string DescripcionUbicacion { get; set; }

        // Propiedad de navegación
        public virtual ICollection<TRegistroDiario> RegistrosDiarios { get; set; }
    }
}
