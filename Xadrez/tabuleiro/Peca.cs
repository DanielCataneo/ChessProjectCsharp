


using xadrez;

namespace tabuleiro
{
    abstract class Peca
    {


        public Posicao posicao { get; set; }

        public Cor Cor { get; protected set; }

        public int QtdMovimentos { get; protected set; }

        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            posicao = null;
            Cor = cor;
            QtdMovimentos = 0;
            this.tab = tab;
        }

       

        public void incrementarQteMovimentos()
        {
            QtdMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            QtdMovimentos--;
        }


        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.Linha, pos.Coluna];
        }


        public abstract bool[,] movimentosPossiveis();
        
    }

}
