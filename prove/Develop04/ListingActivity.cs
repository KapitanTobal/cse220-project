
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            // Read input without blocking the activity timer.
            Task<string?> inputTask = Task.Run(() => Console.ReadLine());

            TimeSpan remaining = endTime - DateTime.Now;

            if (remaining <= TimeSpan.Zero ||
                !inputTask.Wait(remaining))
            {
                break;
            }

            string? item = inputTask.Result;

            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        return items;
    }

    public void Run()
    {
        ShowPrologue();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountdown(5);

        Console.WriteLine("Start listing your answers:");

        List<string> items = GetListFromUser();

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");

        ShowEpilogue();
    }
}
