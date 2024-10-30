using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public class Escanteio : EventoJogo
    {
        public Jogador Jogador { get; private set; }

        public Escanteio(Time time, Jogador jogador, int minuto) : base(time)
        {
            Jogador = jogador;
            Minuto = minuto;
        }

        public override void Executar(Jogo jogo)
        {
            jogo.Escanteio(Time, Jogador);
        }
    }
}
