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
            var timeCasa = new TimeBuilder("Guarani")
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
               .AdicionarJogador("Ricardo", 11, "Atacante")
            .Build();

            var timeVisitante = new TimeBuilder("Ferroviária")
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

            var jogo = Jogo.Instancia;
            var placarObservador = new PlacarObservador();
            jogo.RegistrarObservador(placarObservador);

            jogo.IniciarJogo(timeCasa, timeVisitante);

            var random = new Random();

            for (int minuto = 1; minuto <= 90; minuto++)
            {
                jogo.AvancarMinuto();
                Console.WriteLine($"Minuto {minuto}");

                var jogadorAleatorioCasa = timeCasa.Jogador[random.Next(timeCasa.Jogador.Count)];
                var jogadorAleatorioVisitante = timeVisitante.Jogador[random.Next(timeVisitante.Jogador.Count)];

                
                if (minuto == 15) {
                    jogo.ExecutarEvento(new ToqueDeBola(timeCasa, jogadorAleatorioCasa, minuto));
                    jogo.ExecutarEvento(new Gol(timeCasa, minuto));
                } 
                if (minuto == 30) jogo.ExecutarEvento(new CartaoAmarelo(timeCasa, timeCasa.Jogador[1], minuto));
                if (minuto == 45) jogo.Intervalo();
                if (minuto == 46) jogo.SegundoTempo();
                if (minuto == 60) jogo.ExecutarEvento(new Substituicao(timeVisitante, timeVisitante.Jogador[1], new Jogador("Novo Jogador", 12, "Defensor"), minuto));
                if (minuto == 75) {
                    jogo.ExecutarEvento(new ToqueDeBola(timeVisitante, jogadorAleatorioVisitante, minuto));
                    jogo.ExecutarEvento(new Gol(timeVisitante, minuto));
                } 
                if (minuto == 80) jogo.ExecutarEvento(new CartaoVermelho(timeVisitante, timeVisitante.Jogador[0], minuto));
            }

            Console.WriteLine("==========================================================================");
            Console.WriteLine("                        Jogo finalizado!                                ");
            Console.WriteLine("==========================================================================");
        }
    }
}