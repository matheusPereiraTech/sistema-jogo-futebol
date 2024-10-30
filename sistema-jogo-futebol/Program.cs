using sistema_jogo_futebol.builder;
using sistema_jogo_futebol.@event;
using sistema_jogo_futebol.model;
using sistema_jogo_futebol.observer;

namespace sistema_jogo_futebol
{
    public class Programa
    {
        public static void Main(string[] args)
        {
            var timeCasa = ConfigurarTimeCasa();
            var timeVisitante = ConfigurarTimeVisitante();

            ExibirEscalacoes(timeCasa, timeVisitante);

            var jogo = Jogo.Instancia;
            var placarObservador = new PlacarObservador();
            jogo.RegistrarObservador(placarObservador);
            jogo.IniciarJogo(timeCasa, timeVisitante);

            ExecutarPartida(jogo, timeCasa, timeVisitante);
        }

        private static Time ConfigurarTimeCasa()
        {
            return new TimeBuilder("Guarani")
                .AdicionarJogador("João", 1, "Goleiro")
                .AdicionarJogador("Carlos", 2, "Defensor")
                .AdicionarJogador("Ricardo", 3, "Defensor")
                .AdicionarJogador("Lucas", 4, "Defensor")
                .AdicionarJogador("Marcelo", 5, "Defensor")
                .AdicionarJogador("Fernando", 6, "Meio-Campista")
                .AdicionarJogador("Thiago", 7, "Meio-Campista")
                .AdicionarJogador("André", 8, "Meio-Campista")
                .AdicionarJogador("Pedro", 9, "Atacante")
                .AdicionarJogador("Bruno", 10, "Atacante")
                .AdicionarJogador("Antonio", 11, "Atacante")
                .Build();
        }

        private static Time ConfigurarTimeVisitante()
        {
            return new TimeBuilder("Ferroviária")
                .AdicionarJogador("Lucas", 1, "Goleiro")
                .AdicionarJogador("André", 2, "Defensor")
                .AdicionarJogador("Gustavo", 3, "Defensor")
                .AdicionarJogador("Felipe", 4, "Defensor")
                .AdicionarJogador("Jorge", 5, "Defensor")
                .AdicionarJogador("Matheus", 6, "Volante")
                .AdicionarJogador("Diego", 7, "Volante")
                .AdicionarJogador("Samuel", 8, "Meio-Campista Ofensivo")
                .AdicionarJogador("Rafael", 9, "Meio-Campista Ofensivo")
                .AdicionarJogador("Vinícius", 10, "Meio-Campista Ofensivo")
                .AdicionarJogador("Tiago", 11, "Atacante")
                .Build();
        }

        private static void ExibirEscalacoes(Time timeCasa, Time timeVisitante)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine($"                      {timeCasa.Nome} - Escalação                      ");
            Console.WriteLine("==========================================================================");
            timeCasa.ExibirDetalhes();
            Console.WriteLine("\n");
            Console.WriteLine("==========================================================================");
            Console.WriteLine($"                   {timeVisitante.Nome} - Escalação                   ");
            Console.WriteLine("==========================================================================");
            timeVisitante.ExibirDetalhes();
            Console.WriteLine("\n");
            Console.WriteLine("==========================================================================");
        }

        private static void ExecutarPartida(Jogo jogo, Time timeCasa, Time timeVisitante)
        {
            var random = new Random();

            for (int minuto = 1; minuto <= 90; minuto++)
            {
                jogo.AvancarMinuto();
                ExecutarEventosEspecificos(minuto, jogo, timeCasa, timeVisitante);
            }

            Console.WriteLine("==========================================================================");
            Console.WriteLine("                        Jogo finalizado!                                ");
            Console.WriteLine("==========================================================================");
        }

