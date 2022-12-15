using MathParser;
using Xunit;

namespace TestProject1;

public class ParserTest
{
    [Fact]
    public void Parse_Should_Contain_Collection_Of_Cells()
    {
        var equationString = "(1 + 2)";
        var parsed = Parser.Parse(equationString);

        Assert.IsAssignableFrom<IReadOnlyCollection<Cell>>(parsed);
    }
    
    [Theory]
    [InlineData("1 + 1", 2)]
    [InlineData("1 + 1 * 2", 3)]
    public void Parse_Should_Parse(string equation, int parsedCount)
    {
        var parsed = Parser.Parse(equation);

        Assert.Equal(parsed.Count, parsedCount);
    }
    
    [Theory]
    [InlineData("1 + 1 * 2", 3)]
    public void Parse_Should_Parse_Exact(string equation, int parsedCount)
    {
        var parsed = Parser.Parse(equation);

        Assert.Equal(parsed.Count, parsedCount);
    }
}
