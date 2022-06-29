﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiroetc;

namespace xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "C";
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

            pos.definirValor(posicao.linha - 1, posicao.coluna - 2);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            pos.definirValor(posicao.linha - 2, posicao.coluna - 1);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            pos.definirValor(posicao.linha - 2, posicao.coluna + 1);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            pos.definirValor(posicao.linha - 1, posicao.coluna + 2);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            pos.definirValor(posicao.linha + 1, posicao.coluna + 2);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            pos.definirValor(posicao.linha + 2, posicao.coluna + 1);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            pos.definirValor(posicao.linha + 2, posicao.coluna - 1);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            pos.definirValor(posicao.linha + 1, posicao.coluna - 2);
            if (tab.posValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            return matriz;
        }
    }
}
