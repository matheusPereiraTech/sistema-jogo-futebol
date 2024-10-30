using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public class InicioSegundoTempo : EventoJogo
    {
        public InicioSegundoTempo(int minuto) : base(null)
        {
            Minuto = minuto;
        }
        public override void Executar(Jogo jogo)
        {
            jogo.SegundoTempo();
        }
    }
}
