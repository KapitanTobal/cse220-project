using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What's your first name?"); 
        string f_name = Console.ReadLine();
        Console.WriteLine("What's your last name?"); 
        string l_name = Console.ReadLine();

        Console.WriteLine($"Your name is {l_name}, {f_name} {l_name}");


    }
}