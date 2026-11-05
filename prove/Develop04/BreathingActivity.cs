
using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        ShowPrologue();

        Console.WriteLine();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            int remaining = (int)Math.Ceiling(
                (endTime - DateTime.Now).TotalSeconds);

            int breatheInTime = Math.Min(4, remaining);

            Console.Write("Breathe in... ");
            ShowCountdown(breatheInTime);

            remaining = (int)Math.Ceiling(
                (endTime - DateTime.Now).TotalSeconds);

            if (remaining <= 0)
            {
                break;
            }

            int breatheOutTime = Math.Min(4, remaining);

            Console.Write("Breathe out... ");
            ShowCountdown(breatheOutTime);

            Console.WriteLine();
        }

        ShowEpilogue();
    }
}
