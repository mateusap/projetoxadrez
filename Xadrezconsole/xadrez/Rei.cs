using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiroetc;

namespace xadrez
{
    internal class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor, Partida partida) : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "R";
        }
        private bool podeMover (Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentoPossivel()
        {
            bool[,] matriz = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);
            //cima
            pos.definirValor(posicao.linha - 1, posicao.coluna);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //ne
            pos.definirValor(posicao.linha - 1, posicao.coluna+1);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //direita
            pos.definirValor(posicao.linha, posicao.coluna+1);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //se
            pos.definirValor(posicao.linha + 1, posicao.coluna+1);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //baixo
            pos.definirValor(posicao.linha +1, posicao.coluna);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //so
            pos.definirValor(posicao.linha + 1, posicao.coluna-1);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //esquerda
            pos.definirValor(posicao.linha, posicao.coluna-1);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //no
            pos.definirValor(posicao.linha - 1, posicao.coluna-1);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            return matriz;
        }
    }
}