        private static void ExecutarEventosEspecificos(int minuto, Jogo jogo, Time timeCasa, Time timeVisitante)
        {
            switch (minuto)
            {
                case 5:
                    EventoMinuto5(jogo, timeCasa, timeVisitante, minuto);
                    break;
                case 10:
                    EventoMinuto10(jogo, timeCasa, timeVisitante, minuto);
                    break;
                case 35:
                    EventoMinuto35(jogo, timeCasa, minuto);
                    break;
                case 45:
                    EventoIntervalo(jogo, timeVisitante, minuto);
                    break;
                case 46:
                    EventoMinuto46(jogo, timeCasa, minuto);
                    break;
                case 60:
                    EventoMinuto60(jogo, timeCasa, timeVisitante, minuto);
                    break;
                case 85:
                    EventoMinuto85(jogo, timeVisitante, minuto);
                    break;
                default:
                    Console.WriteLine($"Minuto {minuto}: Jogo em andamento");
                    break;
            }
        }

        private static void EventoMinuto5(Jogo jogo, Time timeCasa, Time timeVisitante, int minuto)
        {
            jogo.ExecutarEvento(new ToqueDeBola(timeCasa, timeCasa.Jogador[10], minuto));
            jogo.ExecutarEvento(new Chute(timeCasa, timeCasa.Jogador[3], minuto));
            jogo.ExecutarEvento(new Defesa(timeVisitante, timeVisitante.Jogador[0], minuto));
            Console.WriteLine("==========================================================================\n");
        }

        private static void EventoMinuto10(Jogo jogo, Time timeCasa, Time timeVisitante, int minuto)
        {
            jogo.ExecutarEvento(new RouboDeBola(timeVisitante, timeVisitante.Jogador[5], minuto));
            jogo.ExecutarEvento(new Chute(timeVisitante, timeVisitante.Jogador[5], minuto));
            jogo.ExecutarEvento(new Defesa(timeCasa, timeCasa.Jogador[0], minuto));
            jogo.ExecutarEvento(new Escanteio(timeCasa, timeCasa.Jogador[2], minuto));
            Console.WriteLine("==========================================================================\n");
        }

        private static void EventoMinuto35(Jogo jogo, Time timeCasa, int minuto)
        {
            jogo.ExecutarEvento(new Chute(timeCasa, timeCasa.Jogador[8], minuto));
            jogo.ExecutarEvento(new Gol(timeCasa, minuto));
            Console.WriteLine("==========================================================================\n");
        }

        private static void EventoIntervalo(Jogo jogo, Time timeVisitante, int minuto)
        {
            jogo.Intervalo();
            Console.WriteLine("==========================================================================\n");
            jogo.ExecutarEvento(new Substituicao(timeVisitante, timeVisitante.Jogador[7], "Peterson", minuto));
            Console.WriteLine("==========================================================================\n");
            jogo.SegundoTempo();
            Console.WriteLine("==========================================================================\n");
        }

        private static void EventoMinuto46(Jogo jogo, Time timeCasa, int minuto)
        {
            jogo.ExecutarEvento(new Falta(timeCasa, timeCasa.Jogador[1], minuto));
            jogo.ExecutarEvento(new CartaoAmarelo(timeCasa, timeCasa.Jogador[1], minuto));
            Console.WriteLine("==========================================================================\n");
        }

        private static void EventoMinuto60(Jogo jogo, Time timeCasa, Time timeVisitante, int minuto)
        {
            jogo.ExecutarEvento(new Lateral(timeVisitante, timeVisitante.Jogador[5], minuto));
            jogo.ExecutarEvento(new ToqueDeBola(timeVisitante, timeVisitante.Jogador[8], minuto));
            jogo.ExecutarEvento(new Chute(timeVisitante, timeVisitante.Jogador[5], minuto));
            jogo.ExecutarEvento(new Gol(timeVisitante, minuto));
            jogo.ExecutarEvento(new Falta(timeCasa, timeCasa.Jogador[1], minuto));
            jogo.ExecutarEvento(new CartaoVermelho(timeCasa, timeCasa.Jogador[1], minuto));
            Console.WriteLine("==========================================================================\n");
        }

        private static void EventoMinuto85(Jogo jogo, Time timeVisitante, int minuto)
        {
            jogo.ExecutarEvento(new ToqueDeBola(timeVisitante, timeVisitante.Jogador[6], minuto));
            jogo.ExecutarEvento(new Chute(timeVisitante, timeVisitante.Jogador[9], minuto));
            jogo.ExecutarEvento(new Gol(timeVisitante, minuto));
            Console.WriteLine("==========================================================================\n");
        }
    }
}
