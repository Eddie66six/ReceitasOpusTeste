using System.Collections.Generic;

namespace ReceitasOpusTeste.core.Dominio.Entidades
{
    public sealed class Ingrediente : EntidadeBase
    {
        //entity framework
        private Ingrediente() { }
        /// <summary>
        /// Utilizado apenas para o migrations
        /// </summary>
        /// <param name="idIngrediente"></param>
        /// <param name="nome"></param>
        public Ingrediente(int idIngrediente, string nome)
        {
            IdIngrediente = idIngrediente;
            Nome = nome;
            Validar();
        }
        public Ingrediente(string nome)
        {
            Nome = nome;
            Validar();
        }
        protected override void Validar()
        {
            if (Nome?.Length < 2)
                AddErro("Nome deve ter no minimo 3 caracteres");
        }
        public int IdIngrediente { get; private set; }
        public string Nome { get; private set; }
        public ICollection<IngredienteReceita> Receitas { get; private set; }
    }
}
