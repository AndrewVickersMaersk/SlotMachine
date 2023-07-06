using SlotMachine.Enums;

namespace SlotMachine.Models
{
    public class Cell
    {
        private string _displaySymbol = null!;
        private decimal _coefficient;

        public string DisplaySymbol
        {
            get => _displaySymbol;
        }

        public decimal Coefficient
        {
            get => _coefficient;
        }

        public Cell(Symbol symbol)
        {
            switch(symbol)
            {
                case Symbol.Apple:
                    _coefficient = 0.4M;
                    _displaySymbol = "A";
                    break;
                case Symbol.Banana:
                    _coefficient = 0.6M;
                    _displaySymbol = "B";
                    break;
                case Symbol.Pineapple:
                    _coefficient = 0.8M;
                    _displaySymbol = "P";
                    break;
                case Symbol.Wildcard:
                    _coefficient = 0M;
                    _displaySymbol = "*";
                    break;
            }
        }
    }
}
