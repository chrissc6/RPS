using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    class RockPaperScissorsGame
    {
        private Random rng;
        private int wins;
        private int losses;
        private int ties;

        public RockPaperScissorsGame()
        {
            rng = new Random();
        }

        public void Play()
        {
            string Choice;
            Choice = Prompt();

            while(Choice != "Q")
            {
                string computerChoice = GetComputerChoice();
                Winner(Choice, computerChoice);
                PrintScore();
                Console.Clear();
                Choice = Prompt();
            }
        }

        private void PrintScore()
        {
            Console.WriteLine("\nWins: {0}", wins);
            Console.WriteLine("Losses: {0}", losses);
            Console.WriteLine("Ties: {0}", ties);
            Console.WriteLine("Press 'Enter' to coninue");
            Console.ReadKey();
        }

        private void Winner(string Choice, string computerChoice)
        {
            if (Choice == computerChoice)
            {
                ties++;
                Console.WriteLine("Tie, you both picked {0}", Converter(Choice));
            }
            else if ((Choice == "R" && computerChoice == "S") || (Choice == "P" && computerChoice == "R") || (Choice == "S" && computerChoice == "P"))
            {
                wins++;
                Console.WriteLine("You WON! {0} beats {1}", Converter(Choice), Converter(computerChoice));
            }
            else
            {
                losses++;
                Console.WriteLine("You lose, good day sir. {0} beats {1} ", Converter(computerChoice), Converter(Choice));
            }

        }

        private string Converter(string choice)
        {
            if (choice == "R")
                return "Rock";
            else if (choice == "P")
                return "Paper";
            else
                return "Scissors";
        }

        private string GetComputerChoice()
        {
            int choice = rng.Next(1, 4);

            if (choice == 1)
                return "R";
            else if (choice == 2)
                return "P";
            else
                return "S";
        }

        private string Prompt()
        {
            while(true)
            {
                Console.WriteLine("**Rock Paper Scissors Game**");
                Console.WriteLine("Enter you choice (R)ock, (P)aper, (S)cissors, (Q)uit: ");
                string schoice = Console.ReadLine();

                if(schoice == "R" || schoice == "P" || schoice == "S" || schoice == "Q")
                {
                    return schoice;
                }
                else
                    Console.WriteLine("Not a choice");
            }
        }

    }
}
