using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    static void InitializeBoard()
    {
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = (char)('1' + i);
        }
    }

    static void DisplayBoard()
    {
        Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
    }

    static void MakeMove(char playerSymbol)
    {
        int choice;
        while (true)
        {
            Console.WriteLine("Player {0}, choose a cell (1-9): ", playerSymbol);
            choice = int.Parse(Console.ReadLine()) - 1;

            if (choice >= 0 && choice < 9 && board[choice] != 'X' && board[choice] != 'O')
            {
                board[choice] = playerSymbol;
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    static bool CheckWin()
    {
        int[,] winCombinations = new int[,]
        {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, 
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, 
            {0, 4, 8}, {2, 4, 6}             
        };

        for (int i = 0; i < winCombinations.GetLength(0); i++)
        {
            int a = winCombinations[i, 0];
            int b = winCombinations[i, 1];
            int c = winCombinations[i, 2];

            if (board[a] == board[b] && board[b] == board[c])
            {
                return true;
            }
        }

        return false;
    }

    static void Main()
    {
        do
        {
            InitializeBoard();
            char currentPlayer = 'X';

            for (int turn = 0; turn < 9; turn++)
            {
                DisplayBoard();
                MakeMove(currentPlayer);

                if (CheckWin())
                {
                    DisplayBoard();
                    Console.WriteLine("Player {0} wins!", currentPlayer);
                    break;
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }

            if (!CheckWin())
            {
                DisplayBoard();
                Console.WriteLine("It's a draw!");
            }

            Console.WriteLine("Would you like to start a new game? (yes/no)");
        }
        while (Console.ReadLine().ToLower() == "yes");

        Console.WriteLine("Thank you for playing!");
    }
}
