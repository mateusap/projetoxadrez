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
        public Peao(Tabuleiro tab, Cor cor, Partida partida) : base(tab, cor)
        {
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
            }
            return matriz;
        }
    }
}
