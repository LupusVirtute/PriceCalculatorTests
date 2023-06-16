namespace CodeCoverageTests;

public class PriceCalculator
{
    private IDateProvider _dateProvider;

    public PriceCalculator(IDateProvider dateProvider)
    {
        _dateProvider = dateProvider;
    }

    public double CalculatePrice(Customer customer, double price)
    {
        const double hundredPercent = 1.0;
        const double thirtyPercent = 0.3;
        const double fiftyPercent = 0.5;

        if (customer.Age < 4)
        {
            return 0;
        }

        if (customer.Age >= 65)
        {
            return price * (hundredPercent - thirtyPercent);
        }

        var twoHundredDaysAgo = _dateProvider.Now.AddDays(-200);

        if(customer.LastVisited <= twoHundredDaysAgo)
        {
            return price * fiftyPercent;
        }

        return price;
    }


}