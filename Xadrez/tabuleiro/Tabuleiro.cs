﻿using System.Security.Cryptography.X509Certificates;
using xadrez;



namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas {  get; set; }

        public int Colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[Linhas, Colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao posicao)
        {
            return pecas[posicao.Linha , posicao.Coluna];
        }

        public void colocarPeca(Peca p , Posicao pos)
        {
            if ( existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!! ");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.Linha , pos.Coluna] = null;
            return aux;
        }


        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }


        public bool posicaoValida(Posicao pos)
        {
            if ( pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas) {
                return false;
            }
            return true;

            
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Invalid Position");
            }
        }
    }
}
