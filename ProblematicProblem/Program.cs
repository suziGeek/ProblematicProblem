using ProblematicProblem;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {


        static void Main(string[] args)
        {
            string userAge;
            bool userAge1 = true;
            bool seeList = true;
            bool cont = true;
            bool addToList = true;
            string contStr = "";

            Random rng = new Random();

            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");

             Questions myQuestions = new Questions();

            myQuestions.Question(ref addToList);

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            //Fix logical error does not pick up age always says too young for wine :-(**
            //Also add check for int input value
            do
            {
                Console.Write("What is your age? ");
                 userAge = Console.ReadLine();

                int i = 0;
                userAge1 = int.TryParse(userAge, out i);

                if (!userAge1) { Console.WriteLine(" Enter a valid number!"); }
            } while (!userAge1);

            int userAge2 = int.Parse(userAge);

            Console.WriteLine();

          

            Console.Write("Would you like to see the current list of activities? Yes/No : ");

            myQuestions.Question(ref seeList);         

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($" {activity}");
                    Thread.Sleep(250);
                }

                Console.WriteLine();

                Console.Write("Would you like to add any activities before we generate one? yes/no: ");                

                myQuestions.Question(ref addToList);

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Would you like to add more? yes/no: ");
                  
                    myQuestions.Question(ref addToList);

                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.WriteLine("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];

                if (userAge2 > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }
                do
                {
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();

                    contStr = Console.ReadLine().ToLower();

                    if (contStr != "redo" && contStr != "keep")
                    { Console.WriteLine("Please enter Keep or Redo!"); }

                    cont = contStr == "redo" ? true : false;

                } while (contStr != "redo" && contStr != "keep");
            }
        }
    }
}
