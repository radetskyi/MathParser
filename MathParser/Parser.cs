namespace MathParser;

public static class Parser
{
    private const char OpeningChar = '(';
    private const char ClosingChar = ')';

    public static IReadOnlyCollection<Cell> Parse(string equation)
    {
        var parsed = equation.Split(new[] { '+', '-', 'ˆ', '/', '*' });
        return parsed.Select(p => new Cell(double.Parse(p), ' ')).ToArray();
    }

    private static IReadOnlyCollection<string> SplitBr(string input)
    {
        return input.Split(ClosingChar);
    }
}
