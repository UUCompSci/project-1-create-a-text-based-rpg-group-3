using static System.Console;

class Program
{
  //================== Initialize Variables ===================

  //------ scenes -------
  const byte INTRO = 0;
  const byte LAB = 1;
  const byte HALLWAY = 2;

  static byte? currentArea = INTRO;

  //------ values -------
  static int coins = 0;
  static int maxHP = 20;
  static int HP = maxHP;

  //------ RNG -------
  static Random rng = new Random(); //not used yet 
  //WriteLine($"Random number: {rng.Next(5)}");

  //---- key choices ----
  static ConsoleKey GetChoice()
  {
      ConsoleKey choice = ReadKey(true).Key;
      WriteLine();
      return choice;
  }

  const ConsoleKey Z = ConsoleKey.Z;
  const ConsoleKey X = ConsoleKey.X;
  const ConsoleKey C = ConsoleKey.C;
  const ConsoleKey V = ConsoleKey.V; //not used yet
  const ConsoleKey Y = ConsoleKey.Y; //not used yet (YES)
  const ConsoleKey N = ConsoleKey.N; //not used yet (NO)
  const ConsoleKey ESC = ConsoleKey.Escape;

  //======================== INVENTORY =========================

  static string[] items = { "Keys", "Lead Pipe" };
  static void PrintInventory()
  {
    WriteLine($"You have {coins} coins and {items[0]} and {items[1]}");
  }

  //======================== MAIN =============================

  static void Main(string[] args)
  {
    Console.Title = "Lab-Grown Element: Awakening";
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine($"Random number: {rng.Next(5)}");

    bool exit = false;
    while (!exit)
      {
          WriteLine();
          switch (currentArea)
          {
              case INTRO:
                  IntroScene();
                  break;
              case LAB:
                  //SpawnLoop();
                  break;
              case HALLWAY:
                  HallLoop(ref exit);
                  //CheckDeath();
                  break;
              default:
                  WriteLine("You died!");
                  exit = true;
                  break;
          }
      }
      Console.ResetColor();
      Console.ReadKey();
  }

  //======================= GAME LOOP ==========================

  

  //===================== OPTIONS LOOP ==========================

  

  //========================= SCENES ===========================

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
    Console.WriteLine("Z. Examine your body.");
    Console.WriteLine("X. Check surroundings.");
    Console.WriteLine("C. Attempt to escape.\n");

    switch (GetChoice())
    {
      case Z:
        ExamineBody();
        break;
      case X:
        CheckSurroundings();
        break;
      case C:
        //EscapeAttempt();
        break;
      default:
        Console.WriteLine("\nYour unstable mind wavers, unable to decide…");
        break;
    }
  }

  static void HallLoop(ref bool exit) //Random number for which hall it is
  {
    WriteLine("Placeholder for hallway exploration");
    WriteLine("Press 'z' to look around, 'esc' to quit: ");

    switch (GetChoice())
    {
      case Z:
        Console.WriteLine("You see a florescent glare in the hall ahead. Around you are panels on the wall with blue tubes of light");
        break;
      case ESC:
        exit = true;
        break;
      default:
        WriteLine("You hesitate and catch your breath");
        break;
    }
  }

  // Scenarios

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

  static void CheckSurroundings()
  {
    if (currentArea == INTRO) // Search laboratory
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
          Console.WriteLine("\nThe console flickers: SECURITY LOCKDOWN ENGAGED. A map of the facility is displayed. The map shows circles around CONTAINMENT_CENTER_3, NORTHERN_SECURITY, and CONFERENCE_4");
      else
          Console.WriteLine("\nYou hesitate, doing nothing.");
    }
  }
}