namespace ReceitasOpusTeste.core.Infra.Repositorio
{
    public class BaseResitorio
    {
        protected readonly Contexto _Db;
        public BaseResitorio(Contexto contexto)
        {
            _Db = contexto;
        }
    }
}