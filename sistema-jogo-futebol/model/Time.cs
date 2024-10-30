using sistema_jogo_futebol.@interface;

namespace sistema_jogo_futebol.model
{
    public class Time(string nome) : IComponenteTime
    {
        public string Nome { get; set; } = nome;
        public List<Jogador> Jogador = [];

        public void AdicionarJogador(Jogador componente)
        {
            if (!Jogador.Contains(componente))
                Jogador.Add(componente);
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"Escalação do {Nome}:");
            foreach (var componente in Jogador)
            {
                componente.ExibirDetalhes();
            }
        }
    }
}
