using Microsoft.AspNetCore.Mvc;
using ReceitasOpusTeste.core;
using System.Threading.Tasks;
using ReceitasOpusTeste.core.Aplicacao;
using ReceitasOpusTeste.core.Dominio;

namespace ReceitasOpusTeste.Api.Controllers
{
    [Route("api/receitas")]
    [ApiController]
    public class ReceitaController : BaseController
    {
        private readonly ReceitaAplicacao _receitaAplicacao;
        public ReceitaController(EventoMensagem eventoMensagem, ReceitaAplicacao receitaAplicacao) : base(eventoMensagem)
        {
            _receitaAplicacao = receitaAplicacao;
        }

        [HttpPost]
        [Route("")]
        public Task<ObjectResult> Criar(ReceitaCriarViewModel receita)
        {
            _receitaAplicacao.CriarReceita(receita);
            return CreateResponse(null);
        }
        [HttpGet]
        [Route("")]
        public Task<ObjectResult> ObterTodas()
        {
            return CreateResponse(_receitaAplicacao.ObterTodas());
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ObjectResult> ObterPorId(int id)
        {
            return CreateResponse(_receitaAplicacao.ObterPorId(id));
        }

        [HttpGet]
        [Route("{id}/ingredientes")]
        public Task<ObjectResult> ObterIngredientesDaReceita(int id)
        {
            return CreateResponse(_receitaAplicacao.ObterIngredientes(id));
        }

        [HttpGet]
        [Route("/-/ingredientes/{id}")]
        public Task<ObjectResult> ObtemReceitasPorIdIngrediente(int id)
        {
            return CreateResponse(_receitaAplicacao.ObterReceitasPorIdIngrediente(id));
        }

        [HttpGet]
        [Route("ingredientes")]
        public Task<ObjectResult> ObtemTodosOsIngredientesUtilizados()
        {
            return CreateResponse(_receitaAplicacao.ObterTodosIngredientesComReceita());
        }
    }
}