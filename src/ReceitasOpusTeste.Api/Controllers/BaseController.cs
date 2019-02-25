using Microsoft.AspNetCore.Mvc;
using ReceitasOpusTeste.core;
using System.Net;
using System.Threading.Tasks;

namespace ReceitasOpusTeste.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly EventoMensagem _eventoMensagem;
        public BaseController(EventoMensagem eventoMensagem)
        {
            _eventoMensagem = eventoMensagem;
        }
        public Task<ObjectResult> CreateResponse(object result, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return Task.FromResult(_eventoMensagem.ExisteErro() ? StatusCode((int)HttpStatusCode.BadRequest, _eventoMensagem.ObterMensagens()) : StatusCode((int)httpStatusCode, result));
        }
    }
}