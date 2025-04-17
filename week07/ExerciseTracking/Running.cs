public class Running : Activity
{
    public double Distance { get; set; } // in miles

    public override double GetDistance() => Distance;

    public override double GetSpeed() => (Distance / Minutes) * 60; // Speed in mph

    public override double GetPace() => Minutes / Distance; // Pace in min per mile
}
