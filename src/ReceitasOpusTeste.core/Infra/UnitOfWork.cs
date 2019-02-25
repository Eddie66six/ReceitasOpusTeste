using System;

namespace ReceitasOpusTeste.core.Infra
{
    public class UnitOfWork : EventoMensagem
    {
        private readonly Contexto _context;
        public UnitOfWork(Contexto context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                if (ExisteErro()) return false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                AddErro(e.Message, e.InnerException.Message);
                return false;
            }
        }
    }
}