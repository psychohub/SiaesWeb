
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SiaesLibraryShared.Models
{
    public class Model_Tanu
    {
        [Key]
        public int Id { get; set; }
        public string? NombreHospital { get; set; }

        public string? NumeroIdentificacionMadre { get; set; }

        public string? NombreMadre { get; set; }

        public string? ApellidosMadre { get; set; }

        public string? Telefono1Madre { get; set; }

        public string? Telefono2Madre { get; set; }

        public string? NumeroIdentificacionRecienNacido { get; set; }

        public string? NombreRecienNacido { get; set; }

        public string? ApellidosRecienNacido { get; set; }

        public DateTime FechaNacimientoRecienNacido { get; set; }

        public string? SexoRecienNacido { get; set; } // Puedes usar un enum o string según tus necesidades

        public DateTime FechaPrimerTamizaje { get; set; }

        public bool PasaDerechoEOA { get; set; }

        public bool PasaIzquierdoEOA { get; set; }

        public string? CentroDiagnosticoReferencia { get; set; }

        public string? ValoracionDiagnostica { get; set; }

 
        public bool PEAAV0_1 { get; set; }

        public bool PEAAV0_2 { get; set; }


        public string? LateralidadDerechaTipoSordera { get; set; }

        public string? LateralidadDerechaGradoSordera { get; set; }


        public string? LateralidadIzquierdaTipoSordera { get; set; }

        public string? LateralidadIzquierdaGradoSordera { get; set; }
    }
}
