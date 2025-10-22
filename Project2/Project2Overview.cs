using System;
using System.Collections.Generic;

// ================= ENUMS & RECORDS =====================

enum LocationType { Intro, Lab, Hallway, Containment, NorthSecurity, Conference, Radiation, Normal, Experiment, EscapePod }

record /* EnemyInfo(string Name, int Damage, int HP) */

// =================== PLAYER CLASS =======================

class Player
{
    private int hp;
    private int maxHP;
    private int antiMatter;
    private double luckModifier;
    private double antiMatterBonus;

    public string Name { get; private set; }
    public bool IsAlive => HP > 0;

    public int HP
    {
        get => hp;
        set => hp = value < 0 ? 0 : (value > maxHP ? maxHP : value);
    }

    public int MaxHP => maxHP;
    public int AntiMatter
    {
        get => antiMatter;
        private set => antiMatter = value < 0 ? 0 : value;
    }

    public double Luck => luckModifier;

    // ----- Constructor Overloading -----
    public Player(string name) : this(name, 20, 1.0, 1.0) { }

    public Player(string name, int health, double luck, double antimatterBonus)
    {
        Name = name;
        maxHP = health;
        HP = health;
        antiMatterBonus = antimatterBonus;
        luckModifier = luck;
    }

    public void Heal(int amount)
    {
        HP += amount;
        GameUtils.PrintMessage($"You heal for {amount} HP.");
    }

    public void TakeDamage(int amount)
    {
        HP -= amount;
        GameUtils.PrintMessage($"You take {amount} damage. (HP: {HP}/{MaxHP})");
    }

    public void AddAntiMatter()
    {
        int gain = (int)Math.Ceiling(1 * antiMatterBonus);
        AntiMatter += gain;
        GameUtils.PrintMessage($"You absorbed {gain} AntiMatter. Total: {AntiMatter}");
    }

    public void PrintStatus()
    {
        GameUtils.PrintMessage($"HP: {HP}/{MaxHP} | AntiMatter: {AntiMatter}");
    }
}

// =================== LOCATION CLASS =======================

class Location
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public LocationType Type { get; private set; }

    public Action<Player>? OnEnter { get; set; }

    public Location(string name, string description, LocationType type)
    {
        Name = name;
        Description = description;
        Type = type;
    }

    public void Enter(Player player)
    {
        GameUtils.PrintHeader(Name);
        Console.WriteLine(Description);
        OnEnter?.Invoke(player);
    }
}

// =================== STATIC UTIL CLASS =======================

static class GameUtils
{
    public static Random RNG = new Random();

    public static void PrintHeader(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n==== {text.ToUpper()} ====\n");
        Console.ResetColor();
    }

    public static void PrintMessage(string text)
    {
        Console.WriteLine(text);
    }

    public static bool RandomChance(double chance)
    {
        return RNG.NextDouble() < chance;
    }

    public static int Roll(int min, int max)
    {
        return RNG.Next(min, max);
    }
}

// =================== MAIN GAME CLASS =======================

class Game
{
    private Player player;
    private bool exit = false;
    private LocationType currentArea = LocationType.Intro;
    private Dictionary<LocationType, Location> locations = new();

    public Game()
    {
        InitializeLocations();
        ChooseCharacter();
    }

    private void ChooseCharacter()
    {
        Console.WriteLine("Choose your form:");
        Console.WriteLine("1. Balanced Entity (20 HP, normal luck, normal antimatter gain)");
        Console.WriteLine("2. Fragile Reactor (10 HP, normal luck, DOUBLE antimatter gain)");
        Console.WriteLine("3. Luminous Wraith (15 HP, HIGH luck, 50% antimatter gain)");
        Console.Write("Choice: ");
        string choice = Console.ReadLine()?.Trim() ?? "";

        switch (choice)
        {
            case "2":
                player = new Player("Fragile Reactor", 10, 1.0, 2.0);
                break;
            case "3":
                player = new Player("Luminous Wraith", 15, 1.5, 0.5);
                break;
            default:
                player = new Player("Balanced Entity");
                break;
        }

        Console.WriteLine($"\nYou awaken as: {player.Name}");
    }

