using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public class ToqueDeBola : EventoJogo
    {
        public Jogador Jogador { get; private set; }

        public ToqueDeBola(Time time, Jogador jogador, int minuto) : base(time)
        {
            Jogador = jogador;
            Minuto = minuto;
        }

        public override void Executar(Jogo jogo)
        {
            jogo.ToqueDeBola(Time, Jogador);
        }
    }
}
