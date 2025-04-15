using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }

    public abstract double GetDistance(); // To be implemented by derived classes
    public abstract double GetSpeed(); // To be implemented by derived classes
    public abstract double GetPace(); // To be implemented by derived classes

    public string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({DurationInMinutes} min) - Distance {GetDistance():0.0}, Speed {GetSpeed():0.0}, Pace: {GetPace():0.0} min per mile";
    }
}

// Derived class for Running
public class Running : Activity
{
    public double DistanceInMiles { get; set; }

    public Running(DateTime date, int durationInMinutes, double distanceInMiles)
    {
        Date = date;
        DurationInMinutes = durationInMinutes;
        DistanceInMiles = distanceInMiles;
    }

    public override double GetDistance()
    {
        return DistanceInMiles;
    }

    public override double GetSpeed()
    {
        return (DistanceInMiles / DurationInMinutes) * 60; // miles per hour
    }

    public override double GetPace()
    {
        return DurationInMinutes / DistanceInMiles; // minutes per mile
    }
}

// Derived class for Cycling
public class Cycling : Activity
{
    public double SpeedInMPH { get; set; }

    public Cycling(DateTime date, int durationInMinutes, double speedInMPH)
    {
        Date = date;
        DurationInMinutes = durationInMinutes;
        SpeedInMPH = speedInMPH;
    }

    public override double GetDistance()
    {
        return (SpeedInMPH * DurationInMinutes) / 60; // distance in miles
    }

    public override double GetSpeed()
    {
        return SpeedInMPH;
    }

    public override double GetPace()
    {
        return 60 / SpeedInMPH; // minutes per mile
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    public int Laps { get; set; }

    public Swimming(DateTime date, int durationInMinutes, int laps)
    {
        Date = date;
        DurationInMinutes = durationInMinutes;
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0 * 0.62; // miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / DurationInMinutes) * 60; // miles per hour
    }

    public override double GetPace()
    {
        return DurationInMinutes / GetDistance(); // minutes per mile
    }
}

// Program to test
class Program
{
    static void Main()
    {
        // Create a list of activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 45, 12.0),
            new Swimming(new DateTime(2022, 11, 3), 40, 20)
        };

        // Display summaries for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
