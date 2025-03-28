using Moq;
using UniitTest.App;
using Xunit;

namespace UnitTest.Test;

public class CalculatorTest
{
    private Calculator _calculator { get; set; }
    private Mock<ICalculatorService> _mymock { get; set; }
    public CalculatorTest()
    {
        var mymock = new Mock<ICalculatorService>();
        _calculator = new Calculator(mymock.Object);

    }

    [Theory]
    [InlineData(2, 5, 7)] // test edillecek veriler
    [InlineData(10, 2, 12)] // test edilecek veriler
    public void Add_SimpleValues_ReturnTotalValue(int a, int b, int exptectedTotal)
    {
        //  verify ile metodun calsıp calısmadıgını test ederiz
        _mymock.Setup(x => x.Add(a, b)).Returns(exptectedTotal);
        var actualTotal = _calculator.add(a, b);
        Assert.Equal(exptectedTotal, actualTotal);
        //  bir kez calıssın times.once hiç  Times.Never
        _mymock.Verify(x => x.Add(a, b), Times.Once);

    }
    //[Theory]
    //[InlineData(0, 5)]
    //[InlineData(2, 0)]
    //public void Add_WhenZeroInputs_ThrowsException(int a, int b)
    //{
    //    // Arrange
    //    _mymock.Setup(x => x.Add(a, b)).Throws(new Exception("a=0 olamaz b=0 olamaz"));

    //    // Act & Assert
    //    var ex = Assert.Throws<Exception>(() => _calculator.Add(a, b));
    //    Assert.Equal("a=0 olamaz b=0 olamaz", ex.Message);

    //    _mymock.Verify(x => x.a(a, b), Times.Once);
}
