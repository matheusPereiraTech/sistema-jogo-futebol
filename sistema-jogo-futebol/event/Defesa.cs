using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public class Defesa : EventoJogo
    {
        public Jogador Jogador { get; private set; }

        public Defesa(Time time, Jogador jogador, int minuto) : base(time)
        {
            Jogador = jogador;
            Minuto = minuto;
        }

        public override void Executar(Jogo jogo)
        {
            jogo.Defesa(Time, Jogador);
        }
    }
}
