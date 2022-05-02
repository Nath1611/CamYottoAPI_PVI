using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CamYottoAPI.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.All)]

    public sealed class ApiKeyAttribute : Attribute, IAsyncActionFilter 
    {
        //SE CREAN ANTRIBUTOS PARA LUEGO USAR COMO DECORACION PARA LOS CONTROLLERS E
        //INYECTARLE AL MECANISMO DE SEGURIDAD POR ApiKey PARA DARLE UN CAPA DE SEGURIDAD SIMPLE AL end points

        private const string NombreDelApiKey = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(NombreDelApiKey, out var ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "No se ha incluido una API key"
                };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var apikey = appSettings.GetValue<string>(NombreDelApiKey);

            if (!apikey.Equals(ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "La API Key suministrada no es la correcta."
                };
                return;
            }

            await next();

        }

    }
}
