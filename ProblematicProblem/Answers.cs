using System;
using System.Collections.Generic;
using System.Text;

namespace Answers
{
    public class Answers
    {
        public void Question()
        {
            bool addToList;
            string contStr;
            do
            {
                
                Console.WriteLine();
                contStr = Console.ReadLine().ToLower();

                if (contStr != "yes" && contStr != "no")
                { Console.WriteLine("Please enter yes or no!"); }

                addToList = contStr == "yes" ? true : false;

                Console.WriteLine();

            } while (contStr != "yes" && contStr != "no");

        }
    }
}
