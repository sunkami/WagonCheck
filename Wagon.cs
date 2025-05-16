using System.Collections.Generic;

public abstract class Wagon
{
    public int LowerSeats { get; protected set; }
    public int UpperSeats { get; protected set; }
    public int LowerSideSeats { get; protected set; }
    public int UpperSideSeats { get; protected set; }

    protected Dictionary<string, decimal> AdditionalServices;

    protected Wagon(int lower, int upper, int lowerSide, int upperSide, Dictionary<string, decimal> services)
    {
        LowerSeats = lower;
        UpperSeats = upper;
        LowerSideSeats = lowerSide;
        UpperSideSeats = upperSide;
        AdditionalServices = services ?? new Dictionary<string, decimal>();
    }

    public abstract decimal GetIncome();
}