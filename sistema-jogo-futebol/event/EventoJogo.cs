using sistema_jogo_futebol.model;

namespace sistema_jogo_futebol.@event
{
    public abstract class EventoJogo
    {
        public Time Time { get; private set; }
        public int Minuto { get; set; }
        public string Descricao { get; protected set; }

        protected EventoJogo(Time time)
        {
            Time = time;
        }

        public abstract void Executar(Jogo jogo);
    }
}
