using ReceitasOpusTeste.core.Dominio;
using ReceitasOpusTeste.core.Dominio.Entidades;
using ReceitasOpusTeste.core.Infra;
using ReceitasOpusTeste.core.Infra.Repositorio;

namespace ReceitasOpusTeste.core.Aplicacao
{
    public class ReceitaAplicacao : BaseAplicacao
    {
        private readonly ReceitaRepositorio _receitaRepositorio;
        public ReceitaAplicacao(ReceitaRepositorio receitaRepositorio, UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _receitaRepositorio = receitaRepositorio;
        }

        /// <summary>
        /// Cria uma nova receita
        /// </summary>
        /// <param name="receita"></param>
        public void CriarReceita(ReceitaCriarViewModel receita)
        {
            if (receita == null)
            {
                AddErro("Receita invalida");
                return;
            }
            _receitaRepositorio.CriarReceita(new Receita(receita.Nome, receita.Porcoes,receita.Calorias, receita.ModoDePreparo, receita.IdsIngredientes));
            Commit();
        }
        /// <summary>
        /// Obtem todas as receitas criadas
        /// </summary>
        /// <returns></returns>
        public Receita[] ObterTodas()
        {
            return _receitaRepositorio.ObterTodas();
        }
        /// <summary>
        /// Obtem uma receita por id (somente leitura)
        /// </summary>
        /// <param name="id">id receita</param>
        /// <returns></returns>
        public Receita ObterPorId(int id)
        {
            return _receitaRepositorio.ObterPorId(id);
        }
        /// <summary>
        /// Obtem os ingredientes de uma receita
        /// </summary>
        /// <param name="id">id receita</param>
        /// <returns></returns>
        public Ingrediente[] ObterIngredientes(int id)
        {
            return _receitaRepositorio.ObterIngredientes(id);
        }
        /// <summary>
        /// Obtem receitas que tenham algum determinado ingrediente
        /// </summary>
        /// <param name="id">id ingrediente</param>
        /// <returns></returns>
        public Receita[] ObterReceitasPorIdIngrediente(int id)
        {
            return _receitaRepositorio.ObterReceitasPorIdIngrediente(id);
        }
        /// <summary>
        /// Obtem todos os ingredientes que estam em alguma receita
        /// </summary>
        /// <returns></returns>
        public Ingrediente[] ObterTodosIngredientesComReceita()
        {
            return _receitaRepositorio.ObterTodosIngredientesComReceita();
        }
    }
}