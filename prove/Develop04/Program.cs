
using System;

class Program
{
    // EXCEEDING REQUIREMENTS:
    // I added an activity tracker that counts how many times
    // each mindfulness activity has been completed.
    // The user can view their progress from the main menu.
    // This feature goes beyond the core requirements.

    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        int choice = 0;

        while (choice != 5)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity statistics");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out choice))
            {
                choice = 0;
            }

            switch (choice)
            {
                case 1:
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathingCount++;
                    break;

                case 2:
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    reflectionCount++;
                    break;

                case 3:
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++;
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Activity Statistics");
                    Console.WriteLine("-------------------");
                    Console.WriteLine($"Breathing activities: {breathingCount}");
                    Console.WriteLine($"Reflection activities: {reflectionCount}");
                    Console.WriteLine($"Listing activities: {listingCount}");
                    Console.WriteLine($"Total activities: {breathingCount + reflectionCount + listingCount}");
                    break;

                case 5:
                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (choice != 5)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }
}
