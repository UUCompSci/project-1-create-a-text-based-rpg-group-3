
using static System.Console;

//================== Initialize Variables ===================

//------ scenes -------
const byte LAB = 0;
const byte HALLWAY = 1;
byte? currentArea = LAB;

//------ values -------
int coins = 0;
int maxHP = 20;
int HP = maxHP;

//------ RNG -------
Random rng = new Random(); //not used yet 
WriteLine($"Random number: {rng.Next(5)}");

//---- key choices ----
ConsoleKey GetChoice()
{
    ConsoleKey choice = ReadKey(true).Key;
    WriteLine();
    return choice;
}

const ConsoleKey Z = ConsoleKey.Z;
const ConsoleKey X = ConsoleKey.X;
const ConsoleKey V = ConsoleKey.V; //not used yet
const ConsoleKey Y = ConsoleKey.Y; //not used yet (YES)
const ConsoleKey N = ConsoleKey.N; //not used yet (NO)
const ConsoleKey ESC = ConsoleKey.Escape;

//======================== INVENTORY =========================

string[] items;
items = new string[] { "Keys", "Lead Pipe" };

void PrintInventory()
{
  WriteLine($"You have {coins} coins and {items[0]} and {items[1]}");
}

//======================= GAME LOOP ==========================

bool exit = false;
while (!exit)
{
    WriteLine();
    switch (currentArea)
    {
        case LAB:
            SpawnLoop();
            break;
        case HALLWAY:
            HallLoop();
            //CheckDeath();
            break;
        default:
            WriteLine("You died!");
            exit = true;
            break;
    }
}

//===================== OPTIONS LOOP ==========================

void SpawnLoop()
{
  WriteLine("You wake up lost in a spaceship. Where do you go?");
  Write("Press 'z' to examine your surroundings, 'x' to walk down corridor, 'v' to view inventory, 'esc' to quit the game: ");
  switch (GetChoice())
  {
    case Z:
      CheckSurroundings();
      break;
    case X:
      currentArea = HALLWAY;
      break;
    case ESC:
      exit = true;
      break;
  }
}

//========================= SCENES ===========================


void CheckSurroundings()
{
  if (currentArea == LAB)
  {
    WriteLine("You are in a laboratory with green testtubes covering the walls. Each tube has a human-like creature but something is off. One of the tubes is broken and empty. ");
  }
}

void HallLoop() //Random number for which hall it is
{
  WriteLine("Placeholder for hallway exploration");
  WriteLine("Press 'z' to look around, 'esc' to quit: ");

  switch (GetChoice())
  {
    case Z:
      WriteLine("You see a florescent glare in the hall ahead. Around you are panels on the wall with blue tubes of light");
      break;
    case ESC:
      exit = true;
      break;
    default:
      WriteLine("You hesitate and catch your breath");
      break;
  }
}