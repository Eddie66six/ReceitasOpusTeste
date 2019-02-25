using ReceitasOpusTeste.core.Dominio.Entidades;
using ReceitasOpusTeste.core.Infra;
using ReceitasOpusTeste.core.Infra.Repositorio;

namespace ReceitasOpusTeste.core.Aplicacao
{
    public class IngredienteAplicacao : BaseAplicacao
    {
        private readonly IngredienteRepositorio _ingredienteRepositorio;
        public IngredienteAplicacao(IngredienteRepositorio ingredienteRepositorio, UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _ingredienteRepositorio = ingredienteRepositorio;
        }

        public Ingrediente[] ObterIngredientes()
        {
            return _ingredienteRepositorio.ObterIngredientes();
        }
    }
}
