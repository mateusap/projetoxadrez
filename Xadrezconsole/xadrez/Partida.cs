using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiroetc;

namespace xadrez
{
    internal class Partida
    {
        public Tabuleiro tab { get; set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }
        public Partida()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            posicionar();
        }
        public void movimenta(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirar(origem);
            p.incrementarmovimento();
            Peca capturada = tab.retirar(destino);
            tab.posicionar(p, destino);
        }
        private void posicionar()
        {
            tab.posicionar(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tab.posicionar(new Rei(tab, Cor.Preta), new PosicaoXadrez('d',4).toPosicao());
        }
    }
}

 