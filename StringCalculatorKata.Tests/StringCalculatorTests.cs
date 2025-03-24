namespace StringCalculatorKata.Tests;

public class StringCalculatorKata
{

    [Fact]
    public void Takes_A_String_And_Returns_Number()
    {
        var stringCalculator = new StringCalculator();
        //Act
        var result = stringCalculator.Add("");
        //Assert
        Assert.Equal(0, result);


    }
    [Fact]
    public void Thrown_An_Exception_If_Given_Numbers_Are_Negative()
    {
        var stringCalculator = new StringCalculator();
        //Act
        var result = Assert.Throws<ArgumentException>(() => stringCalculator.Add("-1,2,-3"));
        //Assert
        Assert.Equal("Negatives not allowed: -1, -3", result.Message);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    [InlineData("3\n5\n3,9", 20)]
    [InlineData("//;\n1;2", 3)]
    [InlineData("1000,1001,2", 2)]
    [InlineData("//[***]\n1***2***3", 6)]
    [InlineData("//[*][%]\n1*2%3", 6)]
    [InlineData("//[***][#][%]\n1***2#3%4", 10)]
    [InlineData("//[*1*][%]\n1*1*2%3", 6)]
    public void Takes_One_NumberString_And_Returns_It_As_A_Number(string numbers, int expectedResult)
    {

        var stringCalculator = new StringCalculator();
        var result = stringCalculator.Add(numbers);
        Assert.Equal(result, expectedResult);

    }

}
