using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlotMachine.Enums;

namespace SlotMachine.Models
{
    internal class Cell
    {
        private string _displaySymbol;
        private double _coefficient;

        public string DisplaySymbol
        {
            get => _displaySymbol;
        }

        public double Coefficient
        {
            get => _coefficient;
        }

        public Cell(Symbol symbol)
        {
            switch(symbol)
            {
                case Symbol.Apple:
                    _coefficient = 0.4;
                    _displaySymbol = "A";
                    break;
                case Symbol.Banana:
                    _coefficient = 0.6;
                    _displaySymbol = "B";
                    break;
                case Symbol.Pineapple:
                    _coefficient = 0.8;
                    _displaySymbol = "P";
                    break;
                case Symbol.Wildcard:
                    _coefficient = 0;
                    _displaySymbol = "*";
                    break;
            }
        }
    }
}
