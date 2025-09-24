using static System.Console;

class Program
{
  //================== Initialize Variables ===================

  //------ scenes / areas -------
  const byte INTRO = 0;
  const byte LAB = 1;
  const byte HALLWAY = 2; //(1-20)
  const byte HALLWAY2 = 3; //(20-40)
  const byte CONTAINMENT = 4; // anti matter // encounter an alien // (40-50)
  const byte NORTHSEC = 5; // anti matter (50-60)
  const byte CONFERENCE = 6; // anti matter (60-70)
  const byte RADIATION = 7; // 5 damage (70-80)
  const byte NORMAL = 8; // (80-98)
  const byte ESCAPEPOD = 9; //(99-100)

  static byte? currentArea = INTRO;

  //------ values -------
  static int antiMatter = 0;
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
  const ConsoleKey V = ConsoleKey.V; 
  const ConsoleKey Y = ConsoleKey.Y; //not used yet (YES)
  const ConsoleKey N = ConsoleKey.N; //not used yet (NO)
  const ConsoleKey ESC = ConsoleKey.Escape;

  //======================== INVENTORY =========================

  static void PrintInventory()
  {
    WriteLine($"You have {antiMatter} anti matter.");
    WriteLine($"What is this power?");
    WriteLine($"Your health is at {HP} out of {maxHP}.");
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
                  LabScene();
                  break;
              case HALLWAY:
                  HallLoop(ref exit);
                  break;
              case HALLWAY2:
                  HallLoop(ref exit);
                  Console.WriteLine("Why are these halls so long?");
                  break;
              case CONTAINMENT:
                  ContainmentScene();
                  break;
              case NORTHSEC:
                  NorthScene();
                  break;
              case CONFERENCE:
                  ConferenceScene();
                  break;
              case RADIATION:
                  RadiationScene();
                  break;
              case NORMAL:
                  NormalScene();
                  break;
              case ESCAPEPOD:
                  EscapepodScene();
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

  //======================= ESCAPE ATTEMPT ==========================

  static void EscapeAttempt()
  {
    Console.WriteLine("You attempt to make your escape here");
    int escapeValue = rng.Next(11);
    Console.WriteLine($"RNG: {escapeValue}");
    if (escapeValue == 7)
    {
      Console.WriteLine("You successfully escaped");
    }
  }

  //===================== OPTIONS LOOP ==========================

  static void StarterLoop()
  {
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
        Console.WriteLine("You fail to escape");
        break;
      default:
        Console.WriteLine("\nYour unstable mind wavers, unable to decide…");
        break;
    }
  }

  //========================= SCENES ===========================
  static bool introTextShown = false;

  static void IntroScene()
  {
    if (!introTextShown)
    {
      Console.WriteLine("=====================================================");
      Console.WriteLine("                   THE AWAKENING");
      Console.WriteLine("=====================================================\n");

      Console.WriteLine("You awaken in a dim laboratory. Glass shards and");
      Console.WriteLine("cracked steel containment tubes surround you.");
      Console.WriteLine("Your body hums with unstable energy—");
      Console.WriteLine("you are the result of a failed experiment.");
      Console.WriteLine("Yet somehow… you are alive.\n");

      introTextShown = true;
    }

    StarterLoop();
  }

  static void LabScene()
  {
    Console.WriteLine("A sign reads \"LAB\"");
    currentArea = HALLWAY;
  }

// THE core loop of the game sort of
  static void HallLoop(ref bool exit) //Random number for which hall it is
  {
    WriteLine("");
    WriteLine("Z. Look around");
    WriteLine("X. Go forward");
    //WriteLine("C. Attempt to escape");
    WriteLine("V. View status");
    WriteLine("ESC: Quit game");


    switch (GetChoice())
    {
      case Z:
        CheckSurroundings();
        break;
      case X:
        Console.WriteLine("You go forward through the halls");
        int hallRoll = rng.Next(100);

        if (hallRoll < 20)
        {
          currentArea = HALLWAY;
        }

        else if (hallRoll < 40)
        {
          currentArea = HALLWAY2;
        }

        else if (hallRoll < 50)
        {
          currentArea = CONTAINMENT;
        }

        else if (hallRoll < 60)
        {
          currentArea = NORTHSEC;
        }

        else if (hallRoll < 70)
        {
          currentArea = CONFERENCE;
        }

        else if (hallRoll < 80)
        {
          currentArea = RADIATION;
        }

        else if (hallRoll < 99)
        {
          currentArea = NORMAL;
        }

        else
        {
          currentArea = ESCAPEPOD;
        }

        break;
      /*
      case C:
        EscapeAttempt();
        break;
      */
      case V:
        PrintInventory();
        break;
      case ESC:
        exit = true;
        break;
      default:
        WriteLine("You hesitate and catch your breath");
        break;
    }
  }

