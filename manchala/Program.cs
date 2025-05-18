using System;

namespace manchala
{
    class Program
    {
        static void Main(string[] args)
        {
            bool inv = false, start=false;
            string p1 = "PL1", p2 = "PL2";
            int starter = 4;
            string menu = "\tMANQALE\n\n" +
                    "1-Play with a friend\n" +
                    "2-Play with bot\n" +
                    "3-How to play\n" +
                    "4-Credits\n";
            string underCons= "\n"+
                        "██    ██ ███    ██ ██████  ███████ ██████       ██████  ██████  ███    ██ ███████ ████████ ██████  ██    ██  ██████ ████████ ██  ██████  ███    ██ \n"+
                        "██    ██ ████   ██ ██   ██ ██      ██   ██     ██      ██    ██ ████   ██ ██         ██    ██   ██ ██    ██ ██         ██    ██ ██    ██ ████   ██ \n"+
                        "██    ██ ██ ██  ██ ██   ██ █████   ██████      ██      ██    ██ ██ ██  ██ ███████    ██    ██████  ██    ██ ██         ██    ██ ██    ██ ██ ██  ██ \n"+
                        "██    ██ ██  ██ ██ ██   ██ ██      ██   ██     ██      ██    ██ ██  ██ ██      ██    ██    ██   ██ ██    ██ ██         ██    ██ ██    ██ ██  ██ ██ \n"+
                        " ██████  ██   ████ ██████  ███████ ██   ██      ██████  ██████  ██   ████ ███████    ██    ██   ██  ██████   ██████    ██    ██  ██████  ██   ████ \n"+
                        "                                                                                                                                                   \n"+
                        "0-return to the main menu";
            string HowToPlay = "\tHOW TO PLAY\nSet Up: Place 4 stones in each of the 12 round spaces.\n " +
                        "Leave the larger ovals (called the ‘Store’) empty.\n\n" +
                        "First player chooses a house on their own side(right), picks up the stones in that space\n" +
                        "and starting with the next space, drops one stone in each space going counterclockwise(including the Store)\n" +
                        "until all of the stones are played out. \n\n" +
                        "Now it is the other player’s turn to do the same using stones on their side and continuing to play counterclockwise\n\n" +
                        " * Note: if there are enough stones to reach the other player’s \"Store\"(not house), skip that space and continue on your own.\n\n" +
                        "If your last stone goes into your Store, you get to go again.\n\n" +
                        "If your last stone goes into an empty space on \"your\" side, move that stone AND\n" +
                        "any captured stones ( those directly across on your opponent’s side) to your Store.\n\n" +
                        "The game ends when either player has no more stones in their six circles. The remaining stones go to the other player’s Store.\n\n" +
                        "The winner is the player with the most stones in their Store\n\n" +
                        "0-return to the main menu";
            string credits = "credits";
            string whatToShow = menu;
            

            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.Write(whatToShow);
                if (inv)
                {
                    Console.Write("\n\n *** INVALID INPUT ***\n");
                    inv = false;
                }
                if (start)
                {
                    Console.Clear();
                    Console.WriteLine($"enter first player's name:   (default is '{p1}')");
                    string input = Console.ReadLine();
                    if (input.Length > 0)
                        p1 = input;
                    Console.Clear();
                    Console.WriteLine($"enter second player's name:   (default is '{p2}')");
                    input = Console.ReadLine();
                    if (input.Length > 0)
                        p2 = input;
                    Console.Clear();
                    Console.WriteLine($"how many stones do you want to play with? we recommend 3 or 4   (default is '{starter}')");
                    input = Console.ReadLine();
                    try
                    {
                        starter = Convert.ToInt32(input);
                    }
                    catch (Exception e) {
                        Console.WriteLine("then 4 it is.");
                        Console.WriteLine("press any key to continue");
                        Console.ReadKey();
                    }
                    break;
                }
                /*while (!Console.KeyAvailable)
                {
                }*/

                // Key is available - read it
                key = Console.ReadKey(true).Key;
                start = false;
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        start = true;
                        break;
                    case ConsoleKey.NumPad2:
                        whatToShow = underCons;
                        break;
                    case ConsoleKey.NumPad3:
                        whatToShow = HowToPlay;
                        break;
                    case ConsoleKey.NumPad4:
                        whatToShow = credits;
                        break;
                    case ConsoleKey.NumPad0:
                        whatToShow = menu;
                        break;
                    default:
                        inv = true;
                        break;
                }
            } while (key != ConsoleKey.Escape);

            Manqale game = new Manqale(p1, p2, starter);
            game.Play();

        }
    }

}
