public class Swimming : Activity
{
    public int Laps { get; set; } // Number of laps

    public override double GetDistance() => Laps * 50 / 1000; // Distance in kilometers

    public override double GetSpeed() => (GetDistance() / Minutes) * 60; // Speed in kph

    public override double GetPace() => Minutes / GetDistance(); // Pace in min per km
}
