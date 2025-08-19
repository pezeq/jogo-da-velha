namespace Jogo_da_Velha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool validEntry = true;

            do
            {
                HeaderScene();
                Console.WriteLine("DESEJA INICIAR O JOGO?");
                Console.WriteLine("( 1 ) SIM / ( 0 ) SAIR");
                Console.Write("\nESCOLHA UMA OPÇÃO: ");
                string menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        Game();
                        break;
                    case "0":
                        validEntry = false;
                        break;
                    default:
                        Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                        Console.ReadKey();
                        break;
                }
            } while (validEntry);

            HeaderScene();
            Console.WriteLine("ENCERRANDO JOGO DA VELHA...");
        }

        static void Game()
        {
            char[] positions = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool gameOver = false;
            string winnerPlayer = "";
            int rounds = 0;

            HeaderScene();

            Console.Write("Digite o nome do jogador 1 (X): ");
            string player1 = Console.ReadLine().ToUpper();

            Console.Write("Digite o nome do jogador 2 (O): ");
            string player2 = Console.ReadLine().ToUpper();

            HeaderScene();
            StartScene(player1, player2);
            Console.Clear();

            do
            {
                rounds++;

                if (string.IsNullOrEmpty(winnerPlayer))
                {
                    bool validEntry = false;

                    if (Draw(positions, 'X', 'O'))
                    {
                        winnerPlayer = "Deu Velha!";
                        gameOver = true;
                    }
                    else if (WhoWon(positions, 'O'))
                    {
                        winnerPlayer = player2;
                        gameOver = true;
                    }
                    else
                    {
                        PlayerMove(validEntry, positions, player1, 'X');
                    }
                }

                if (string.IsNullOrEmpty(winnerPlayer))
                {
                    bool validEntry = false;

                    if (Draw(positions, 'X', 'O'))
                    {
                        winnerPlayer = "Deu Velha!";
                        gameOver = true;
                    }
                    else if (WhoWon(positions, 'X'))
                    {
                        winnerPlayer = player1;
                        gameOver = true;
                    }
                    else
                    {
                        PlayerMove(validEntry, positions, player2, 'O');
                    }
                }
            } while (!gameOver);

            EndScene(player1, player2, winnerPlayer, rounds);
        }

        static void HeaderScene()
        {
            Console.Clear();
            Console.WriteLine(@"##########################################################################
#        _                         _        __     __   _ _              #
#       | | ___   __ _  ___     __| | __ _  \ \   / /__| | |__   __ _    #
#    _  | |/ _ \ / _` |/ _ \   / _` |/ _` |  \ \ / / _ \ | '_ \ / _` |   #
#   | |_| | (_) | (_| | (_) | | (_| | (_| |   \ V /  __/ | | | | (_| |   #
#    \___/ \___/ \__, |\___/   \__,_|\__,_|    \_/ \___|_|_| |_|\__,_|   #
#                |___/                                                   #
##########################################################################
powered by pedro ezequiel   |   @pezeq   |   ezeq/softwares    ___    v1.0
");
        }

        static void StartScene(string player1, string player2)
        {
            Console.WriteLine($"--------------------------------------------------------------------------");
            Console.WriteLine($"Sejam bem-vindos: {player1} (X) e {player2} (O).");
            Console.WriteLine($"--------------------------------------------------------------------------\n");

            Console.WriteLine("PRESSIONE ALGUMA TECLA PARA COMEÇAR O JOGO...");
            Console.ReadKey();
        }

        static void TicTacToe(char[] positions)
        {
            Console.Write($" {positions[0]} "); Console.Write(" | "); Console.Write($" {positions[1]} "); Console.Write(" | "); Console.WriteLine($" {positions[2]} ");
            Console.WriteLine("----+-----+----");

            Console.Write($" {positions[3]} "); Console.Write(" | "); Console.Write($" {positions[4]} "); Console.Write(" | "); Console.WriteLine($" {positions[5]} ");
            Console.WriteLine("----+-----+----");

            Console.Write($" {positions[6]} "); Console.Write(" | "); Console.Write($" {positions[7]} "); Console.Write(" | "); Console.WriteLine($" {positions[8]} ");
            Console.WriteLine("");
        }

        static void PlayerMove(bool validEntry, char[] positions, string player, char symbol)
        {
            while (!validEntry)
            {
                Console.Clear();
                TicTacToe(positions);
                char playerOption;
                Console.WriteLine($"É a vez do {player} ({symbol}) jogar.\n");

                while (true)
                {
                    Console.Write($"ESCOLHA UMA POSIÇÃO VAZIA: ");
                    string input = Console.ReadLine();

                    if (input?.Length == 1)
                    {
                        playerOption = input[0];
                        break;
                    }
                }

                for (int i = 0; i < positions.Length; i++)
                {
                    if (positions[i] == playerOption)
                    {
                        Console.Clear();
                        positions[i] = symbol;
                        validEntry = true;
                        break;
                    }
                }
            }
        }

        static bool WhoWon(char[] positions, char symbol)
        {
            int[,] combos = new int[,]
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8},
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8},
                {0, 4, 8}, {2, 4, 6}
            };

            for (int i = 0; i < combos.GetLength(0); i++)
            {
                if (positions[combos[i, 0]] == symbol &&
                    positions[combos[i, 1]] == symbol &&
                    positions[combos[i, 2]] == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        static bool Draw(char[] positions, char symbolX, char symbolO)
        {
            int[,] combos = new int[,]
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8},
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8},
                {0, 4, 8}, {2, 4, 6}
            };

            for (int i = 0; i < combos.GetLength(0); i++)
            {
                bool canXwin = ((positions[combos[i, 0]] != symbolO) &&
                                (positions[combos[i, 1]] != symbolO) &&
                                (positions[combos[i, 2]] != symbolO));

                bool canOwin = ((positions[combos[i, 0]] != symbolX) &&
                                (positions[combos[i, 1]] != symbolX) &&
                                (positions[combos[i, 2]] != symbolX));

                if (canXwin || canOwin)
                {
                    return false;
                }
            }
            return true;
        }

        static void EndScene(string player1, string player2, string winnerPlayer, int rounds)
        {
            if (player1 == winnerPlayer)
            {
                Console.WriteLine(@"
            .-=========-.
            \'-=======-'/
            _|   .=.   |_
           ((|  {{1}}  |))
            \|   /|\   |/
             \__ '`' __/
               _`) (`_
             _/_______\_
            /___________\
");

                Console.WriteLine($"Parabéns! {winnerPlayer} venceu o jogo!");
                Console.WriteLine($"Parabéns! {winnerPlayer} venceu o jogo!");
                Console.WriteLine($"Parabéns! {winnerPlayer} venceu o jogo!");
                Console.WriteLine($"Parabéns! {winnerPlayer} venceu o jogo!");
                Console.WriteLine($"Parabéns! {winnerPlayer} venceu o jogo!");
                Console.WriteLine($"\nForam jogados {rounds} rounds.");
            }
            else if (player2 == winnerPlayer)
            {
                Console.WriteLine(@"
            .-=========-.
            \'-=======-'/
            _|   .=.   |_
           ((|  {{1}}  |))
            \|   /|\   |/
             \__ '`' __/
               _`) (`_
             _/_______\_
            /___________\
");

                Console.WriteLine($"Parabéns! {winnerPlayer} venceu o jogo!");
                Console.WriteLine($"Parabéns! {winnerPlayer} venceu o jogo!");
                Console.WriteLine($"Parabéns! {winnerPlayer} venceu o jogo!");
                Console.WriteLine($"Parabéns! {winnerPlayer} venceu o jogo!");
                Console.WriteLine($"Parabéns! {winnerPlayer} venceu o jogo!");
                Console.WriteLine($"\nForam jogados {rounds} rounds.");
            }
            else
            {
                Console.WriteLine(@"
                 .-.
               ,-""""""-,
              / \__   \
             |  /  `\  |
             \(  ^.^  )/
               \  -  /
            .-'|;---;|-.
         (\/   ||___||  `\
          \\__/       \__|
        C|`----`|D __//| |
         |      |====( | |
         |      |    _/_/___.----
     .===|      |====\      /===.
     |  ('------')  ( '----' )  |
     |                          |
");
                Console.WriteLine($"O jogo entre {player1} e {player2} deu velha.");
                Console.WriteLine($"O jogo entre {player1} e {player2} deu velha.");
                Console.WriteLine($"O jogo entre {player1} e {player2} deu velha.");
                Console.WriteLine($"O jogo entre {player1} e {player2} deu velha.");
                Console.WriteLine($"O jogo entre {player1} e {player2} deu velha.");
                Console.WriteLine($"\nForam jogados {rounds} rounds.");
            }
            Console.WriteLine("\nPRESSIONE ALGUMA TECLA PARA CONTINUAR...");
            Console.ReadKey();
        }
    }
}