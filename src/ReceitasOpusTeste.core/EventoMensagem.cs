using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ReceitasOpusTeste.core
{
    public class EventoMensagem : IDisposable
    {
        private static List<MensagemModelo> _domainEventContainer;

        public void AddErro(string mensagem, string detalhes = null, [CallerMemberName] string nomeMetodoChamada = null)
        {
            if (_domainEventContainer == null) _domainEventContainer = new List<MensagemModelo>();
            _domainEventContainer.Add(new MensagemModelo(mensagem, detalhes, nomeMetodoChamada));
        }

        public void Dispose()
        {
            _domainEventContainer = null;
            GC.SuppressFinalize(this);
        }

        public MensagemModelo[] ObterMensagens()
        {
            return _domainEventContainer?.ToArray();
        }

        public bool ExisteErro()
        {
            return _domainEventContainer?.Any() ?? false;
        }
        public class MensagemModelo
        {
            public MensagemModelo(string mensagem, string detalhes, string metodo)
            {
                Mensagem = mensagem;
                Detalhes = detalhes;
                Metodo = metodo;
            }
            public string Mensagem { get; }
            public string Detalhes { get; set; }
            public string Metodo { get; }
        }
    }
}