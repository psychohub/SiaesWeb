using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class IEMInformeDTO
    {
        [Key]
        public string COD_INFORME { get; set; }
        public string DSC_INFORME { get; set; }
   
    }
}
