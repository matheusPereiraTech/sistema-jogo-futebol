using sistema_jogo_futebol.@event;
using sistema_jogo_futebol.@interface;
using sistema_jogo_futebol.observer;

namespace sistema_jogo_futebol.model
{
    public class Jogo
    {
        private static Jogo InstanciaUnica;
        public Time TimeCasa { get; private set; }
        public Time TimeVisitante { get; private set; }
        public int GolsCasa { get; private set; }
        public int GolsVisitante { get; private set; }
        public string TempoAtual { get; private set; }
        public int MinutoAtual { get; private set; } = 0;

        private GerenciadorObservadores GerenciadorObservadores = new();

        private Jogo() { }

        public static Jogo Instancia => InstanciaUnica ??= new Jogo();

        public void RegistrarObservador(IObservadorJogo observador)
        {
            GerenciadorObservadores.RegistrarObservador(observador);
        }

        public void IniciarJogo(Time timeCasa, Time timeVisitante)
        {
            TimeCasa = timeCasa;
            TimeVisitante = timeVisitante;
            GolsCasa = 0;
            GolsVisitante = 0;
            TempoAtual = "Primeiro Tempo";
            MinutoAtual = 0;
            GerenciadorObservadores.Notificar("O jogo começou!");
        }

        public void MarcarGol(Time time)
        {
            if (time == TimeCasa)
                GolsCasa++;
            else if (time == TimeVisitante)
                GolsVisitante++;

            GerenciadorObservadores.Notificar($"Gol do {time.Nome} aos {MinutoAtual} minutos! Placar: {TimeCasa.Nome} {GolsCasa} x {GolsVisitante} {TimeVisitante.Nome}");
        }

        public void Intervalo()
        {
            TempoAtual = "Intervalo";
            GerenciadorObservadores.Notificar("Intervalo");
        }

        public void SegundoTempo()
        {
            TempoAtual = "Segundo Tempo";
            GerenciadorObservadores.Notificar("Início do segundo tempo!");
        }

        public void ExecutarEvento(EventoJogo evento)
        {
            evento.Executar(this);
        }

        public void AvancarMinuto()
        {
            MinutoAtual++;
        }

        public void CartaoAmarelo(Time time, Jogador jogador)
        {
            GerenciadorObservadores.Notificar($"Cartão Amarelo para {jogador.Nome} do {time.Nome} aos {MinutoAtual} minutos!");
        }

        public void ToqueDeBola(Time time, Jogador jogador)
        {
            GerenciadorObservadores.Notificar($"O Jogador {jogador.Nome} do {time.Nome} tocou a bola aos {MinutoAtual} minutos!");
        }

        public void CartaoVermelho(Time time, Jogador jogador)
        {
            GerenciadorObservadores.Notificar($"Cartão Vermelho para {jogador.Nome} do {time.Nome} aos {MinutoAtual} minutos!");
        }

        public void RouboDeBola(Time time, Jogador jogador)
        {
            GerenciadorObservadores.Notificar($"O jogador {jogador.Nome} do {time.Nome} roubou a bola aos {MinutoAtual} minutos!");
        }


        public void Substituir(Time time, Jogador jogadorSai, Jogador jogadorEntra)
        {
            GerenciadorObservadores.Notificar($"Substituição no {time.Nome}: {jogadorSai.Nome} saiu e {jogadorEntra.Nome} entrou aos {MinutoAtual} minutos!");
        }
    }
}
