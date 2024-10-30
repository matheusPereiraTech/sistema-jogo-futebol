using sistema_jogo_futebol.@interface;

namespace sistema_jogo_futebol.observer
{
    public class GerenciadorObservadores
    {
        private List<IObservadorJogo> observadores = [];

        public void RegistrarObservador(IObservadorJogo observador)
        {
            observadores.Add(observador);
        }

        public void Notificar(string mensagem)
        {
            foreach (var observador in observadores)
            {
                observador.Atualizar(mensagem);
            }
        }
    }
}
