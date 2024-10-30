using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public class Gol : EventoJogo
    {
        public Gol(Time time, int minuto) : base(time)
        {
            Minuto = minuto;
        }

        public override void Executar(Jogo jogo)
        {
            jogo.MarcarGol(Time);
        }
    }
}
