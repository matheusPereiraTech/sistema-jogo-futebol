using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.builder
{
    public class TimeBuilder(string nomeTime)
    {
        private Time Time = new(nomeTime);

        public TimeBuilder AdicionarJogador(string nome, int numero, string posicao)
        {
            Time.AdicionarJogador(new Jogador(nome, numero, posicao));
            return this;
        }

        public Time Build()
        {
            return Time;
        }
    }
}
