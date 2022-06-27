using tabuleiroetc;
using Xadrezconsole;
using xadrez;

Tabuleiro tab = new Tabuleiro(8, 8);

tab.posicionar(new Torre(tab, Cor.Branca), new Posicao(3, 5));
tab.posicionar(new Bispo(tab, Cor.Preta), new Posicao(2, 2));
Tela.printTabuleiro(tab);
