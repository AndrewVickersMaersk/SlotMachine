using SlotMachine.Enums;
using SlotMachine.Models;

namespace SlotMachine.Services;

public static class GameEngine
{
    private static Player player;

    public static void PlayGame()
    {
        player = new Player();
        Console.WriteLine("Please deposit money you would like to play with: ");

        decimal playerBalance = 0;
        while (!decimal.TryParse(Console.ReadLine(), out playerBalance) || playerBalance < 0)
        {
            Console.WriteLine("Please enter a whole number only: ");
        }

        player.Balance = playerBalance;

        var randomGen = new Random();
        while (player.Balance > 0)
        {
            var stake = GetValidStake();
            var game = new Game(stake);
            player.Balance -= stake;

            var spins = new Cell[4, 3];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var symbol = GetRandomSymbol(randomGen.Next(1, 100));
                    spins[i, j] = new Cell(symbol);
                }

            }

            DisplaySpins(spins);
            var coefficient = CalculateGameCoefficient(spins);
            var winnings = stake * coefficient;

            player.Balance += winnings;

            Console.WriteLine($"You have won: {winnings:F1}");
            Console.WriteLine($"Current balance is: {player.Balance:F1}");
        }

        Console.WriteLine("Game over");
    }

    public static decimal CalculateGameCoefficient(Cell[,]? spins)
    {
        decimal coefficient = 0;
        for (int i = 0; i < 4; i++)
        {
            var row = new List<decimal>();
            for (int j = 0; j < 3; j++)
            {
                row.Add(spins[i, j].Coefficient);
            }

            var results = from cell in row
                group cell by cell
                into g
                where g.Key > 0
                let count = g.Count()
                orderby count descending
                select new
                {
                    Count = count,
                    Coefficient = g.Key
                };

            if (results.Count() == 1)
            {
                coefficient += results.First().Count * results.First().Coefficient;
            }

        }

        return coefficient;
    }

    static void DisplaySpins(Cell[,]? spins)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(spins[i, j].DisplaySymbol);
            }

            Console.WriteLine();
        }
    }

    static decimal GetValidStake()
    {
        decimal stake = 0;
        Console.WriteLine("Enter stake amount: ");
        while (!decimal.TryParse(Console.ReadLine(), out stake) || stake < 0 || (stake > player.Balance))
        {
            Console.WriteLine($"Please enter a valid stake (between 0.1 and {player.Balance:F1}): ");
        }

        Console.WriteLine();
        return stake;
    }

    public static Symbol GetRandomSymbol(int percentage)
    {
        if (percentage <= (int) Symbol.Wildcard)
            return Symbol.Wildcard;
        if (percentage <= (int) Symbol.Pineapple)
            return Symbol.Pineapple;
        if (percentage <= (int) Symbol.Banana)
            return Symbol.Banana;
        return Symbol.Apple;
    }
}