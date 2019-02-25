using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReceitasOpusTeste.core;
using ReceitasOpusTeste.core.Aplicacao;

namespace ReceitasOpusTeste.Api.Controllers
{
    [Route("api/ingredientes")]
    [ApiController]
    public class IngredienteController : BaseController
    {
        private readonly IngredienteAplicacao _ingredienteAplicacao;
        public IngredienteController(EventoMensagem eventoMensagem, IngredienteAplicacao ingredienteAplicacao) : base(eventoMensagem)
        {
            _ingredienteAplicacao = ingredienteAplicacao;
        }

        [HttpGet]
        [Route("")]
        public Task<ObjectResult> ObterTodosIngredientes()
        {
            return CreateResponse(_ingredienteAplicacao.ObterIngredientes());
        }
    }
}