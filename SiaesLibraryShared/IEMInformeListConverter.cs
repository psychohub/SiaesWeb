using SiaesLibraryShared.Models;
using System.ComponentModel;
using System.Globalization;

namespace SiaesLibraryShared
{
    public class IEMInformeListConverter : TypeConverter
    {
        private static readonly List<IEMInforme> _informes = new List<IEMInforme>
        {
       new IEMInforme { COD_INFORME = "1", DSC_INFORME = "Cuadro Resumen" },
new IEMInforme { COD_INFORME = "11E", DSC_INFORME = "Hospital de Día" },
new IEMInforme { COD_INFORME = "13", DSC_INFORME = "Odontología" },
new IEMInforme { COD_INFORME = "17", DSC_INFORME = "Urgencias" },
new IEMInforme { COD_INFORME = "18", DSC_INFORME = "Accidentes" },
new IEMInforme { COD_INFORME = "180", DSC_INFORME = "Medicina Empresa" },
new IEMInforme { COD_INFORME = "180a", DSC_INFORME = "Consulta Externa" },
new IEMInforme { COD_INFORME = "19", DSC_INFORME = "Atención Domiciliar" },
new IEMInforme { COD_INFORME = "19CP", DSC_INFORME = "Atención Domiciliar Cuidados Paliativos" },
new IEMInforme { COD_INFORME = "20", DSC_INFORME = "ATAP" },
new IEMInforme { COD_INFORME = "20a", DSC_INFORME = "Actividades Escenario Domiciliar" },
new IEMInforme { COD_INFORME = "20b", DSC_INFORME = "Actividades en otros Escenarios" },
new IEMInforme { COD_INFORME = "20c", DSC_INFORME = "Actividades en otros Escenarios ATAP" },
new IEMInforme { COD_INFORME = "21", DSC_INFORME = "Listas de Espera-21" },
new IEMInforme { COD_INFORME = "22", DSC_INFORME = "Lista de Espera" },
new IEMInforme { COD_INFORME = "23", DSC_INFORME = "Control del Dolor y CP" },
new IEMInforme { COD_INFORME = "24", DSC_INFORME = "Teleinterconsulta (Consultado)" },
new IEMInforme { COD_INFORME = "25", DSC_INFORME = "Teleinterconsulta (Consultante)" },
new IEMInforme { COD_INFORME = "27", DSC_INFORME = "Centro de Llamadas para Citas" },
new IEMInforme { COD_INFORME = "31", DSC_INFORME = "Medicamentos" },
new IEMInforme { COD_INFORME = "31B", DSC_INFORME = "Actividades de Atención Farmacéutica" },
new IEMInforme { COD_INFORME = "31x", DSC_INFORME = "MedicamentosXML" },
new IEMInforme { COD_INFORME = "32", DSC_INFORME = "Laboratorio" },
new IEMInforme { COD_INFORME = "33", DSC_INFORME = "Estudios e Imágenes de RX" },
new IEMInforme { COD_INFORME = "35", DSC_INFORME = "Fluoroscopías" },
new IEMInforme { COD_INFORME = "36", DSC_INFORME = "Ultrasonidos" },
new IEMInforme { COD_INFORME = "36B", DSC_INFORME = "Mamografías" },
new IEMInforme { COD_INFORME = "36GIN", DSC_INFORME = "Ultrasonidos Gin" },
new IEMInforme { COD_INFORME = "37", DSC_INFORME = "TAC" },
new IEMInforme { COD_INFORME = "38", DSC_INFORME = "Banco de Sangre" },
new IEMInforme { COD_INFORME = "39", DSC_INFORME = "Citologías Biopsias y Autopsias" },
new IEMInforme { COD_INFORME = "41", DSC_INFORME = "Psicología" },
new IEMInforme { COD_INFORME = "42", DSC_INFORME = "Trabajo Social" },
new IEMInforme { COD_INFORME = "43", DSC_INFORME = "Nutrición" },
new IEMInforme { COD_INFORME = "43B", DSC_INFORME = "Actividades de Nutrición" },
new IEMInforme { COD_INFORME = "44", DSC_INFORME = "Procedimientos Programados" },
new IEMInforme { COD_INFORME = "44B", DSC_INFORME = "Procedimientos No Programados" },
new IEMInforme { COD_INFORME = "46", DSC_INFORME = "Terapias" },
new IEMInforme { COD_INFORME = "62", DSC_INFORME = "Transportes" },
new IEMInforme { COD_INFORME = "66", DSC_INFORME = "Residuos Hospitalarios" },
new IEMInforme { COD_INFORME = "79", DSC_INFORME = "Listas de Espera CX-79" },
new IEMInforme { COD_INFORME = "80", DSC_INFORME = "Adscripción y Beneficio Familiar" },
new IEMInforme { COD_INFORME = "81", DSC_INFORME = "Programa Atención Escenario Educativo" },
new IEMInforme { COD_INFORME = "81a", DSC_INFORME = "Modulo RISA" },
new IEMInforme { COD_INFORME = "81b", DSC_INFORME = "Tamizajes" },
new IEMInforme { COD_INFORME = "81c", DSC_INFORME = "Reporte_RISA" },
new IEMInforme { COD_INFORME = "82", DSC_INFORME = "905 CAJA" },
new IEMInforme { COD_INFORME = "82_1", DSC_INFORME = "905 CAJA CONSULTAS" },
new IEMInforme { COD_INFORME = "82_2", DSC_INFORME = "905 CAJA ESCALAR" },
new IEMInforme { COD_INFORME = "82A", DSC_INFORME = "905 CAJA REDES" },
new IEMInforme { COD_INFORME = "82B", DSC_INFORME = "905 CAJA FARMACIA" },
new IEMInforme { COD_INFORME = "82C", DSC_INFORME = "CAMPAÑAS" },
new IEMInforme { COD_INFORME = "82C_1", DSC_INFORME = "905 CAJA CAMPAÑAS" },
new IEMInforme { COD_INFORME = "82C_2", DSC_INFORME = "Mant_Campañas" },
new IEMInforme { COD_INFORME = "82D", DSC_INFORME = "Vacunación" },
new IEMInforme { COD_INFORME = "82R", DSC_INFORME = "905 CAJA REDES CONSULTAS" },
new IEMInforme { COD_INFORME = "83", DSC_INFORME = "SEDISPEDO" },
new IEMInforme { COD_INFORME = "83A", DSC_INFORME = "SEDISPEDO_REDES" },
new IEMInforme { COD_INFORME = "83B", DSC_INFORME = "SEDISPEDO_ALDI" },
new IEMInforme { COD_INFORME = "83C", DSC_INFORME = "SEDISPEDO_PROV" },
new IEMInforme { COD_INFORME = "85", DSC_INFORME = "Actividades de recuperación" },
new IEMInforme { COD_INFORME = "85A", DSC_INFORME = "Exportar Actividades de recuperación" },
new IEMInforme { COD_INFORME = "86", DSC_INFORME = "Corrección de datos" },
new IEMInforme { COD_INFORME = "87", DSC_INFORME = "Tamizaje Auditivo" },
new IEMInforme { COD_INFORME = "90", DSC_INFORME = "Promocion de la Salud" },
new IEMInforme { COD_INFORME = "92", DSC_INFORME = "SIVEO" },
new IEMInforme { COD_INFORME = "92A", DSC_INFORME = "Poblacion_SIVEO" },
new IEMInforme { COD_INFORME = "94", DSC_INFORME = "ISUP_Area" },
new IEMInforme { COD_INFORME = "94a", DSC_INFORME = "ISUP_Supervision" },
new IEMInforme { COD_INFORME = "94b", DSC_INFORME = "ISUP_Expediente" },
new IEMInforme { COD_INFORME = "M1", DSC_INFORME = "Registro" },
new IEMInforme { COD_INFORME = "M10", DSC_INFORME = "Registro_Responsable_Cuadro" },
new IEMInforme { COD_INFORME = "M11", DSC_INFORME = "Registro_Jefaturas_REDES" },
new IEMInforme { COD_INFORME = "M12", DSC_INFORME = "FechasCorte" },
new IEMInforme { COD_INFORME = "M13", DSC_INFORME = "RegistroCuadroEstablecimiento" },
new IEMInforme { COD_INFORME = "M2", DSC_INFORME = "RegistroUsuariosInforme" },
new IEMInforme { COD_INFORME = "M3", DSC_INFORME = "Registro_Procedimientos" },
new IEMInforme { COD_INFORME = "M4", DSC_INFORME = "Registro_Escuelas" },
new IEMInforme { COD_INFORME = "M5", DSC_INFORME = "Registro_Estrategia_Farmacia" },
new IEMInforme { COD_INFORME = "M6", DSC_INFORME = "Registro_Jefatura" },
new IEMInforme { COD_INFORME = "M7", DSC_INFORME = "Registro_Empresa" },
new IEMInforme { COD_INFORME = "M8", DSC_INFORME = "Registro_Funcionario" },
new IEMInforme { COD_INFORME = "M9", DSC_INFORME = "Registro_Medico_Empresa" },
new IEMInforme { COD_INFORME = "R11E", DSC_INFORME = "ReportCuadro_11E" },
new IEMInforme { COD_INFORME = "R13", DSC_INFORME = "ReportCuadro_13" },
new IEMInforme { COD_INFORME = "R17", DSC_INFORME = "ReportCuadro_17" },
new IEMInforme { COD_INFORME = "R19", DSC_INFORME = "ReportCuadro_19" },
new IEMInforme { COD_INFORME = "R19CP", DSC_INFORME = "ReportCuadro_19CP" },
new IEMInforme { COD_INFORME = "R20", DSC_INFORME = "ReportCuadro_20" },
new IEMInforme { COD_INFORME = "R21", DSC_INFORME = "ReportCuadro_21" },
new IEMInforme { COD_INFORME = "R23", DSC_INFORME = "ReportCuadro_23" },
new IEMInforme { COD_INFORME = "R24", DSC_INFORME = "ReportCuadro_24" },
new IEMInforme { COD_INFORME = "R25", DSC_INFORME = "ReportCuadro_25" },
new IEMInforme { COD_INFORME = "R27", DSC_INFORME = "ReportCuadro_27" },
new IEMInforme { COD_INFORME = "R31B", DSC_INFORME = "ReportCuadro_31B" },
new IEMInforme { COD_INFORME = "R32", DSC_INFORME = "ReportCuadro_32" },
new IEMInforme { COD_INFORME = "R33", DSC_INFORME = "ReportCuadro_33" },
new IEMInforme { COD_INFORME = "R35", DSC_INFORME = "ReportCuadro_35" },
new IEMInforme { COD_INFORME = "R36", DSC_INFORME = "ReportCuadro_36" },
new IEMInforme { COD_INFORME = "R36B", DSC_INFORME = "ReportCuadro_36B" },
new IEMInforme { COD_INFORME = "R36GIN", DSC_INFORME = "ReportCuadro_36GIN" },
new IEMInforme { COD_INFORME = "R37", DSC_INFORME = "ReportCuadro_37" },
new IEMInforme { COD_INFORME = "R38", DSC_INFORME = "ReportCuadro_38" },
new IEMInforme { COD_INFORME = "R39", DSC_INFORME = "ReportCuadro_39" },
new IEMInforme { COD_INFORME = "R41", DSC_INFORME = "ReportCuadro_41" },
new IEMInforme { COD_INFORME = "R42", DSC_INFORME = "ReportCuadro_42" },
new IEMInforme { COD_INFORME = "R43", DSC_INFORME = "ReportCuadro_43" },
new IEMInforme { COD_INFORME = "R43B", DSC_INFORME = "ReportCuadro_43B" },
new IEMInforme { COD_INFORME = "R44", DSC_INFORME = "ReportCuadro_44" },
new IEMInforme { COD_INFORME = "R44B", DSC_INFORME = "ReportCuadro_44B" },
new IEMInforme { COD_INFORME = "R46", DSC_INFORME = "ReportCuadro_46" },
new IEMInforme { COD_INFORME = "R62", DSC_INFORME = "ReportCuadro_62" },
new IEMInforme { COD_INFORME = "R66", DSC_INFORME = "ReportCuadro_66" },
new IEMInforme { COD_INFORME = "R80", DSC_INFORME = "ReportCuadro_80" },
new IEMInforme { COD_INFORME = "RAES1", DSC_INFORME = "ReporteGeneralCuadros" },

        };

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object? ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is not string stringValue)
            {
                return null;
            }

            var informeCodes = stringValue.Split(',').Select(s => s.Trim());
            var informes = new List<IEMInforme>();

            foreach (var codigo in informeCodes)
            {
                var informe = _informes.FirstOrDefault(i => i.COD_INFORME == codigo);
                if (informe != null)
                {
                    informes.Add(informe);
                }
            }

            return informes;
        }
    }
}
