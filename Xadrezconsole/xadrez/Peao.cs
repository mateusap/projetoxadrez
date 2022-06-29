using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiroetc;

namespace xadrez
{
    internal class Peao : Peca
    {
        private Partida partida;
        public Peao(Tabuleiro tab, Cor cor, Partida partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        public override string ToString()
        {
            return "P";
        }
        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }
        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }
        public override bool[,] movimentoPossivel()
        {
            bool[,] matriz = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.definirValor(posicao.linha - 1, posicao.coluna);
                if (tab.posValida(pos) && livre(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
                pos.definirValor(posicao.linha - 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha - 1, posicao.coluna);
                if (tab.posValida(p2) && livre(p2) && tab.posValida(pos) && livre(pos) && qtmovimento == 0)
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
                pos.definirValor(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
                pos.definirValor(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                //en passant
                if (posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneveravelEnPassant)
                    {
                        matriz[esquerda.linha -1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneveravelEnPassant)
                    {
                        matriz[direita.linha-1, direita.coluna] = true;
                    }
                }
            }
            else
            {
                pos.definirValor(posicao.linha + 1, posicao.coluna);
                if (tab.posValida(pos) && livre(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
                pos.definirValor(posicao.linha + 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha + 1, posicao.coluna);
                if (tab.posValida(p2) && livre(p2) && tab.posValida(pos) && livre(pos) && qtmovimento == 0)
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
                pos.definirValor(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
                pos.definirValor(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
                //en passant
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneveravelEnPassant)
                    {
                        matriz[esquerda.linha+1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneveravelEnPassant)
                    {
                        matriz[direita.linha+1, direita.coluna] = true;
                    }
                }
            }
            return matriz;
        }
    }
}
