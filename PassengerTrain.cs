using System.Collections.Generic;

public class PassengerTrain
{
    private List<Wagon> Wagons;

    public PassengerTrain()
    {
        Wagons = new List<Wagon>();
    }

    public void AddWagon(Wagon wagon)
    {
        Wagons.Add(wagon);
    }

    public decimal GetTotalIncome()
    {
        decimal total = 0;
        foreach (var wagon in Wagons)
            total += wagon.GetIncome();
        return total;
    }
}