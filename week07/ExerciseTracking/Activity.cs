using System;

public abstract class Activity
{
    public DateTime Date { get; set; }
    public double Minutes { get; set; }

    // Abstract methods to be overridden in derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Method to return summary for each activity
    public string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({Minutes} min): Distance {GetDistance()}, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}
