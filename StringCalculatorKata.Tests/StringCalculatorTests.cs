namespace StringCalculatorKata.Tests;

public class StringCalculatorKata
{
    
    [Fact]
    public void Takes_A_String_And_Returns_Number()
    {
        var stringCalculator = new StringCalculator();
        //Act
        var result = stringCalculator.calculateString("");
        //Assert
        Assert.Equal(0,result);


    }

    [Theory]
    [InlineData("1",1)]
    [InlineData("1,2",3)]
    public void Takes_One_NumberString_And_Returns_It_As_A_Number(string numbers,int expectedResult){

        var stringCalculator = new StringCalculator();
        var result = stringCalculator.calculateString(numbers);
        Assert.Equal(result,expectedResult);
        
    }
}
