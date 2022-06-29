using tabuleiroetc;
using Xadrezconsole;
using xadrez;

Partida partida = new Partida();
while (!partida.terminada)
{
    try
    {
        Console.Clear();
        Tela.imprimirPartida(partida);
        Console.Write("Origem:");
        Posicao origem = Tela.lerPosicao().toPosicao();
        partida.validarOrigem(origem);

        bool[,] posicaoPossivel = partida.tab.peca(origem).movimentoPossivel();

        Console.Clear();
        Tela.printTabuleiro(partida.tab, posicaoPossivel);

        Console.WriteLine();
        Console.Write("Destino:");
        Posicao destino = Tela.lerPosicao().toPosicao();
        partida.validarDestino(origem, destino);
        partida.realizaJogada(origem, destino);
    }
    catch (TabuleiroException e)
    {
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}
Console.Clear();
Tela.imprimirPartida(partida);