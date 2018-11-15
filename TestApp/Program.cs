using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var number = random.Next(1, 101);

            bool guessCorrectly = false;

            while (!guessCorrectly)
            {
                Console.WriteLine("Give me a number");
                var guess = Int32.Parse(Console.ReadLine());

                if (guess > number)
                    Console.WriteLine("Too high");
                else if (guess < number)
                    Console.WriteLine("Too low");
                else
                {
                    Console.WriteLine("Great, the number is " + number);
                    guessCorrectly = true;
                }
            }

            Console.Read();
        }

      
    }
}
