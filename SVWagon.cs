public class SVWagon : Wagon
{
    private decimal priceLower = 2000m;
    private decimal priceUpper = 1500m;

    public SVWagon(int lower, int upper, Dictionary<string, decimal> services)
        : base(lower, upper, 0, 0, services) { }

    public override decimal GetIncome()
    {
        decimal seatsIncome = LowerSeats * priceLower +
                             UpperSeats * priceUpper;

        decimal servicesIncome = 0;
        foreach (var price in AdditionalServices.Values)
            servicesIncome += price;

        return seatsIncome + servicesIncome;
    }
}