using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;

namespace SiaesLibraryShared
{
    public class InformeDTOListConverter : JsonConverter
    {
        private readonly IServicioIEMUsuarioInforme _servicioIEMUsuarioInforme;
        public InformeDTOListConverter() { }
   
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<IEMInforme>);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Serialización no es necesaria si solo estás deserializando
            throw new NotImplementedException();
        }

        public InformeDTOListConverter(IServicioIEMUsuarioInforme servicioIEMUsuarioInforme)
        {
            _servicioIEMUsuarioInforme = servicioIEMUsuarioInforme;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var informes = new List<IEMInforme>();

            JArray array = JArray.Load(reader);

            foreach (var item in array)
            {
                if (item != null && item["informe"] != null)
                {
                    IEMInforme informe = new IEMInforme
                    {
                        COD_INFORME = item["informe"]["coD_INFORME"]?.ToString(),
                        DSC_INFORME = item["informe"]["dsC_INFORME"]?.ToString()
                    };

                    informes.Add(informe);
                }
            }

            return informes;
        }
    }
}
