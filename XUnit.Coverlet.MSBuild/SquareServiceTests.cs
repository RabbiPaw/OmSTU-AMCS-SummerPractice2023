using System.Square;
using SquareEquationLib;
using Xunit;

namespace XUnit.Coverlet
{
    public class PrimeServiceTests
    {
        readonly SquareService _squareService;

        public SquareServiceTests() => _squareService = new SquareService();

        #region Sample_TestCode
        [Theory]
        [InlineData(0, 1, 2), InlineData(double.NaN, 1, 2), InlineData(1, double.NaN, 2), InlineData(1, 2, double.NaN), InlineData(double.PositiveInfinity, 1, 2), InlineData(1, double.PositiveInfinity, 2), InlineData(1, 2, double.PositiveInfinity), InlineData(double.NegativeInfinity, 1, 2), InlineData(1, double.NegativeInfinity, 2), InlineData(1, 2, double.NegativeInfinity)]
        public void ExceptionTest(double a, double b, double c)
        {
            try
            {
                double[] Answ = SquareEquation.Solve(a, b, c);
            }
            catch (System.ArgumentException)
            {
                var result = false;
                Assert.False(result);
            }
        }
        #endregion

        [Theory]
        [InlineData(1, 3, 2), InlineData(1, 3, 2.124999999), InlineData(1, 2, 1), InlineData(1, 2, 0)]
        public void OneAndTwoXTest(double a, double b, double c)
        {
            double[] Answ = SquareEquation.Solve(a, b, c);
            var result = _squareService.SquareMath(a, b, c, Answ);
            Assert.True(result);
        }

        [Theory]
        [InlineData(4, 2, 3), InlineData(-6, 1, -3)]
        public void NoXTest(double a, double b, double c)
        {
            double[] Answ = SquareEquation.Solve(a, b, c);
            var result = _squareService.SquareMath(a, b, c, Answ);
            Assert.False(result);
        }
    }
}
