using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void Run()
    {
        DisplayStartMessage();
        PrepareToBegin();
        PerformActivity();
        DisplayEndMessage();
    }

    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("Enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
        Console.WriteLine();
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void PerformActivity();

    public void PrepareToBegin()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void PerformActivity()
    {
        int interval = 4;
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(interval);
            elapsed += interval;

            if (elapsed >= _duration) break;

            Console.Write("Breathe out... ");
            ShowCountdown(interval);
            elapsed += interval;
        }
    }
}

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < _duration)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine("> " + question);
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("You will begin in:");
        ShowCountdown(5);

        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"You listed {items.Count} items!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (activity == null)
            {
                if (choice == "4") break;
                continue;
            }

            activity.Run();
        }
    }
}
