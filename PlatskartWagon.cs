public class PlatskartWagon : Wagon
{
    private decimal priceLower = 700m;
    private decimal priceUpper = 500m;
    private decimal priceLowerSide = 400m;
    private decimal priceUpperSide = 350m;

    public PlatskartWagon(int lower, int upper, int lowerSide, int upperSide, Dictionary<string, decimal> services)
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