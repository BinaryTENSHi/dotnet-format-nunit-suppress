using NUnit.Framework;

namespace Example.Test;

public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void TestAdd()
    {
        Assert.That(_calculator.Add(1, 2), Is.EqualTo(3));
    }
}