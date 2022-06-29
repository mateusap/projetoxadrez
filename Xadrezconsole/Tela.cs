using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiroetc;
using xadrez;

namespace Xadrezconsole
{
    internal class Tela
    {
        public static void imprimirPartida(Partida partida)
        {
            printTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno:" + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Jogador atual:" + partida.jogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("XEQUE MATE!");
                Console.WriteLine("Vendedor: "+ partida.jogadorAtual);
            }
        }
        public static void imprimirCapturadas(Partida partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
        }
        public static void imprimirConjunto (HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void printTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimir(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void printTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor original = Console.BackgroundColor;
            ConsoleColor posicaopos = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = posicaopos;
                    }
                    else
                    {
                        Console.BackgroundColor = original;
                    }
                    imprimir(tab.peca(i, j));
                    Console.BackgroundColor = original;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.ResetColor();
        }
        public static PosicaoXadrez lerPosicao()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void imprimir(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(peca);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(peca);
                    Console.ResetColor();
                }
                Console.Write(" ");
            }
        }
    }
}
