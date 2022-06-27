using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiroetc
{
    internal class Tabuleiro
    {
        public int linha { get; set; }
        public int coluna { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
            pecas = new Peca[linha, coluna];
        }
        public Peca peca ( int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public bool casaOcupada (Posicao pos)
        {
            validar(pos);
            return peca(pos) != null;
        }
        private object peca(Posicao pos)
        {
            throw new NotImplementedException();
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
            if (pos.linha<0 || pos.coluna<0 || pos.linha >= linha || pos.coluna >= coluna)
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
    }
}
