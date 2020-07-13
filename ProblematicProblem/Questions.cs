using System;
using System.Collections.Generic;
using System.Text;

namespace ProblematicProblem
{
    public class Questions
    {
        
        public bool seeList { get; set; }
        public bool cont { get; set; }
        public bool addToList { get; set; }
        public string contStr { get; set; }

        public bool Question(out bool input)
        {
            do
            {
                Console.WriteLine();

                contStr = Console.ReadLine().ToLower();

                if (contStr != "yes" && contStr != "no")
                { Console.WriteLine("Please enter yes or no!"); }             
                
            } while (contStr != "yes" && contStr != "no");

            return input = contStr == "yes" ? true : false;
        }
    }
}
