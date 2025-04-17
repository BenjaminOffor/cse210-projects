public class Cycling : Activity
{
    public double Speed { get; set; } // Speed in miles per hour

    public override double GetDistance() => Speed * (Minutes / 60); // Distance in miles

    public override double GetSpeed() => Speed; // Speed is already provided

    public override double GetPace() => 60 / Speed; // Pace in min per mile
}
