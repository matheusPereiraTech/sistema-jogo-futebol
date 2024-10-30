using sistema_jogo_futebol.@interface;

namespace sistema_jogo_futebol.observer
{
    public class PlacarObservador : IObservadorJogo
    {
        public void Atualizar(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}
