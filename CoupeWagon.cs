public class CoupeWagon : Wagon
{
    private decimal priceLower = 1000m;
    private decimal priceUpper = 800m;
    private decimal priceLowerSide = 600m;
    private decimal priceUpperSide = 500m;

    public CoupeWagon(int lower, int upper, int lowerSide, int upperSide, Dictionary<string, decimal> services)
        : base(lower, upper, lowerSide, upperSide, services) { }

    public override decimal GetIncome()
    {
        decimal seatsIncome = LowerSeats * priceLower +
                             UpperSeats * priceUpper +
                             LowerSideSeats * priceLowerSide +
                             UpperSideSeats * priceUpperSide;

        decimal servicesIncome = 0;
        foreach (var price in AdditionalServices.Values)
            servicesIncome += price;

        return seatsIncome + servicesIncome;
    }
}