using sistema_jogo_futebol.@interface;

namespace sistema_jogo_futebol.model
{
    public class Jogador(string nome, int numero, string posicao) : IComponenteTime
    {
        public string Nome { get; set; } = nome;
        public int Numero { get; set; } = numero;
        public string Posicao { get; set; } = posicao;

        public void ExibirDetalhes()
        {
            Console.WriteLine($"{Posicao} {Numero} - {Nome}");
        }
    }
}
