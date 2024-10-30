using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public class Chute : EventoJogo
    {
        public Jogador Jogador { get; private set; }

        public Chute(Time time, Jogador jogador, int minuto) : base(time)
        {
            Jogador = jogador;
            Minuto = minuto;
        }

        public override void Executar(Jogo jogo)
        {
            jogo.Chute(Time, Jogador);
        }
    }
}
