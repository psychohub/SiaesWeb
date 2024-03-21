using AutoMapper;
using SiaesLibraryShared.Models.Dtos;
using SiaesLibraryShared.Models;

namespace SiaesServer.Mappers
{
    public class SiaesMapper : Profile
    {
        public SiaesMapper()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Establecimiento, EstablecimientoDTO>().ReverseMap();
            CreateMap<Perfil, PerfilDTO>().ReverseMap();
            CreateMap<UsuarioEstablecimiento, UsuarioEstablecimientoDTO>().ReverseMap();
            CreateMap<UsuarioPerfil, UsuarioPerfilDTO>().ReverseMap();
            CreateMap<IEMInforme, IEMInformeDTO>().ReverseMap();
            CreateMap<IEMUsuarioInforme, IEMUsuarioInformeDTO>().ReverseMap();
        }
    }
}
