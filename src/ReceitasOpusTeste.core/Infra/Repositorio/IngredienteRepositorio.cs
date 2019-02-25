using System.Linq;
using ReceitasOpusTeste.core.Dominio.Entidades;

namespace ReceitasOpusTeste.core.Infra.Repositorio
{
    public class IngredienteRepositorio : BaseResitorio
    {
        public IngredienteRepositorio(Contexto contexto) : base(contexto)
        {
        }
        public Ingrediente[] ObterIngredientes()
        {
            return _Db.Ingredientes.ToArray();
        }
    }
}