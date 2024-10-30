using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public class Substituicao : EventoJogo
    {
        public Jogador JogadorSai { get; private set; }
        public Jogador JogadorEntra { get; private set; }

        public Substituicao(Time time, Jogador jogadorSai, Jogador jogadorEntra, int minuto) : base(time)
        {
            JogadorSai = jogadorSai;
            JogadorEntra = jogadorEntra;
            Minuto = minuto;
        }

        public override void Executar(Jogo jogo)
        {
            jogo.Substituir(Time, JogadorSai, JogadorEntra);
        }
    }
}
