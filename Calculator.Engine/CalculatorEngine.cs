
namespace Calculator.Engine;

public enum Operation
{
    None,
    Add,
    Subtract,
    Multiply,
    Divide,
    Percent
}

/// <summary>
/// Stateless calculation helpers + a small state wrapper to mimic real calculators.
/// </summary>
public class CalculatorEngine
{
    public string Display { get; private set; } = "0";
    public double? Accumulator { get; private set; }
    public Operation PendingOperation { get; private set; } = Operation.None;
    public bool IsEnteringNewNumber { get; private set; } = true;

    public void InputDigit(char c)
    {
        if (!char.IsDigit(c) && c != '.') return;

        if (IsEnteringNewNumber)
        {
            Display = (c == '.') ? "0." : c.ToString();
            IsEnteringNewNumber = false;
        }
        else
        {
            if (c == '.' && Display.Contains('.')) return;
            Display = (Display == "0" && !Display.Contains('.')) ? c.ToString() : Display + c;
        }
    }

    public void ToggleSign()
    {
        if (Display.StartsWith("-"))
            Display = Display[1..];
        else if (Display != "0")
            Display = "-" + Display;
    }

    public void ClearEntry()
    {
        Display = "0";
        IsEnteringNewNumber = true;
    }

    public void AllClear()
    {
        Display = "0";
        Accumulator = null;
        PendingOperation = Operation.None;
        IsEnteringNewNumber = true;
    }

    public void SetOperation(Operation op)
    {
        ComputePending();
        PendingOperation = op;
        IsEnteringNewNumber = true;
    }

    public void Equals()
    {
        ComputePending();
        PendingOperation = Operation.None;
        IsEnteringNewNumber = true;
    }

    private void ComputePending()
    {
        if (!double.TryParse(Display, out var current))
        {
            Display = "0";
            return;
        }

        if (PendingOperation == Operation.None)
        {
            Accumulator = current;
            return;
        }

        if (Accumulator is null)
        {
            Accumulator = current;
            return;
        }

        double result = Accumulator.Value;
        switch (PendingOperation)
        {
            case Operation.Add:
                result += current;
                break;
            case Operation.Subtract:
                result -= current;
                break;
            case Operation.Multiply:
                result *= current;
                break;
            case Operation.Divide:
                if (current == 0)
                {
                    Display = "Cannot divide by zero";
                    Accumulator = null;
                    PendingOperation = Operation.None;
                    IsEnteringNewNumber = true;
                    return;
                }
                result /= current;
                break;
            case Operation.Percent:
                // Treat as Accumulator * (current / 100)
                result = Accumulator.Value * (current / 100.0);
                break;
        }

        Accumulator = result;
        Display = result.ToString(System.Globalization.CultureInfo.InvariantCulture);
    }
}
