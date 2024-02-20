namespace SiaesLibraryShared.Models
{
    public  class UsuarioParaRegistroAPI
    {
        public string nombreUsuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public int codEstablecimiento { get; set; }
        public string clave { get; set; }
        public int perfil { get; set; }
        public int estado { get; set; }
        public DateTime fechaCaducidad { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
