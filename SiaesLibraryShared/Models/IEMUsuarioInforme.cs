
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
  
    public class IEMUsuarioInforme
    {
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string COD_INFORME { get; set; }
        public int? Cod_Establecimiento { get; set; }
        public int? Log_Activo { get; set; }
   
    }
}
