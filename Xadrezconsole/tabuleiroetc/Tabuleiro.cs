using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez;

namespace tabuleiroetc
{
    internal class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        public Peca peca ( int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca (Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }
        public bool casaOcupada(Posicao pos)
        {
            validar(pos);
            return peca(pos) != null;
        }
        public void posicionar (Peca p, Posicao pos)
        {
            if (casaOcupada(pos))
            {
                throw new TabuleiroException("Essa casa já está ocupada");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }
        public bool posValida (Posicao pos)
        {
            if (pos.linha<0 || pos.coluna<0 || pos.linha >= linhas || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }
        public void validar (Posicao pos)
        {
            if (!posValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }

        internal void posicionar(Torre torre)
        {
            throw new NotImplementedException();
        }
    }
}
