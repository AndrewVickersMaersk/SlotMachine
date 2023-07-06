namespace SlotMachine.Models;

public class Game
{
    private decimal _stake;
    private decimal _coefficient;
    public DateTime DatePlayed { get; set; }

    public decimal Stake
    {
        get => _stake;
        private set => _stake = value;
    }
    public decimal Coefficient
    {
        get => _coefficient;
        set => _coefficient = value;
    }
    
    public Game(decimal stake)
    {
        DatePlayed = DateTime.Now;
        _stake = stake;
    }
}