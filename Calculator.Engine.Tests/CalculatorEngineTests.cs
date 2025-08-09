using Calculator.Engine;
using Xunit;

namespace Calculator.Engine.Tests;

public class CalculatorEngineTests
{
    [Fact]
    public void AddsTwoNumbers()
    {
        var calc = new CalculatorEngine();
        calc.InputDigit('2');
        calc.SetOperation(Operation.Add);
        calc.InputDigit('3');
        calc.Equals();
        Assert.Equal("5", calc.Display);
    }

    [Fact]
    public void MultiplyThenPercent()
    {
        var calc = new CalculatorEngine();
        calc.InputDigit('2');
        calc.SetOperation(Operation.Multiply);
        calc.InputDigit('5');
        calc.Equals();
        Assert.Equal("10", calc.Display);

        calc.SetOperation(Operation.Percent);
        calc.InputDigit('5');
        calc.Equals(); // 10 * (5/100) = 0.5
        Assert.Equal("0.5", calc.Display);
    }

    [Fact]
    public void DivisionByZeroHandled()
    {
        var calc = new CalculatorEngine();
        calc.InputDigit('9');
        calc.SetOperation(Operation.Divide);
        calc.InputDigit('0');
        calc.Equals();
        Assert.Equal("Cannot divide by zero", calc.Display);
    }
}
