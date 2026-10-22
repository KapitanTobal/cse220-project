public class Program
{
    public static void Main(string[] args)
    {
        // Creativity: The user can choose a specific Doctrinal Mastery
        // scripture or choose one randomly from the ScriptureLibrary.

        ScriptureLibrary library = new ScriptureLibrary();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine();
            Console.WriteLine("Choose a scripture to memorize:");
            Console.WriteLine();

            for (int i = 0; i < library.GetCount(); i++)
            {
                Scripture scripture = library.GetScripture(i);
                Console.WriteLine($"{i + 1}. {scripture.GetReferenceString()}");
            }

            Console.WriteLine();
            Console.WriteLine("R. Choose a random scripture");
            Console.WriteLine("Q. Quit");
            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine() ?? "";

            if (choice.Trim().ToLower() == "q")
            {
                break;
            }

            Scripture selectedScripture;

            if (choice.Trim().ToLower() == "r")
            {
                selectedScripture = library.GetRandomScripture();
            }
            else if (int.TryParse(choice, out int number)
                     && number >= 1
                     && number <= library.GetCount())
            {
                selectedScripture = library.GetScripture(number - 1);
            }
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            PracticeScripture(selectedScripture);

            Console.WriteLine();
            Console.WriteLine("Press Enter to choose another scripture.");
            Console.ReadLine();
        }
    }

    public static void PracticeScripture(Scripture scripture)
    {
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayString());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words or type 'quit' to stop:");

            string input = Console.ReadLine() ?? "";

            if (input.Trim().ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayString());
        Console.WriteLine();
        Console.WriteLine("Congratulations! You hid the entire scripture.");
    }
}