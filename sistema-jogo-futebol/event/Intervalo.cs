using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public class Intervalo : EventoJogo
    {
        public Intervalo(int minuto) : base(null)
        {
            Minuto = minuto;
        }

        public override void Executar(Jogo jogo)
        {
            jogo.Intervalo();
        }
    }
}
