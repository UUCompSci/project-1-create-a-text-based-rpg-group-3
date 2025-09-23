using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Lab-Grown Element: Awakening";
        Console.ForegroundColor = ConsoleColor.Green;

        IntroScene();

        Console.ResetColor();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void IntroScene()
    {
        Console.WriteLine("=====================================================");
        Console.WriteLine("                   THE AWAKENING");
        Console.WriteLine("=====================================================\n");

        Console.WriteLine("You awaken in a dim laboratory. Glass shards and");
        Console.WriteLine("cracked steel containment tubes surround you.");
        Console.WriteLine("Your body hums with unstable energy—");
        Console.WriteLine("you are the result of a failed experiment.");
        Console.WriteLine("Yet somehow… you are alive.\n");

        Console.WriteLine("What do you do?");
        Console.WriteLine("1. Examine your body.");
        Console.WriteLine("2. Search the laboratory.");
        Console.WriteLine("3. Attempt to escape.\n");

        Console.Write("Enter choice (1-3): ");
        string input = Console.ReadLine() ?? string.Empty;

        switch (input)
        {
            case "1":
                ExamineBody();
                break;
            case "2":
                SearchLab();
                break;
            case "3":
                EscapeAttempt();
                break;
            default:
                Console.WriteLine("\nYour unstable mind wavers, unable to decide…");
                break;
        }
    }

    static void ExamineBody()
    {
        Console.WriteLine("\nYou look down at your shimmering, unstable form.");
        Console.WriteLine("Energy arcs across your surface, flickering between");
        Console.WriteLine("solid and gas. You feel both fragile and powerful.\n");

        Console.WriteLine("What now?");
        Console.WriteLine("1. Focus your energy inward to stabilize.");
        Console.WriteLine("2. Release a burst of energy outward.");
        Console.Write("Choice: ");
        string input = Console.ReadLine() ?? string.Empty;

        if (input == "1")
            Console.WriteLine("\nYou steady yourself… for now. Your form stabilizes slightly.");
        else if (input == "2")
            Console.WriteLine("\nA shockwave rattles the room! Glass shatters further, alarms faintly beep.");
        else
            Console.WriteLine("\nYou flicker uncertainly, doing nothing.");
    }

    static void SearchLab()
    {
        Console.WriteLine("\nYou scan the ruined laboratory. Broken computers hum faintly.");
        Console.WriteLine("Scrawled notes litter the floor: \"Subject unstable… sentience improbable.\"");
        Console.WriteLine("It seems the scientists never expected you to live.\n");

        Console.WriteLine("What now?");
        Console.WriteLine("1. Examine the notes more closely.");
        Console.WriteLine("2. Check the glowing console in the corner.");
        Console.Write("Choice: ");
        string input = Console.ReadLine() ?? string.Empty;

        if (input == "1")
            Console.WriteLine("\nThe notes describe you as 'Element X-13'… a failed weapon prototype.");
        else if (input == "2")
            Console.WriteLine("\nThe console flickers: SECURITY LOCKDOWN ENGAGED. A map of the facility is displayed.");
        else
            Console.WriteLine("\nYou hesitate, doing nothing.");
    }

    static void EscapeAttempt()
    {
        Console.WriteLine("\nYou stagger toward the steel door. It’s locked tight.");
        Console.WriteLine("The energy within you surges—");
        Console.WriteLine("perhaps you can force your way out… if you dare.\n");

        Console.WriteLine("What now?");
        Console.WriteLine("1. Concentrate your energy and blast the door.");
        Console.WriteLine("2. Search for another exit.");
        Console.Write("Choice: ");
        string input = Console.ReadLine() ?? string.Empty;

        if (input == "1")
            Console.WriteLine("\nThe door buckles under your power! Beyond it lies a dark hallway…");
        else if (input == "2")
            Console.WriteLine("\nBehind a stack of crates, you find a vent—small, but unstable like you.");
        else
            Console.WriteLine("\nYou wait… the silence of the lab presses in.");
    }
}
