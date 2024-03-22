
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiaesLibraryShared.Models
{
 
    public class IEMInforme
    {
        [Key]
        public string COD_INFORME { get; set; }
        public string DSC_INFORME { get; set; }
        public int? Log_Activo { get; set; }
        public int? Tipo { get; set; }
        public int? Log_Activo_SACCE { get; set; }
    }
}
