﻿using Microsoft.AspNetCore.Components;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using System.Text.RegularExpressions;
using System.Web;

namespace SiaesCliente.Pages.Autenticacion
{
    public  partial  class Acceder
    {
        private UsuarioAutenticacion usuarioAutenticacion = new UsuarioAutenticacion();
        public bool EstaProcesando { get; set; } = false;
        public bool MostrarErroresAutenticacion { get; set; }

        public string UrlRetorno { get; set; }

        public string Errores { get; set; }

        [Inject]
        public IServicioAutenticacion servicioAutenticacion { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }


        private async Task AccesoUsuario()
        {
            MostrarErroresAutenticacion = false;
            EstaProcesando = true;

        

            //var usuarioParaRegistroAPI = new UsuarioParaRegistroAPI
            //{
            //    nombreUsuario = usuarioAutenticacion.NombreUsuario,
            //    clave = usuarioAutenticacion.Clave,
            //    codEstablecimiento = usuarioAutenticacion.CodEstablecimiento,
            //    perfil = usuarioAutenticacion.Perfil,
            //};



            var result = await servicioAutenticacion.Acceder(usuarioAutenticacion);
            if (result.IsSuccess)
            {
                EstaProcesando = false;
                var urlAbsoluta = new Uri(navigationManager.Uri);
                var parametroQuery = HttpUtility.ParseQueryString(urlAbsoluta.Query);
                UrlRetorno = parametroQuery["returnUrl"];
                if(string.IsNullOrEmpty(UrlRetorno))
                {
                    navigationManager.NavigateTo("/");
                }
                else
                {
                    navigationManager.NavigateTo("/" + UrlRetorno);
                }
               

            }
            else
            {
                EstaProcesando = false;
                MostrarErroresAutenticacion = true;
                Errores = "Usuario y/o contraseña incorrecto";
                navigationManager.NavigateTo("/acceder");
            }
        }

        private string LimpiarYPrevenirInyeccion(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                valor = valor.Trim().ToLower();
                valor = Regex.Replace(valor, "<.*?>", String.Empty); // Elimina etiquetas HTML maliciosas
                valor = valor.Replace("*", ""); // Excluye el carácter '*' de la eliminación
            }
            return valor;
        }

    }
}
