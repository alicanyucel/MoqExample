
namespace UniitTest.App;

public class Calculator
{
    private ICalculatorService _calculatorService;

    public Calculator()
    {
    }

    public Calculator(ICalculatorService  calculatorService)
    {
        _calculatorService = calculatorService;
    }
    public int add(int a,int b)
    {
        return _calculatorService.Add(a,b);
    }
    
}