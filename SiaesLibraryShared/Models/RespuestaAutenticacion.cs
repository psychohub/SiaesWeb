﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class RespuestaAutenticacion
    {
        public bool IsSuccess { get; set; }
        public string? Token { get; set; }

        public Usuario? Usuario { get; set; }
        public IEnumerable<string>? Errores { get; set; }
    }
}