    private void InitializeLocations()
    {
        locations[LocationType.Intro] = new Location("The Awakening",
            "You awaken in a shattered containment chamber. The hum of machinery surrounds you.", LocationType.Intro)
        {
            OnEnter = (p) => IntroScene()
        };

        locations[LocationType.Lab] = new Location("The Lab",
            "A broken laboratory full of shattered glass and notes labeled 'Subject X-13'.", LocationType.Lab)
        {
            OnEnter = (p) => LabScene(p)
        };

        locations[LocationType.Containment] = new Location("Containment Center 3",
            "A heavy door slides open. The air hums with unstable energy.", LocationType.Containment)
        {
            OnEnter = (p) => ContainmentScene(p)
        };

        locations[LocationType.NorthSecurity] = new Location("Northern Security",
            "A flickering terminal and a glass chamber with something glowing inside.", LocationType.NorthSecurity)
        {
            OnEnter = (p) => NorthScene(p)
        };

        locations[LocationType.Conference] = new Location("Conference Room 4",
            "A long table, dusty notes, and a faint shimmer of antimatter on top.", LocationType.Conference)
        {
            OnEnter = (p) => ConferenceScene(p)
        };

        locations[LocationType.Radiation] = new Location("Radiation Chamber",
            "Warning lights blink. The air feels deadly here.", LocationType.Radiation)
        {
            OnEnter = (p) => RadiationScene(p)
        };

        locations[LocationType.Normal] = new Location("Empty Room",
            "A quiet, unremarkable chamber.", LocationType.Normal)
        {
            OnEnter = (p) => NormalScene(p)
        };

        locations[LocationType.Experiment] = new Location("Experimental Facility",
            "Strange devices hum with unstable energy.", LocationType.Experiment)
        {
            OnEnter = (p) => ExperimentScene(p)
        };

        locations[LocationType.EscapePod] = new Location("Escape Pod Bay",
            "A line of cracked pods—one still looks intact.", LocationType.EscapePod)
        {
            OnEnter = (p) => EscapePodScene(p)
        };

        locations[LocationType.Lab] = new Location("The Lab",
     "A broken laboratory full of shattered glass and notes labeled 'Subject X-13'.", LocationType.Lab)
        {
            OnEnter = (p) => LabScene(p)
        };
    }


    public void Run()
    {
        while (!exit && player.IsAlive)
        {
            if (player.AntiMatter >= 3)
            {
                EscapeSuccess2();
                break;
            }

            locations[currentArea].Enter(player);
        }

        if (!player.IsAlive)
        {
            YouDied();
        }

        Console.ResetColor();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // ===================== SCENES ========================

    private void IntroScene()
    {
        Console.WriteLine("You slowly gain consciousness...");
        Console.WriteLine("Broken machines surround you, and your body crackles with unstable light.\n");

        Console.WriteLine("Z. Examine your body");
        Console.WriteLine("X. Check surroundings");
        Console.WriteLine("C. Attempt to escape");
        Console.Write("Choice: ");

        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.Z:
                ExamineBody();
                break;
            case ConsoleKey.X:
                currentArea = LocationType.Lab;
                break;
            case ConsoleKey.C:
                Console.WriteLine("You are too weak to escape... yet.");
                break;
            default:
                Console.WriteLine("You flicker uncertainly.");
                break;
        }
    }

    private void LabScene(Player p)
    {
        Console.WriteLine("You step into the main lab. Scattered notes reference something called 'Antimatter Synthesis'.");
        MoveNext(p);
    }

