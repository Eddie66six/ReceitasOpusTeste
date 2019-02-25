namespace ReceitasOpusTeste.core.Dominio.Entidades
{
    public abstract class EntidadeBase : EventoMensagem
    {
        protected abstract void Validar();
    }
}