  static void ContainmentScene()
  {
    Console.WriteLine("A sign reads \"CONTAINMENT_CENTER_3\"");
    currentArea = HALLWAY;
  }

  static void NorthScene()
  {
    Console.WriteLine("A sign reads \"NORTHERN_SECURITY\"");
    currentArea = HALLWAY;
  }

  static void ConferenceScene()
  {
    Console.WriteLine("A sign reads \"CONFERENCE_4\"");
    currentArea = HALLWAY;
  }

  static void RadiationScene()
  {
    Console.WriteLine("A sign reads \"CAUTION: RADIATION\"");
    currentArea = HALLWAY;
  }

  static void NormalScene()
  {
    Console.WriteLine("There is nothing interesting about this room.");
    currentArea = HALLWAY;
  }

  static void EscapepodScene()
  {
    Console.WriteLine("A sign reads \"ESCAPEPODS\"");
    currentArea = HALLWAY;
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
    Console.Write("");
    string input = Console.ReadLine() ?? string.Empty;

    if (input == "1")
      Console.WriteLine("\nYou steady yourself… for now. Your form stabilizes slightly.");
    else if (input == "2")
      Console.WriteLine("\nA shockwave rattles the room! Glass shatters further, alarms faintly beep.");
    else
      Console.WriteLine("\nYou flicker uncertainly, doing nothing.");
    PostExamineBody();
  }
  
  static void PostExamineBody()
  {
      Console.WriteLine("What do you do?");
      Console.WriteLine("Z. Check Surroundings.");
      Console.WriteLine("X. Attempt to escape.\n");

      switch (GetChoice())
      {
          case Z:
              CheckSurroundings();
              break;
          case X:
              //EscapeAttempt();
              break;
          default:
              Console.WriteLine("\nYour unstable mind wavers, unable to decide…");
              break;
      }
  }

  static void CheckSurroundings()
  {

    if (currentArea == INTRO) // Search laboratory
    {
      Console.WriteLine("\nYou scan the ruined laboratory. Broken computers hum faintly.");
      Console.WriteLine("\nThere is a mysterious hallway with an almost blinding florescent light");
      Console.WriteLine("Scrawled notes litter the floor: \"Subject unstable… sentience improbable.\"");
      Console.WriteLine("It seems the scientists never expected you to live.\n");

      Console.WriteLine("What now?");
      Console.WriteLine("1. Examine the notes more closely.");
      Console.WriteLine("2. Check the glowing console in the corner.");
      Console.WriteLine("3. Walk into the hallway.");
      Console.Write("Choice: ");
      Console.Write("");
      string input = Console.ReadLine() ?? string.Empty;

      if (input == "1")
      {
        Console.WriteLine("\nThe notes describe you as 'Element X-13'… a failed weapon prototype.");
      }
      else if (input == "2")
      {
        Console.WriteLine("\nThe console flickers: SECURITY LOCKDOWN ENGAGED. A map of the facility is displayed. The map shows circles around CONTAINMENT_CENTER_3, NORTHERN_SECURITY, and CONFERENCE_4");
      }
      else if (input == "3")
      {
        currentArea = HALLWAY;
      }
      else
        Console.WriteLine("\nYou hesitate, doing nothing.");
    }

    if (currentArea == HALLWAY)
    {
      Console.Write("You look around the hall. Metal beams line the walls with blueish florescent light immenating from the roof.");
      Console.Write(" The walls seem to be curved inward. The hall seems round in shape.");
    }
  }
}