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
            bool seeList = true;
            bool cont = true;
            bool addToList = true;
            string contStr = "";

            Random rng = new Random();

            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };



            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");

             Questions myQuestions = new Questions();

            myQuestions.Question(addToList);

            //do
            //{
            //    Console.WriteLine();
            //    contStr = Console.ReadLine().ToLower();

            //    if (contStr != "yes" && contStr != "no")
            //    { Console.WriteLine("Please enter yes or no!"); }

            //    addToList = contStr == "yes" ? true : false;

            //    Console.WriteLine();

            //} while (contStr != "yes" && contStr != "no");

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Questions myQuestions2 = new Questions();

            myQuestions2.Question(seeList);

            //do
            //{
            //    Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");

            //    contStr = Console.ReadLine().ToLower();

            //    if (contStr != "sure" && contStr != "no thanks")
            //    { Console.WriteLine("Please enter sure or no thanks!"); }

            //    seeList = contStr == "sure" ? true : false;

            //} while (contStr != "sure" && contStr != "no thanks");

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($" {activity}");
                    Thread.Sleep(250);
                }

                Console.WriteLine();


                do
                {
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");

                    Console.WriteLine();
                    contStr = Console.ReadLine().ToLower();

                    if (contStr != "yes" && contStr != "no")
                    { Console.WriteLine("Please enter yes or no!"); }

                    addToList = contStr == "yes" ? true : false;


                } while (contStr != "yes" && contStr != "no");


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
                    do
                    {
                        Console.WriteLine("Would you like to add more? yes/no: ");

                        contStr = Console.ReadLine().ToLower();

                        if (contStr != "yes" && contStr != "no")
                        { Console.WriteLine("Please enter yes or no!"); }

                        addToList = contStr == "yes" ? true : false;

                    } while (contStr != "yes" && contStr != "no");

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

                if (userAge > 21 && randomActivity == "Wine Tasting")
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
