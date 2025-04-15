using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
    }

    public abstract void RecordEvent();

    public virtual string GetDetailsString()
    {
        return $"{Name}: {(IsComplete ? "Complete" : "Incomplete")}";
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
        }
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            Console.WriteLine($"Goal '{Name}' recorded! You earned {Points} points.");
        }
    }
}

public class ChecklistGoal : Goal
{
    public int TotalTimes { get; set; }
    public int TimesCompleted { get; set; }

    public ChecklistGoal(string name, int points, int totalTimes) : base(name, points)
    {
        TotalTimes = totalTimes;
        TimesCompleted = 0;
    }

    public override void RecordEvent()
    {
        if (TimesCompleted < TotalTimes)
        {
            TimesCompleted++;
            Console.WriteLine($"Goal '{Name}' recorded! You earned {Points} points. Completed {TimesCompleted}/{TotalTimes}.");
            if (TimesCompleted == TotalTimes)
            {
                Console.WriteLine($"Goal '{Name}' completed! Bonus points awarded.");
                // Example: Give bonus points
                Console.WriteLine($"Bonus Points! You earned 500 extra points for completing {Name}.");
            }
        }
    }

    public override string GetDetailsString()
    {
        return $"{Name}: Completed {TimesCompleted}/{TotalTimes} times";
    }
}

public class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest!");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. View all goals");
            Console.WriteLine("4. View total points");
            Console.WriteLine("5. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ViewGoals();
                    break;
                case "4":
                    Console.WriteLine($"Total points: {totalPoints}");
                    break;
                case "5":
                    Console.WriteLine("Exiting... Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nEnter goal name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter goal points:");
        int points = int.Parse(Console.ReadLine());
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string goalType = Console.ReadLine();

        switch (goalType)
        {
            case "1":
                goals.Add(new SimpleGoal(name, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, points));
                break;
            case "3":
                Console.WriteLine("Enter the number of times to complete this goal:");
                int totalTimes = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, totalTimes));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine("\nChoose a goal to record an event for:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordEvent();
            totalPoints += goals[goalIndex].Points;
        }
        else
        {
            Console.WriteLine("Invalid goal selected.");
        }
    }

    static void ViewGoals()
    {
        Console.WriteLine("\nYour Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }
}
