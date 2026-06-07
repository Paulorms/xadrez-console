using tabuleiro;
using xadrez;
using xadrez;

namespace xadrez_console;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            PartidaDeXadrex partida = new PartidaDeXadrex();

            while (!partida.terminada)
            {
                try
                {
                    Console.Clear();
                    Tela.ImprimirPartida(partida);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeOrigem(origem);

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.realizaJogada(origem, destino);
                }
                catch (TabuleiroExceptions e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                    Console.WriteLine("PRESSIONE [ENTER] PARA CONTINUAR.");
                    Console.ReadLine();
                }
            }

            Console.Clear();
            Tela.ImprimirPartida(partida);
        }
        catch (TabuleiroExceptions e)
        {
            Console.WriteLine(e.Message);
        }
    }
}