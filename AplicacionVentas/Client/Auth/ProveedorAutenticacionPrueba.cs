using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AplicacionVentas.Client.Auth
{
    public class ProveedorAutenticacionPrueba : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimo = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("llave1", "valor1"),
                new Claim(ClaimTypes.Name, "Enrique"),
                new Claim(ClaimTypes.Role, "admin")
            }, "prueba");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimo)));
        }
    }
}
