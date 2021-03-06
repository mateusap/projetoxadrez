using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiroetc
{
    internal abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtmovimento { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.qtmovimento = qtmovimento = 0;
            this.tab = tab;
        }
        public void incrementarmovimento()
        {
            qtmovimento++;
        }
        public void decrementarmovimento()
        {
            qtmovimento--;
        }
        public bool existemovimento()
        {
            bool[,] matriz = movimentoPossivel();
            for (int i=0; i<tab.linhas; i++)
            {
                for (int j=0; j<tab.colunas; j++)
                {
                    if (matriz[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool existeMovimento(Posicao pos)
        {
            return movimentoPossivel()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentoPossivel();
    }
}
