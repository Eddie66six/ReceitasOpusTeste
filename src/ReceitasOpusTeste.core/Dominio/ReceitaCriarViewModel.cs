namespace ReceitasOpusTeste.core.Dominio
{
    public class ReceitaCriarViewModel
    {
        public string Nome { get; set; }
        public int Porcoes { get; set; }
        public float Calorias { get; set; }
        public string ModoDePreparo { get; set; }
        public int[] IdsIngredientes { get; set; }
    }
}