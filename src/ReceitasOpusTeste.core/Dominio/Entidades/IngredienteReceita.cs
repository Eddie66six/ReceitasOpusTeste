namespace ReceitasOpusTeste.core.Dominio.Entidades
{
    public sealed class IngredienteReceita : EntidadeBase
    {
        //entity framework
        private IngredienteReceita(){}
        public IngredienteReceita(Receita receita, int idIngrediente)
        {
            Receita = receita;
            IdIngrediente = idIngrediente;
            Validar();
        }
        protected override void Validar()
        {
            if (Receita == null || IdIngrediente == 0)
                AddErro("Erro");
        }
        public int IdReceita { get; private set; }
        public Receita Receita { get; private set; }
        public int IdIngrediente { get; private set; }
        public Ingrediente Ingrediente { get; private set; }
    }
}
