using System;
using Microsoft.EntityFrameworkCore;
using ReceitasOpusTeste.core.Dominio.Entidades;
using System.Linq;

namespace ReceitasOpusTeste.core.Infra.Repositorio
{
    public class ReceitaRepositorio : BaseResitorio
    {
        public ReceitaRepositorio(Contexto contexto) : base(contexto)
        {
        }
        /// <summary>
        /// Cria uma nova receita
        /// </summary>
        /// <param name="receita"></param>
        public void CriarReceita(Receita receita)
        {
            _Db.Receitas.Add(receita);
        }
        /// <summary>
        /// Obtem todas as receitas criadas
        /// </summary>
        /// <returns></returns>
        public Receita[] ObterTodas()
        {
            return _Db.Receitas.AsNoTracking().ToArray();
        }
        /// <summary>
        /// Obtem uma receita por id (somente leitura)
        /// </summary>
        /// <param name="id">id receita</param>
        /// <returns></returns>
        public Receita ObterPorId(int id)
        {
            return _Db.Receitas.AsNoTracking().FirstOrDefault(p => p.IdReceita == id);
        }
        /// <summary>
        /// Obtem os ingredientes de uma receita
        /// </summary>
        /// <param name="id">id receita</param>
        /// <returns></returns>
        public Ingrediente[] ObterIngredientes(int id)
        {
            return _Db.Ingredientes.AsNoTracking().Where(p => p.Receitas.Any(i => i.IdReceita == id)).ToArray();
        }
        /// <summary>
        /// Obtem receitas que tenham algum determinado ingrediente
        /// </summary>
        /// <param name="id">id ingrediente</param>
        /// <returns></returns>
        public Receita[] ObterReceitasPorIdIngrediente(int id)
        {
            return _Db.Receitas.AsNoTracking().Where(p => p.Ingredientes.Any(i => i.IdIngrediente == id)).ToArray();
        }
        /// <summary>
        /// Obtem todos os ingredientes que estam em alguma receita
        /// </summary>
        /// <returns></returns>
        public Ingrediente[] ObterTodosIngredientesComReceita()
        {
            return _Db.Ingredientes.AsNoTracking().Where(p => p.Receitas.Any()).ToArray();
        }
    }
}