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
        public static void printTabuleiro (Tabuleiro tab)
        {
            for (int i=0; i<tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimir(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
                }
            Console.WriteLine("  A B C D E F G H");
            }
        public static PosicaoXadrez lerPosicao()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void imprimir (Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(peca);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ResetColor();
            }
        }
        }
}
