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
        private Partida partida;
        public Rei(Tabuleiro tab, Cor cor, Partida partida) : base(tab, cor)
        {
            this.partida = partida;
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
        private bool testeTorreRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtmovimento == 0;
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
            //roque pequeno 
            if (qtmovimento==0 && !partida.xeque)
            {
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if (tab.peca(p1)==null && tab.peca(p2) == null)
                    {
                        matriz[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
                //roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna -4);
                if (testeTorreRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3)==null)
                    {
                        matriz[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }
            return matriz;
        }
    }
}
