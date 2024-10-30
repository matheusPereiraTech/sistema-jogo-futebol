using sistema_jogo_futebol.@event;
using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol
{
    public class RouboDeBola : EventoJogo
    {
        public Jogador Jogador { get; private set; }

        public RouboDeBola(Time time, Jogador jogador, int minuto) : base(time)
        {
            Jogador = jogador;
            Minuto = minuto;
        }

        public override void Executar(Jogo jogo)
        {
            jogo.RouboDeBola(Time, Jogador);
        }
    }
}
