using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public class Lateral : EventoJogo
    {
        public Jogador Jogador { get; private set; }

        public Lateral(Time time, Jogador jogador, int minuto) : base(time)
        {
            Jogador = jogador;
            Minuto = minuto;
        }

        public override void Executar(Jogo jogo)
        {
            jogo.Lateral(Time, Jogador);
        }
    }
}
