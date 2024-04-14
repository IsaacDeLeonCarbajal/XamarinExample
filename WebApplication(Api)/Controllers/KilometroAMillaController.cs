using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication_Api_.Controllers
{
    public class KilometroAMillaController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ConvertirKilometrosAMillas(double kilometros)
        {
            // Convertir kilómetros a millas
            double millas = kilometros * 0.621371;

            // Crear el mensaje de respuesta con el resultado
            var response = Request.CreateResponse(HttpStatusCode.OK, $"{kilometros} kilómetros son aproximadamente {millas} millas.");

            // Devolver la respuesta HTTP
            return response;
        }
    }
}