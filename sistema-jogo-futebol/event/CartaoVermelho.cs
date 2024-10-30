using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public class CartaoVermelho : EventoJogo
    {
        public Jogador Jogador { get; private set; }

        public CartaoVermelho(Time time, Jogador jogador, int minuto) : base(time)
        {
            Jogador = jogador;
            Minuto = minuto;
        }

        public override void Executar(Jogo jogo)
        {
            jogo.CartaoVermelho(Time, Jogador);
        }
    }
}
