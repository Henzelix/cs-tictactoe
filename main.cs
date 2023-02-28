using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]; // plansza gry
        static char player = 'X'; // zaczyna gracz X

        static void Main(string[] args)
        {
            InitializeBoard();

            while (true)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("Gracz {0}, twój ruch.", player);
                int row, col;
                do
                {
                    Console.Write("Podaj numer wiersza (0-2): ");
                    row = int.Parse(Console.ReadLine());
                    Console.Write("Podaj numer kolumny (0-2): ");
                    col = int.Parse(Console.ReadLine());
                } while (!IsValidMove(row, col));

                MakeMove(row, col);

                if (HasWon())
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("Gracz {0} wygrał!", player);
                    break;
                }

                if (IsDraw())
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("Remis!");
                    break;
                }

                SwitchPlayer();
            }

            Console.WriteLine("Koniec gry. Naciśnij dowolny klawisz, aby zakończyć.");
            Console.ReadKey();
        }

        static void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        static void PrintBoard()
        {
            Console.WriteLine("  0 1 2");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col]);
                    if (col != 2)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                if (row != 2)
                {
                    Console.WriteLine("  -----");
                }
            }
        }

        static bool IsValidMove(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                Console.WriteLine("Niepoprawne współrzędne. Spróbuj ponownie.");
                return false;
            }
            if (board[row, col] != ' ')
            {
                Console.WriteLine("To pole jest już zajęte. Spróbuj ponownie.");
                return false;
            }
            return true;
        }

        static void MakeMove(int row, int col)
        {
            board[row, col] = player;
        }

        static bool HasWon()
        {
            // sprawdzanie wierszy
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
                {
                    return true;
                }
            }

            // sprawdzanie kolumn
            for (int col = 0; col < 3; col++)
            {
                        if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
            {
                return true;
            }
        }

        // sprawdzanie przekątnych
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
        {
            return true;
        }
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
        {
            return true;
        }

        return false;
    }

    static bool IsDraw()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }

    static void SwitchPlayer()
    {
        if (player == 'X')
        {
            player = 'O';
        }
        else
        {
            player = 'X';
        }
    }
}
}
