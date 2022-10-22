namespace ConsoleApp7;

class Program
{
    public static void Main(string[] args)
    {
        string[,] playerData =
        {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" }
        };

        string currentPlayer = "X";
        bool isGameOver = false;

        while (!isGameOver)
        {
            Console.Clear();
            DrawDisplay();
            Console.WriteLine($"Player {currentPlayer}'s turn: ");
            var selectedField = Convert.ToInt32(Console.ReadLine());

            if (!ValidatePlayerInput(selectedField))
            {
                continue;
            }

            var loc = GetColumnRow(selectedField);

            playerData[loc.column, loc.row] = currentPlayer;


            if (IsGameOver(out bool isDraw))
            {
                Console.Clear();
                DrawDisplay();
                isGameOver = true;
                if (isDraw)
                    Console.WriteLine("Draw!");
                else
                    Console.WriteLine($"Player {currentPlayer} won!");
            }

            if (currentPlayer.Equals("X"))
            {
                currentPlayer = "O";
            }
            else
            {
                currentPlayer = "X";
            }
        }

        bool IsGameOver(out bool isDraw)
        {
            isDraw = false;
            //checking rows/columns
            for (int i = 0; i < playerData.GetLength(0); i++)
            {
                if ((playerData[i, 0] == playerData[i, 1]) && (playerData[i, 1] == playerData[i, 2]))
                {
                    return true;
                }

                if ((playerData[0, i] == playerData[1, i]) && (playerData[1, i] == playerData[2, i]))
                {
                    return true;
                }
            }

            //check diagrams
            if (((playerData[0, 0] == playerData[1, 1]) && (playerData[1, 1] == playerData[2, 2]))
                || ((playerData[0, 2] == playerData[1, 1]) && (playerData[1, 1] == playerData[2, 0])))
            {
                return true;
            }

            if (IsMatrixFilled())
            {
                isDraw = true;
                return true;
            }

            return false;
        }

        bool IsMatrixFilled()
        {
            foreach (var s in playerData)
            {
                if (!(s.Equals("X") || s.Equals("O")))
                {
                    return false;
                }
            }

            return true;
        }

        bool ValidatePlayerInput(int selectedInput)
        {
            var loc = GetColumnRow(selectedInput);
            if (playerData[loc.column, loc.row] == selectedInput.ToString())
            {
                return true;
            }

            return false;
        }

        (int column, int row) GetColumnRow(int selectedInput)
        {
            selectedInput--;
            return (selectedInput / 3, selectedInput % 3);
        }

        void DrawDisplay()
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"| {playerData[0, 0]} | {playerData[0, 1]} | {playerData[0, 2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {playerData[1, 0]} | {playerData[1, 1]} | {playerData[1, 2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {playerData[2, 0]} | {playerData[2, 1]} | {playerData[2, 2]} |");
            Console.WriteLine("-------------");
        }
    }
}