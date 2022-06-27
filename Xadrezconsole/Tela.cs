using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiroetc;

namespace Xadrezconsole
{
    internal class Tela
    {
        public static void printTabuleiro (Tabuleiro tab)
        {
            for (int i=0; i<tab.linha; i++)
            {
                for (int j = 0; j < tab.coluna; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.peca(i, j) + " ");
                    }
                }
                Console.WriteLine();
                }
            }
        }
}
