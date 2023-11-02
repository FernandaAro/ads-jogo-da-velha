using System;

namespace jogoDaVelha
{
    class Program
    {
        public static void Main(string[] args)
        {
            char[,] tabuleiro = new char[3, 3];
            int linha;
            int coluna;
            bool fimJogo = false;
            int jogador = 1;
            int jogada = 0;

            //preencher o tabuleiro com espaços em branco
            for (int l = 0; l < 3; l++)
                for (int c = 0; c < 3; c++)
                    tabuleiro[l, c] = ' ';

            //gerando tabuleiro
            do
            {
                imprimirTabuleiro(tabuleiro);

                //interação do usuário
                if (jogador == 1)
                    Console.Write("Jogador 1: \n");
                else
                    Console.Write("Jogador 2: \n");

                Console.Write("Selecione uma linha [1-3]: ");
                linha = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Seleciona uma coluna [1-3]: ");
                coluna = Convert.ToInt32(Console.ReadLine()) - 1;
                jogada++;

                //validando os acontecimento da jogada realizada
                fimJogo = conferirJogada(tabuleiro, linha, coluna, jogador, jogada);

                //troca de jogador
                if (jogador == 1)
                    jogador = 2;
                else
                    jogador = 1;
            } while (!fimJogo);
        }
        static void imprimirTabuleiro(char[,] tabuleiro)
        {
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Console.Write(string.Format("{0}", tabuleiro[l, c]));
                    if (c < 2)
                        Console.Write("|");
                }
                Console.Write(Environment.NewLine);
                if (l < 2)
                    Console.Write("-----");
                Console.Write(Environment.NewLine);
            }
        }
        static bool conferirJogada(char[,] tabuleiro, int linha, int coluna, int jogador, int jogada)
        {
            bool trinca = false;

            if (jogador == 1)
                tabuleiro[linha, coluna] = 'X';
            else
                tabuleiro[linha, coluna] = 'O';

            //verificar linha
            for (int c = 0; c < 3; c++)
            {
                if (tabuleiro[linha, c] != tabuleiro[linha, coluna])
                    break;
                if (c == 2)
                    trinca = true;
            }

            //verificar coluna
            if (!trinca)
            {
                if (linha == coluna)
                {
                    for (int cont = 0; cont < 3; cont++)
                    {
                        if (tabuleiro[cont, cont] != tabuleiro[linha, coluna])
                            break;
                        if (cont == 2)
                            trinca = true;
                    }
                }
            }

            //verificar diagonal 1
            if (!trinca)
            {
                if (linha == coluna)
                {
                    for (int cont = 0; cont < 3; cont++)
                    {
                        if (tabuleiro[cont, cont] != tabuleiro[linha, coluna])
                            break;
                        if (cont == 2)
                            trinca = true;
                    }
                }
            }

            //verificar diagonal 2
            if (!trinca)
            {
                if (linha + coluna == 3 - 1)
                {
                    for (int cont = 0; cont < 3; cont++)
                    {
                        if (tabuleiro[cont, 3 - cont - 1] != tabuleiro[linha, coluna])
                            break;
                        if (cont == 2)
                            trinca = true;
                    }
                }
            }

            if (trinca)
            {
                Console.WriteLine();
                imprimirTabuleiro(tabuleiro);
                Console.Write("Jogador " + jogador + " venceu!!! \n\n");
                return true;
            }

            if (jogada == 9)
            {
                Console.WriteLine();
                imprimirTabuleiro(tabuleiro);
                Console.Write("Empate! \n\n");
                return true;
            }

            else
            {
                Console.Write("\n Próximao jogador... \n\n");
                return false;
            }
        }
    }
}
