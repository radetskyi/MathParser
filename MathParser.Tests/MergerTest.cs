using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using MathParser;
using Xunit;

namespace TestProject1;

public class MergerTest
{
    [Theory]
    [InlineData('ˆ', 4)]
    [InlineData('/', 3)]
    [InlineData(':', 3)]
    [InlineData('*', 3)]
    [InlineData('-', 2)]
    [InlineData('+', 2)]
    [InlineData('<', 0)]
    [InlineData('>', 0)]
    [InlineData('=', 0)]
    public void GetPriority_Returns_Exact_Priority(char action, int expectedPriority)
    {
        Assert.Equal(expectedPriority, Merger.GetPriority(action));
    }

    [Theory]
    [ClassData(typeof(TrueTestDataGenerator))]
    public void CanMerge_Returns_Expected_True(Cell left, Cell right)
    {
        Assert.True(Merger.CanMerge(left, right));
    }
    
    [Theory]
    [ClassData(typeof(FalseTestDataGenerator))]
    public void CanMerge_Returns_Expected_False(Cell left, Cell right)
    {
        Assert.False(Merger.CanMerge(left, right));
    }
}

internal class TrueTestDataGenerator : IEnumerable<object[]>
{
    private readonly List<Cell[]> _data = new()
    {
        new Cell[] { new (2, '+'), new (2, '+') },
        new Cell[] { new (2, '-'), new (2, '-') },
        new Cell[] { new (2, '*'), new (2, '*') },
        new Cell[] { new (2, '/'), new (2, '/') },
        new Cell[] { new (2, ':'), new (2, ':') },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal class FalseTestDataGenerator : IEnumerable<object[]>
{
    private readonly List<Cell[]> _data = new()
    {
        new Cell[] { new (2, '+'), new (2, '/') },
        new Cell[] { new (2, '-'), new (2, '*') },
        new Cell[] { new (2, '-'), new (2, ':') },
        new Cell[] { new (2, '/'), new (2, 'ˆ') },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
