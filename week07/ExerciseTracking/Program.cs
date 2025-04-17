using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creating objects for each activity
        var running = new Running
        {
            Date = new DateTime(2022, 11, 3),
            Minutes = 30,
            Distance = 3.0
        };

        var cycling = new Cycling
        {
            Date = new DateTime(2022, 11, 3),
            Minutes = 30,
            Speed = 18.0
        };

        var swimming = new Swimming
        {
            Date = new DateTime(2022, 11, 3),
            Minutes = 30,
            Laps = 20
        };

        // Creating a list of activities
        var activities = new List<Activity> { running, cycling, swimming };

        // Displaying the summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
