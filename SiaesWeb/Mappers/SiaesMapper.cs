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
            CreateMap<TProceso, ProcesoDTO>().ReverseMap();
            CreateMap<TSubProceso, SubProcesoDTO>().ReverseMap();
            CreateMap<TActividadSustantiva, ActividadSustantivaDTO>().ReverseMap();
            CreateMap<TDetalleProceso, DetalleProcesoDTO>().ReverseMap();
            CreateMap<TDetalleProcesoSubArea, DetalleProcesoSubAreaDTO>().ReverseMap();
            CreateMap<TUbicacion, TUbicacionDTO>().ReverseMap();
            CreateMap<TActividadMacro, TActividadMacroDTO>().ReverseMap();
            CreateMap<RegistroDiarioCreacionDTO, TRegistroDiario>();
            CreateMap<RegistroDiarioCreacionDTO, TRegistroDiarioDTO>();
            CreateMap<TRegistroDiario, TRegistroDiarioDTO>().ReverseMap();
            CreateMap<TRegistroDiario, TTiempoInvertidoDTO>().ReverseMap();
        }
    }
}
