using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Guessing_Game
{
    internal class Program
    {
        // global random variable to achieve pure randomness via same variable
        static Random rand = new Random();
        static void Main(string[] args)
        {

            // Performance statistics
            int replicates = 1000000;
            List<int> results = new List<int>();
            for (int i = 0; i < replicates; i++)
            {
                results.Add(GuessingGame());
            }
            Console.WriteLine("Number of guessing games ran: " + replicates);
            Console.WriteLine("Average number of guesses needed: " + results.Average());
            Console.WriteLine("Number of games within 6 guesses: " + results.Where(x => x < 7).ToList().Count());
            Console.ReadLine();
        }

        /* Generates a random number between 1 and 10d0 
         * 
         */
        static int GuessingGame(bool debugMode = false)
        {
            int numberToGuess = rand.Next(1, 100);
            if (debugMode) Console.WriteLine("Guessing the number " + numberToGuess);
            int numberOfGuesses = 0;
            int[] range = new int[] { 0, 100 };

            while (true)
            {
                int guess = (int)range.Average();
                numberOfGuesses++;
                if (debugMode) Console.WriteLine("Run " + numberOfGuesses + ", Guessing " + guess);
                if (guess < numberToGuess)
                {
                    range[0] = guess;
                }
                else if (guess > numberToGuess)
                {
                    range[1] = guess;
                }
                else
                {
                    break;
                }
            }

            return numberOfGuesses;

        }
    }
}
