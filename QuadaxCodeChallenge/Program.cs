using System;

namespace QuadaxCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set-up
            int roundCounter = 1;
            int totalRounds = 10;
            int correctGuesses = 0;

            //Create unique values
            Random rnd = new Random();
            int firstDigit = rnd.Next(1, 6);
            int secondDigit = rnd.Next(1, 6);
            int thirdDigit = rnd.Next(1, 6);
            int fourthDigit = rnd.Next(1, 6);

            //Create the secret code!
            int[] secretCode = new int[] { firstDigit, secondDigit, thirdDigit, fourthDigit };

            //Welcome Player
            Console.WriteLine("\nWelcome to Mastermind!\n");
            Console.WriteLine("You will have 10 attempts to guess the correct 4-digit code, with each digit being between 1-6. If your guess includes \n" +
                "a correct number in the correct position, you will see a '+'. If your guess includes a correct number in an incorrect \n" +
                "position you will see a '-'.");
            Console.WriteLine("\n[ Press any key to play ]\n");
            Console.ReadKey();

            //Play!
            while (roundCounter <= 10 && correctGuesses != 4)
            {
                Console.WriteLine($"\n\nThis is round {roundCounter}.\n");
                string userInput = Console.ReadLine();
                char[] codeKey;

                codeKey = userInput.ToCharArray(0, userInput.Length);

                if (userInput.Length > secretCode.Length)
                {
                    Console.WriteLine("Oh no! That's too many numbers... Here's a hint: The secret code is only 4 digits!");
                }
                else if (userInput.Length < secretCode.Length)
                {
                    Console.WriteLine("Oh no! That's not enough numbers... Here's a hint: The secret code is only 4 digits!");
                }
                else
                {
                    for (int counter = 0; counter < userInput.Length; counter++)
                    {
                        if (codeKey[counter].ToString() == secretCode[counter].ToString())
                        {
                            codeKey[counter] = '+';
                            correctGuesses++;
                        }
                        else
                        {
                            for (int codeCounter = 0; codeCounter < secretCode.Length; codeCounter++)
                            {
                                if (codeKey[counter].ToString() == secretCode[codeCounter].ToString())
                                {
                                    codeKey[counter] = '-';
                                }
                            }
                        }
                    }

                    if (correctGuesses == 4)
                    {
                        Console.Clear();
                        Console.WriteLine($"You win! The secret code was {userInput}!");

                    }
                    else
                    {
                        for (int counter = 0; counter < codeKey.Length; counter++)
                        {
                            if (codeKey[counter] == '+' || codeKey[counter] == '-')
                            {
                                Console.Write($"{codeKey[counter]}");
                            }
                            else
                            {
                                Console.Write(" ");
                            }

                        }
                        correctGuesses = 0;
                        Console.WriteLine($"\n\nYou have {totalRounds - roundCounter} guesses left.");
                        roundCounter++;
                    }
                }
            }
            if (roundCounter >= 10 && correctGuesses != 4)
            {
                Console.WriteLine($"Sorry, you lose! The code was {firstDigit}{secondDigit}{thirdDigit}{fourthDigit}.");
            }
        }
    }
}
