﻿using System.ComponentModel.DataAnnotations;

namespace SiaesLibraryShared.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El codigo es obligatorio")]
        [RegularExpression(@"^\d{1,4}$", ErrorMessage = "El CodEstablecimiento debe contener como máximo 4 dígitos")]
        public int CodEstablecimiento { get; set; }

        [Required(ErrorMessage = "La clave es requerida")]
        public string Clave { get; set; } = string.Empty;
        public int Perfil { get; set; }
        public int Estado { get; set; }

        public int IdRol { get; set; }
        public int IdSubArea { get; set; }
        public DateTime FechaCaducidad { get; set; } = DateTime.Now;
        public string? UsuarioCreacion { get; set; } = string.Empty;

        public string? UsuarioModificacion { get; set; } = string.Empty;
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaActualizacion { get; set; } = DateTime.Now;

        public ICollection<UsuarioEstablecimiento> UsuarioEstablecimientos { get; set; }
        public ICollection<UsuarioPerfil> UsuarioPerfiles { get; set; }

        public ICollection<UsuarioEstablecimientoPerfil> UsuarioEstablecimientoPerfiles { get; set; }

      
    }
}