    private void ContainmentScene(Player p)
    {
        Console.WriteLine("Do you want to pick up the glowing antimatter? (Y/N)");
        if (Console.ReadKey(true).Key == ConsoleKey.Y)
        {
            p.AddAntiMatter();
        }
        else
        {
            Console.WriteLine("You leave it behind.");
        }
        MoveNext(p);
    }

    private void NorthScene(Player p)
    {
        Console.WriteLine("The terminal flickers: 'SECURITY OVERRIDE?' (Y/N)");
        if (Console.ReadKey(true).Key == ConsoleKey.Y)
        {
            if (GameUtils.RandomChance(0.5 * p.Luck))
            {
                Console.WriteLine("Hack successful! You collect the antimatter safely.");
                p.AddAntiMatter();
            }
            else
            {
                Console.WriteLine("Turrets activate! You take 7 damage.");
                p.TakeDamage(7);
            }
        }
        else
        {
            Console.WriteLine("You back away from the terminal.");
        }
        MoveNext(p);
    }

    private void ConferenceScene(Player p)
    {
        Console.WriteLine("You see antimatter on a table. Pick it up? (Y/N)");
        if (Console.ReadKey(true).Key == ConsoleKey.Y)
        {
            p.AddAntiMatter();
        }
        MoveNext(p);
    }

    private void RadiationScene(Player p)
    {
        Console.WriteLine("The radiation burns through your form! You take 10 damage.");
        p.TakeDamage(10);
        MoveNext(p);
    }

    private void NormalScene(Player p)
    {
        Console.WriteLine("There’s nothing here.");
        MoveNext(p);
    }

    private void ExperimentScene(Player p)
    {
        Console.WriteLine("A strange device flickers. Activate it? (Y/N)");
        if (Console.ReadKey(true).Key == ConsoleKey.Y)
        {
            if (GameUtils.RandomChance(0.33 * p.Luck))
            {
                Console.WriteLine("You are healed by its energy!");
                p.Heal(5);
            }
            else
            {
                Console.WriteLine("It explodes violently!");
                p.TakeDamage(6);
            }
        }
        MoveNext(p);
    }

    private void EscapePodScene(Player p)
    {
        Console.WriteLine("You find a working pod. Do you enter? (Y/N)");
        if (Console.ReadKey(true).Key == ConsoleKey.Y)
        {
            EscapeSuccess();
        }
        else
        {
            MoveNext(p);
        }
    }

    // =================== FLOW HELPERS ===================

    private void MoveNext(Player p)
    {
        Console.WriteLine("\nZ. Continue through halls | V. View status | ESC: Quit");
        var key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.Z:
                int roll = GameUtils.Roll(0, 111);
                currentArea = roll switch
                {
                    < 20 => LocationType.Hallway,
                    < 45 => LocationType.Containment,
                    < 60 => LocationType.NorthSecurity,
                    < 70 => LocationType.Conference,
                    < 80 => LocationType.Radiation,
                    < 98 => LocationType.Normal,
                    < 110 => LocationType.Experiment,
                    _ => LocationType.EscapePod
                };
                break;
            case ConsoleKey.V:
                p.PrintStatus();
                break;
            case ConsoleKey.Escape:
                exit = true;
                break;
        }
    }

    private void ExamineBody()
    {
        Console.WriteLine("You examine your unstable form. Energy crackles through you.");
    }

    private void EscapeSuccess()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYou escape through the pod into an unknown world. You win!");
        Console.ResetColor();
        exit = true;
    }

    private void EscapeSuccess2()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYour antimatter overwhelms you! You blast free from the facility.");
        Console.WriteLine("Freedom... and the start of something greater.");
        Console.ResetColor();
        exit = true;
    }

    private void YouDied()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nYour form collapses into nothingness.");
        Console.ResetColor();
    }
}

// =================== PROGRAM ENTRY =======================

class Program
{
    static void Main()
    {
        Console.Title = "Lab-Grown Element: Awakening";
        new Game().Run();
    }
}

