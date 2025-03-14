using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Job job1 = new Job();
        job1._role = "Graphics Designer";
        job1._role = "Adobe";
        job1._startYear = 2018;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._role = "UX Designer";
        job2._companyName = "Figma";
        job2._startYear = 2021;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._fullName = "John Doe";
        myResume._workHistory.Add(job1);
        myResume._workHistory.Add(job2);

        myResume.Display();
    }
}