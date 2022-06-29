using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiroetc;

namespace xadrez
{
    internal  class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "B";
        }
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentoPossivel()
        {
            bool[,] matriz = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //no
            pos.definirValor(posicao.linha - 1, posicao.coluna - 1);
            while (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValor(pos.linha - 1, pos.coluna - 1);
            }
            //ne
            pos.definirValor(posicao.linha - 1, posicao.coluna + 1);
            while (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValor(pos.linha - 1, pos.coluna + 1);
            }
            //se
            pos.definirValor(posicao.linha + 1, posicao.coluna + 1);
            while (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValor(pos.linha + 1, pos.coluna + 1);
            }
            //so
            pos.definirValor(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValor(pos.linha + 1, pos.coluna - 1);
            }
            return matriz;
        }
    }
}
