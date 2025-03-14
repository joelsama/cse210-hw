using System;
using System.Collections.Generic;

public class Resume
{
    public string _fullName;
    public List<Job> _workHistory = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Resume of: {_fullName}");
        Console.WriteLine("\nWork Experience:");

        foreach (Job job in _workHistory)
        {
            job.Display();
        }
    }
}