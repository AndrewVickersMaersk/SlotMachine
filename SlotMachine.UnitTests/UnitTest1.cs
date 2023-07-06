

using SlotMachine.Enums;
using SlotMachine.Models;
using SlotMachine.Services;
using Xunit;

namespace SlotMachine.UnitTests
{
    public class GameEngineTests
    {
        public GameEngineTests()
        {
        }

        [Theory]
        [InlineData(4, Symbol.Wildcard)]
        [InlineData(14, Symbol.Pineapple)]
        [InlineData(24, Symbol.Banana)]
        [InlineData(64, Symbol.Apple)]
        public void Given_Value_For_Percentage_Returns_Correct_Symbol(int percentage, Symbol expectedSymbol)
        {
            var result = GameEngine.GetRandomSymbol(percentage);
            Assert.Equal(expectedSymbol, result);
        }

        [Fact]
        public void Given_3_Apples_Returns_The_Correct_Coefficient()
        {
            // Arrange
            var spin = new Cell[4, 3]
            {
                {new Cell(Symbol.Apple), new Cell(Symbol.Apple), new Cell(Symbol.Apple)},
                {new Cell(Symbol.Apple), new Cell(Symbol.Banana), new Cell(Symbol.Banana)},
                {new Cell(Symbol.Banana), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)},
                {new Cell(Symbol.Apple), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)}
            };
            var result = GameEngine.CalculateGameCoefficient(spin);
            Assert.Equal(1.2M, result);
        }

        [Fact]
        public void Given_3_Bananas_Returns_The_Correct_Coefficient()
        {
            // Arrange
            var spin = new Cell[4, 3]
            {
                {new Cell(Symbol.Banana), new Cell(Symbol.Apple), new Cell(Symbol.Apple)},
                {new Cell(Symbol.Banana), new Cell(Symbol.Banana), new Cell(Symbol.Banana)},
                {new Cell(Symbol.Banana), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)},
                {new Cell(Symbol.Apple), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)}
            };
            var result = GameEngine.CalculateGameCoefficient(spin);
            Assert.Equal(1.8M, result);
        }

        [Fact]
        public void Given_3_Pineapples_Returns_The_Correct_Coefficient()
        {
            // Arrange
            var spin = new Cell[4, 3]
            {
                {new Cell(Symbol.Banana), new Cell(Symbol.Apple), new Cell(Symbol.Apple)},
                {new Cell(Symbol.Banana), new Cell(Symbol.Apple), new Cell(Symbol.Banana)},
                {new Cell(Symbol.Pineapple), new Cell(Symbol.Pineapple), new Cell(Symbol.Pineapple)},
                {new Cell(Symbol.Apple), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)}
            };
            var result = GameEngine.CalculateGameCoefficient(spin);
            Assert.Equal(2.4M, result);
        }

        [Fact]
        public void Given_3_Wildcards_Returns_The_Correct_Coefficient()
        {
            // Arrange
            var spin = new Cell[4, 3]
            {
                {new Cell(Symbol.Banana), new Cell(Symbol.Apple), new Cell(Symbol.Apple)},
                {new Cell(Symbol.Wildcard), new Cell(Symbol.Wildcard), new Cell(Symbol.Wildcard)},
                {new Cell(Symbol.Banana), new Cell(Symbol.Pineapple), new Cell(Symbol.Pineapple)},
                {new Cell(Symbol.Apple), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)}
            };
            var result = GameEngine.CalculateGameCoefficient(spin);
            Assert.Equal(0M, result);
        }

        [Fact]
        public void Given_1_Wildcard_And_2_Bananas_Returns_The_Correct_Coefficient()
        {
            // Arrange
            var spin = new Cell[4, 3]
            {
                {new Cell(Symbol.Banana), new Cell(Symbol.Apple), new Cell(Symbol.Apple)},
                {new Cell(Symbol.Wildcard), new Cell(Symbol.Banana), new Cell(Symbol.Banana)},
                {new Cell(Symbol.Apple), new Cell(Symbol.Pineapple), new Cell(Symbol.Pineapple)},
                {new Cell(Symbol.Apple), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)}
            };
            var result = GameEngine.CalculateGameCoefficient(spin);
            Assert.Equal(1.2M, result);
        }

        [Fact]
        public void Given_2_Wildcards_And_1_Apple_Returns_The_Correct_Coefficient()
        {
            // Arrange
            var spin = new Cell[4, 3]
            {
                {new Cell(Symbol.Wildcard), new Cell(Symbol.Apple), new Cell(Symbol.Wildcard)},
                {new Cell(Symbol.Wildcard), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)},
                {new Cell(Symbol.Pineapple), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)},
                {new Cell(Symbol.Apple), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)}
            };
            var result = GameEngine.CalculateGameCoefficient(spin);
            Assert.Equal(0.4M, result);
        }

        [Fact]
        public void Given_3_Winning_Rows_Returns_The_Correct_Coefficient()
        {
            // Arrange
            var spin = new Cell[4, 3]
            {
                {new Cell(Symbol.Apple), new Cell(Symbol.Apple), new Cell(Symbol.Wildcard)},
                {new Cell(Symbol.Wildcard), new Cell(Symbol.Banana), new Cell(Symbol.Banana)},
                {new Cell(Symbol.Pineapple), new Cell(Symbol.Pineapple), new Cell(Symbol.Pineapple)},
                {new Cell(Symbol.Apple), new Cell(Symbol.Banana), new Cell(Symbol.Pineapple)}
            };
            var result = GameEngine.CalculateGameCoefficient(spin);
            Assert.Equal(4.4M, result);
        }
    }
}