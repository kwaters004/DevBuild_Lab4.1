using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4._1
{
    class Program
    {

        static int getDieRoll(int sides)
        {
            Random rnd = new Random();
            return rnd.Next(1, sides + 1);
        }

        static Dictionary<int, int> AddToDict(Dictionary<int, int> dict, int roll)
        {
            if (dict.ContainsKey(roll))
            {
                dict[roll] = dict[roll] + 1;
                return dict;
            }
            else
            {
                dict.Add(roll, 1);
                return dict;
            }
        }

        static bool[] winningMessage(int total, bool[] allWinning)
        {
            switch (total)
            {
                case 2:
                    Console.WriteLine("Snake Eyes!");
                    Console.WriteLine("Craps!");
                    allWinning[0] = true;
                    break;
                case 3:
                    Console.WriteLine("Ace Deuce!");
                    Console.WriteLine("Craps!");
                    allWinning[1] = true;
                    break;
                case 7:
                    Console.WriteLine("You Won!!");
                    allWinning[2] = true;
                    break;
                case 11:
                    Console.WriteLine("You Won!!");
                    allWinning[3] = true;
                    break;
                case 12:
                    Console.WriteLine("Box Cars!");
                    Console.WriteLine("Craps!");
                    allWinning[4] = true;
                    break;
            }
            return allWinning;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Grand Circus Casino!\n");

            int counter = 0;
            int sides = 1;

            // initializing these here, becuase I use them outside of the while (!done) loop
            
            Dictionary<int, int> rollTracker = new Dictionary<int, int>();
            bool[] allWinning = new bool[] { false, false, false, false, false };

            bool done = false;
            while (!done)
            {
                // resetting these for new dice with different number of sides

                rollTracker = new Dictionary<int, int>();
                allWinning = new bool[] { false, false, false, false, false };
                counter = 0;

                bool validSides = false;
                while (!validSides)
                {
                    Console.Clear();
                    Console.Write("How many sides on the dice? ");


                    bool isInt = Int32.TryParse(Console.ReadLine(), out sides);
                    if (isInt && sides > 0)
                    {
                        validSides = true;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that was not a valid number of sides. Please try again.");
                        continue;
                    }
                }
                Console.Write("Press ENTER to roll the dice.");
                Console.ReadLine();

                bool doneRolling = false;
                while (!doneRolling)
                {
                    counter += 1;
                    int die1 = getDieRoll(sides);
                    int die2 = getDieRoll(sides);
                    Console.WriteLine($"\nRoll {counter}:");
                    Console.WriteLine($"The first die was a {die1}.");
                    Console.WriteLine($"The second die was a {die2}.");
                    rollTracker = AddToDict(rollTracker, die1);
                    rollTracker = AddToDict(rollTracker, die2);
                    int total = die1 + die2;
                    Console.WriteLine($"\nThe total of the rolled values is {total}\n");

                    if (sides == 6)
                    {
                        allWinning = winningMessage(total, allWinning);
                    }
                    else
                    {

                        // this was to exit the loop if a number of sides other than 6 was selected and I was running it continuously

                        //counter += 1;
                        //if (counter == 1000)
                        //{
                        //    doneRolling = true;
                        //}
                    }

                    Console.Write("\nWould you like to roll again? (y/n)");
                    string ans2 = Console.ReadLine().ToLower();
                    if (ans2 == "y" || ans2 == "n")
                    {
                        if (ans2 == "n")
                        {
                            doneRolling = true;
                        }
                    }

                    // This will make the app run until all winning combinations are gotten at least once

                    //int numTrues = 0;
                    //foreach (bool check in allWinning)
                    //{
                    //    if (check.Equals(true))
                    //    {
                    //        numTrues += 1;
                    //    }
                    //}
                    //if (numTrues == 5)
                    //{
                    //    doneRolling = true;
                    //}


                    // This was just to loop it a bunch of times instead of having to continue

                    //counter += 1;
                    //if (counter == 1000)
                    //{
                    //    doneRolling = true;
                    //}
                }

                Console.Write("Would you like to continue? (y/n) ");
                string ans = Console.ReadLine().ToLower();
                if (ans == "y" || ans == "n")
                {
                    if (ans == "n")
                    {
                        done = true;
                    }
                }
            }
            double totalRolls = 0;

            foreach (var item in rollTracker)
            {
                totalRolls += item.Value;
            }
            Console.Clear();

            foreach (var item in rollTracker.OrderBy(i => i.Key))
            {
                int theKey = item.Key;
                int theCount = item.Value;
                string numTime = $"{theKey} was rolled {theCount} time(s).";
                string percent = $" ({ theCount / totalRolls * 100:0.00}% of rolls)";
                Console.WriteLine($"{numTime,-27}{percent,15}");
            }

            Console.WriteLine($"\nTotal Dice Rolls: {totalRolls}\n");


            // Below was to check whether or not the booleans in the allWinnings array were changing.

            //int winnings = 0;
            //if (sides == 6)
            //foreach (bool item in allWinning)
            //{
            //    winnings += 1;
            //    //Console.WriteLine(item);
            //    switch(winnings)
            //    {
            //        case 1:
            //            Console.WriteLine($"Snake Eyes: {item}");
            //            break;
            //        case 2:
            //            Console.WriteLine($"Ace Deuce: {item}");
            //            break;
            //        case 3:
            //            Console.WriteLine($"Win for 7: {item}");
            //            break;
            //        case 4:
            //            Console.WriteLine($"Win for 11: {item}");
            //            break;
            //        case 5:
            //            Console.WriteLine($"Box Cars: {item}");
            //            break;
            //    }
            //}







        }



    }
}

