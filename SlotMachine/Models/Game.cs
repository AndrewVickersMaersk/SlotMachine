namespace SlotMachine.Models;

public class Game
{
    private double _stake;
    private double _coefficient;
    public DateTime DatePlayed { get; set; }

    public double Stake
    {
        get => _stake;
        private set => _stake = value;
    }
    public double Coefficient
    {
        get => _coefficient;
        set => _coefficient = value;
    }
    
    public Game(double stake)
    {
        DatePlayed = DateTime.Now;
        _stake = stake;
    }
}