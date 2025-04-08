using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        var comment1_1 = new Comment("JohnDoe", "Great video!");
        var comment1_2 = new Comment("JaneDoe", "Very informative!");
        var comment1_3 = new Comment("TechGuru", "Amazing insights, thanks for sharing!");

        var video1 = new Video("Intro to C# Programming", "TechMaster", 120);
        video1.Comments.Add(comment1_1);
        video1.Comments.Add(comment1_2);
        video1.Comments.Add(comment1_3);

        var comment2_1 = new Comment("DevMaster", "This helped me a lot!");
        var comment2_2 = new Comment("Coder123", "Looking forward to more tutorials!");
        var comment2_3 = new Comment("TechyDude", "Solid explanation!");

        var video2 = new Video("Advanced C# Techniques", "CodeMaster", 180);
        video2.Comments.Add(comment2_1);
        video2.Comments.Add(comment2_2);
        video2.Comments.Add(comment2_3);

        var comment3_1 = new Comment("LearningCSharp", "Great breakdown of C# fundamentals!");
        var comment3_2 = new Comment("CodeNewbie", "This is a fantastic tutorial for beginners!");

        var video3 = new Video("C# Basics for Beginners", "CodeAcademy", 150);
        video3.Comments.Add(comment3_1);
        video3.Comments.Add(comment3_2);

        var videos = new List<Video> { video1, video2, video3 };

        
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}


public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}


public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}
