using System.Collections.Generic;
using System.Linq;

namespace ReceitasOpusTeste.core.Dominio.Entidades
{
    public sealed class Receita : EntidadeBase
    {
        //entity framework
        private Receita() { }
        public Receita(string nome, int porcoes, float calorias, string modoDePreparo, int[] idsIngredientes)
        {
            Nome = nome;
            Porcoes = porcoes;
            Calorias = calorias;
            ModoDePreparo = modoDePreparo;
            Ingredientes = new List<IngredienteReceita>(idsIngredientes?.Select(p=> new IngredienteReceita(this, p)));
            Validar();
        }
        protected override void Validar()
        {
            if (string.IsNullOrEmpty(Nome) || Nome?.Length < 2)
                AddErro("Nome deve ter no minimo 3 caracteres");
            if (Porcoes <= 0)
                AddErro("Porção deve ser no minimo 1");
            if (Calorias < 0)
                AddErro("Calorias não pode ser um numero negativo");
            if (ModoDePreparo?.Length < 50)
                AddErro("Modo de preparo deve ter no minimo 100 caracteres");
            if (Ingredientes?.Count < 1)
                AddErro("A receita de ter no minimo 1 ingrediente");
        }
        public int IdReceita { get; private set; }
        public string Nome { get; private set; }
        public int Porcoes { get; private set; }
        public float Calorias { get; private set; }
        public string ModoDePreparo { get; private set; }
        public ICollection<IngredienteReceita> Ingredientes { get; private set; }
    }
}
