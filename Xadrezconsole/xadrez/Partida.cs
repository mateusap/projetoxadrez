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
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
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
            tab.posicionar(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            movimenta(origem, destino);
            turno++;
            mudaJogador();
        }
        public void validarOrigem (Posicao pos)
        {
            if (tab.peca(pos)==null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida, aperte enter para continuar.");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua, aperte enter para continuar.");
            }
            if (!tab.peca(pos).existemovimento())
            {
                throw new TabuleiroException("A peça não pode se mover, aperte enter para continuar.");
            }
        }
        public void validarDestino (Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMover(destino))
            {
                throw new TabuleiroException("Destino inválido, aperte enter para continuar.");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
        private void posicionar()
        {
            tab.posicionar(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tab.posicionar(new Rei(tab, Cor.Preta), new PosicaoXadrez('d',4).toPosicao());
        }
    }
}

 