using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SiaesCliente.Helpers;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Linq.Dynamic.Core.Tokenizer;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using SiaesLibraryShared.Models.Dtos;

namespace SiaesCliente.Servicios
{
    public class ServicioAutenticacion : IServicioAutenticacion
    {
        private readonly HttpClient? _cliente;
        private readonly ILocalStorageService? _localStorage;
        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        public ServicioAutenticacion(HttpClient cliente,
            ILocalStorageService localStorage,
            AuthenticationStateProvider estadoProveedorAutenticacion)
        {
            _cliente = cliente;
            _localStorage = localStorage;
            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
        }

        public async Task<RespuestaAutenticacion> Acceder(UsuarioAutenticacion usuarioDesdeAutenticacion)
        {
            var content = JsonConvert.SerializeObject(usuarioDesdeAutenticacion);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _cliente.PostAsync($"{Inicializar.UrlBaseApi}api/siaes/login", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<JObject>(contentTemp);

            if (resultado == null)
            {
                return new RespuestaAutenticacion { IsSuccess = false };
            }

            var result = resultado["result"] as JObject;
            if (result != null)
            {
                var usuario = result["usuario"] as JObject;
                if (usuario != null)
                {
                    var Token = result["token"]?.Value<string>();
                    var Usuario = usuario["nombreUsuario"]?.Value<string>();
                    var Perfil = usuario["perfil"]?.Value<int>();
                    var CodEstablecimiento = usuario["codEstablecimiento"]?.Value<int>();

                    if (!string.IsNullOrEmpty(Token) && !string.IsNullOrEmpty(Usuario) && Perfil.HasValue && CodEstablecimiento.HasValue)
                    {
                        // Realizar acciones con Token, Usuario, Perfil y CodEstablecimiento
                        await _localStorage.SetItemAsync(Inicializar.Token_Local, Token);
                        await _localStorage.SetItemAsync(Inicializar.Datos_Usuario_Local, Usuario);
                        await _localStorage.SetItemAsync("perfil", Perfil.Value);
                        await _localStorage.SetItemAsync("unidad", CodEstablecimiento.Value);
                        ((AuthStateProvider)_estadoProveedorAutenticacion).NotificarUsuarioLogueado(Token);
                        _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);
                        return new RespuestaAutenticacion
                        {
                            IsSuccess = true,
                            Token = Token,
                            NombreUsuario = Usuario,
                            Perfil = Perfil.Value,
                            CodEstablecimiento = CodEstablecimiento.Value
                        };
                    }
                }
            }

            return new RespuestaAutenticacion { IsSuccess = false };
          
        }

        public async Task<(bool registroCorrecto, List<string>? Errores)> RegistrarUsuario(UsuarioParaRegistroAPI usuarioParaRegistro)
        {
            var content = JsonConvert.SerializeObject(usuarioParaRegistro);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _cliente.PostAsync($"{Inicializar.UrlBaseApi}api/siaes/registro", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = (JObject)JsonConvert.DeserializeObject(contentTemp);

            if (response.IsSuccessStatusCode)
            {
                var Token = resultado["result"]["token"].Value<string>();
                var Usuario = resultado["result"]["usuario"]["nombreUsuario"].Value<string>();

                await _localStorage.SetItemAsync(Inicializar.Token_Local, Token);
                await _localStorage.SetItemAsync(Inicializar.Datos_Usuario_Local, Usuario);
                ((AuthStateProvider)_estadoProveedorAutenticacion).NotificarUsuarioLogueado(Token);
                _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);

                // Devolver la tupla esperada
                return (true, null);
            }
            else
            {
                // Devolver la tupla esperada con el error
                return (false, new List<string> { "Error al registrar usuario" });
            }
        }


        public async Task<RespuestaRegistro> RegistrarUsuario(UsuarioRegistro usuarioParaRegistro)
        {
            var content = JsonConvert.SerializeObject(usuarioParaRegistro);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _cliente.PostAsync($"{Inicializar.UrlBaseApi}api/siaes/registro", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<RespuestaRegistro>(contentTemp);
            try
            {
                if (!response.IsSuccessStatusCode)
                {
                    var errores = await response.Content.ReadAsStringAsync();
                    return new RespuestaRegistro { registroCorrecto = false, Errores = new List<string> { errores } };
                }
                else
                {
                    return new RespuestaRegistro { registroCorrecto = true };
                }
            }
            catch (Exception ex)
            {
                // manejar excepción
                return new RespuestaRegistro { registroCorrecto = false, Errores = new List<string> { ex.Message } };
            }
        }


        public async Task<RespuestaRegistro> RegistrarUsuarioAPI(UsuarioParaRegistroAPI usuarioParaRegistro)
        {
            // Obtener el token de autenticación desde el almacenamiento local
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);

            // Verificar si el token está disponible
            if (string.IsNullOrEmpty(token))
            {
                // Si el token no está disponible, puedes manejar el caso de acuerdo a tus necesidades
                // Por ejemplo, puedes devolver un error o redirigir al usuario a la página de inicio de sesión
                return new RespuestaRegistro { registroCorrecto = false, Errores = new List<string> { "No se encontró el token de autenticación" } };
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = JsonConvert.SerializeObject(usuarioParaRegistro);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{Inicializar.UrlBaseApi}api/siaes/registro", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();

            try
            {
                if (!response.IsSuccessStatusCode)
                {
                    var errores = await response.Content.ReadAsStringAsync();
                    return new RespuestaRegistro { registroCorrecto = false, Errores = new List<string> { errores } };
                }
                else
                {
                    var resultado = JsonConvert.DeserializeObject<RespuestaRegistro>(contentTemp);
                    return new RespuestaRegistro { registroCorrecto = true };
                }
            }
            catch (Exception ex)
            {
                // manejar excepción
                return new RespuestaRegistro { registroCorrecto = false, Errores = new List<string> { ex.Message } };
            }
        }

        public Task<RespuestaRegistro> RegistrarUsuario(Usuario usuarioParaRegistro)
        {
            throw new NotImplementedException();
        }



        public async Task Salir()
        {
            await _localStorage.RemoveItemAsync(Inicializar.Token_Local);
            await _localStorage.RemoveItemAsync(Inicializar.Datos_Usuario_Local);
            ((AuthStateProvider)_estadoProveedorAutenticacion).NotificarUsuarioSalir();
            _cliente.DefaultRequestHeaders.Authorization = null;
        }

        Task IServicioAutenticacion.RegistrarUsuario(UsuarioParaRegistroAPI usuarioParaRegistroAPI)
        {
            throw new NotImplementedException();
        }
    }
}
