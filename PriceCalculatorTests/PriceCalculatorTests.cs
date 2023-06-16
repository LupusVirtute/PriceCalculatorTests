
using CodeCoverageTests;

namespace PriceCalculatorTests;

[TestClass]
public class PriceCalculatorTests
{

    DateTime customerLastVisit200DaysAgo = new DateTime(2022, 11, 28);
    DateTime customerLastVisit199DaysAgo = new DateTime(2022, 11, 29);

    Customer customer;
    IDateProvider dateProvider;

    [TestInitialize]
    public void Initialize()
    {
        customer = new Customer();
        dateProvider = new TestDateProviderImplementation();
    }

    [TestMethod]
    [DataRow(1, 200.0)]
    public void Expect_Price_To_Be_Off_100_Percent(int customerAge, double initialPrice)
    {
        customer.Age = customerAge;
     
        var priceCalculator = new PriceCalculator(dateProvider);
        var priceCalculated = priceCalculator.CalculatePrice(customer, initialPrice);
        Assert.AreEqual(priceCalculated, 0.0);
    }

    [TestMethod]
    [DataRow(34, 200.0)]
    public void Expect_Price_To_Be_Off_50_Percent(int customerAge, double initialPrice)
    {
        customer.Age = customerAge;
        customer.LastVisited = customerLastVisit200DaysAgo;
     
        var priceCalculator = new PriceCalculator(dateProvider);
        var priceCalculated = priceCalculator.CalculatePrice(customer, initialPrice);

        Assert.AreEqual(initialPrice / 2, priceCalculated);
    }

    [TestMethod]
    [DataRow(32, 200.0)]
    public void Expect_Price_To_Be_Initial_Price_For_Visit_199_Days_Ago(int customerAge, double initialPrice)
    {
        customer.Age = customerAge;
        customer.LastVisited = customerLastVisit199DaysAgo;
     
        var priceCalculator = new PriceCalculator(dateProvider);
        var priceCalculated = priceCalculator.CalculatePrice(customer, initialPrice);

        Assert.AreEqual(initialPrice, priceCalculated);
    }

    [TestMethod]
    [DataRow(65,200.0)]
    public void Expect_Price_To_Be_Off_30_Percent(int customerAge, double initialPrice)
    {
        customer.Age = customerAge;
        customer.LastVisited = customerLastVisit199DaysAgo;

        var priceCalculator = new PriceCalculator(dateProvider);
        var priceCalculated = priceCalculator.CalculatePrice(customer, initialPrice);

        const double hundredPercent = 1.0;
        const double thirtyPercent = 0.3;

        Assert.AreEqual(initialPrice * (hundredPercent-thirtyPercent), priceCalculated);
}
}