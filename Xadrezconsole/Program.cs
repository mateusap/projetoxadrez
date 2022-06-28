using tabuleiroetc;
using Xadrezconsole;
using xadrez;

Partida partida = new Partida();
while (!partida.terminada)
{
    Console.Clear();
    Tela.printTabuleiro(partida.tab);

    Console.WriteLine();
    Console.Write("Origem:");
    Posicao origem = Tela.lerPosicao().toPosicao();

    bool[,] posicaoPossivel = partida.tab.peca(origem).movimentoPossivel();

    Console.Clear();
    Tela.printTabuleiro(partida.tab, posicaoPossivel);

    Console.WriteLine();
    Console.Write("Destino:");
    Posicao destino = Tela.lerPosicao().toPosicao();
    partida.movimenta(origem, destino);
}