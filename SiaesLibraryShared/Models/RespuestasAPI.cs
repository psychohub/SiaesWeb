using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class RespuestasAPI
    {
        public RespuestasAPI()
        {
            ErrorsMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; } 
        public List<string> ErrorsMessages { get; set; }
        public object Result { get; set; }

    }
}
