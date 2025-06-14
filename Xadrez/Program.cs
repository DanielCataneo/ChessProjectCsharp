using System;
using tabuleiro;
using xadrez;



namespace Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);


                        Console.WriteLine();

                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoOrigem(origem);
                        
                      
                        

                        bool[,] jdsPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                       


                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, jdsPossiveis);

                        Console.WriteLine();
                        Console.WriteLine();

                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e )
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);

            }

            catch (TabuleiroException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            Console.ReadKey();



        }
    }
}
