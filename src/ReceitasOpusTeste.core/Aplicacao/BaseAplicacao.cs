using ReceitasOpusTeste.core.Infra;

namespace ReceitasOpusTeste.core.Aplicacao
{
    public class BaseAplicacao: EventoMensagem
    {
        private readonly UnitOfWork _unitOfWork;
        public BaseAplicacao(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected bool Commit()
        {
            return _unitOfWork.Commit();
        }
    }
}