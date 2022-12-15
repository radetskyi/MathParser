namespace MathParser;

public static class Merger
{
    public static int GetPriority(char action)
    {
        return action switch
        {
            'ˆ' => 4,
            '/' => 3,
            ':' => 3,
            '*' => 3,
            '+' => 2,
            '-' => 2,
            _ => 0
        };
    }

    public static bool CanMerge(Cell left, Cell right) => GetPriority(left.Action) >= GetPriority(right.Action);

    public static Cell Merge(Cell left, Cell right)
    {
        var value = left.Action switch
        {
            'ˆ' => Math.Pow(left.Value, right.Value),
            '*' => left.Value * right.Value,
            '/' => left.Value / right.Value,
            ':' => left.Value / right.Value,
            '+' => left.Value + right.Value,
            '-' => left.Value - right.Value,
            _ => throw new ArgumentOutOfRangeException(nameof(left.Action)),
        };
        return right with { Value = value };
    }
}
