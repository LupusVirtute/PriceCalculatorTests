using CodeCoverageTests;

namespace PriceCalculatorTests;

// Could mock it but i just am lazy to install nuget package
class TestDateProviderImplementation : IDateProvider
{
    public DateTime Now => new DateTime(2023, 6, 16);
}
