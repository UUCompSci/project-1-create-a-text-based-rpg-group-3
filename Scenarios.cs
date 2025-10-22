static void HallwayScenario1()
{
    Console.WriteLine("\nYou enter a long, dimly lit hallway. The walls pulse faintly with a bioluminescent glow.");
    Console.WriteLine("The air is thick with a strange hum that makes your energy fluctuate.");
    Console.WriteLine("Suddenly, the floor vibrates, and shards of broken glass slide toward you.");

    // HP -= 3; // You take 3 damage from the unstable floor shards
    // Console.WriteLine("You take 3 damage from the shards.");

    Console.WriteLine("You carefully step over the shards and see a door slightly ajar at the end of the hall.");
}

static void HallwayScenario2()
{
    Console.WriteLine("\nThe hallway narrows, forcing you to move single file.");
    Console.WriteLine("Panels on the walls flicker erratically, and a soft clicking noise echoes around you.");
    Console.WriteLine("A faint blue glow seeps from under a heavy metal door on your right.");

    Console.WriteLine("Do you want to try to open the door? (Y/N)");
    Console.Write("Choice: ");
    var key = GetChoice();
    if (key == Y)
    {
        Console.WriteLine("\nThe door creaks open, revealing a small storage room filled with glowing canisters.");
        Console.WriteLine("One of the canisters pulses with a vibrant energy — it might be antimatter!");

        // coins += 5; // Collect antimatter as coins (unless you have other ideas for antimatter)
        // Console.WriteLine("You carefully take the antimatter canister, adding to your resources.");
    }
    else
    {
        Console.WriteLine("\nYou decide to ignore the door and continue down the hallway.");
    }
}

static void LabRoom()
{
    Console.WriteLine("\nYou step into a large laboratory, the air thick with chemical odors.");
    Console.WriteLine("Workstations are cluttered with half-finished experiments and shattered equipment.");
    Console.WriteLine("In the center of the room is a containment pod flickering with unstable energy.");

    Console.WriteLine("You feel a surge of power, but the pod’s energy is dangerously unstable.");

    // HP -= 5; // Exposure to unstable energy causes damage
    // Console.WriteLine("The unstable energy pulses through you, causing 5 damage.");

    Console.WriteLine("Among the debris, you notice a small vial marked 'Antimatter Stabilizer'.");
    Console.WriteLine("Do you want to pick it up? (Y/N)");
    Console.Write("Choice: ");
    var key = GetChoice();
    if (key == Y)
    {
        // coins += 10; // Gain a valuable item/resource
        // Console.WriteLine("You pocket the Antimatter Stabilizer, feeling it hum with potential.");
    }
    else
    {
        Console.WriteLine("You decide to leave it behind, wary of further risk.");
    }
}

static void SecurityRoom()
{
    Console.WriteLine("\nYou enter a cramped security room with multiple monitors showing static and flickering images.");
    Console.WriteLine("A terminal blinks, asking for input.");

    Console.WriteLine("Attempting to hack the terminal might unlock new areas — or trigger alarms.");

    Console.WriteLine("Attempt hack? (Y/N)");
    Console.Write("Choice: ");
    var key = GetChoice();
    if (key == Y)
    {
       int hackOutcome = rng.Next(0, 2);
       if (hackOutcome == 0)
        {
            Console.WriteLine("\nHack successful! You disable some security protocols.");
            // coins += 7; // Reward for hacking
            // Console.WriteLine("You find stored antimatter credits in the system.");
        }
        else
        {
            Console.WriteLine("\nAlarm triggered! Security turrets activate.");
            // HP -= 7; // Take damage from turrets
            // Console.WriteLine("You take 7 damage avoiding turret fire.");
        }
    }
    else
    {
        Console.WriteLine("You back away from the terminal, avoiding potential danger.");
    }
}

static void BrokenHallway()
{
    Console.WriteLine("\nThe hallway ahead is collapsed, rubble blocking your path.");
    Console.WriteLine("You notice a narrow crawlspace just large enough to squeeze through.");

    Console.WriteLine("Do you attempt to crawl through? (Y/N)");
    Console.Write("Choice: ");
    var key = GetChoice();
    if (key == Y)
    {
        Console.WriteLine("\nYou crawl through the tight space, scraping yourself against jagged metal.");
        // HP -= 2; // Minor damage from scraping
        // Console.WriteLine("You take 2 damage but make it through.");

        Console.WriteLine("On the other side, you discover a hidden maintenance closet with a small energy cell.");
        // coins += 4; // Gain energy cell
        // Console.WriteLine("You collect the energy cell.");
    }
    else
    {
        Console.WriteLine("You decide not to risk it and search for another route.");
    }
}

static void ExperimentalChamber()
{
    Console.WriteLine("\nYou enter an experimental chamber filled with half-assembled machines and strange apparatuses.");
    Console.WriteLine("A machine in the center hums with unstable energy, and a control panel flickers nearby.");

    Console.WriteLine("Do you try to activate the machine? (Y/N)");
    Console.Write("Choice: ");
    var key = GetChoice();
    if (key == Y)
    {
        int chance = rng.Next(0, 3);
        if (chance == 0)
        {
            Console.WriteLine("\nThe machine whirs to life, stabilizing your energy briefly.");
            // HP = Math.Min(HP + 5, maxHP); // Heal 5 HP
            // Console.WriteLine("You recover 5 HP.");
        }
        else
        {
            Console.WriteLine("\nThe machine overloads and emits a shockwave!");
            // HP -= 6; // Damage from shockwave
            // Console.WriteLine("You take 6 damage.");
        }
    }
    else
    {
        Console.WriteLine("You leave the machine alone, wary of its unpredictable power.");
    }
}
