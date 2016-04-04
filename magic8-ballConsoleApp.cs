using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace magic_8ball
{
    class Program
    {
        static void Main(string[] args)
        {
            //preserve current console text color
            ConsoleColor oldColor = Console.ForegroundColor;

            TellPeople();

            //create randomizer object
            Random randomObject = new Random();

            // loop forever and ever and ever and ever
            while (true)
            {
                string questionString = GetQuestionFromUser();

                int numberOfSecondsToSleep = randomObject.Next(5) + 1;
                Console.WriteLine("Thinking about your answer, please stand by....");
                Thread.Sleep(numberOfSecondsToSleep * 1000);

                if (questionString.Length == 0)
                {
                    Console.WriteLine("you need to type a question FOOL!!");
                    continue;
                }

                // see if the user typed quit
                if (questionString.ToLower() == "quit")
                {
                    break;
                }

                if (questionString.ToLower() == "you suck")
                {
                    Console.WriteLine("you suck even more, bye!!");
                    break;
                }
                //Get a Random number
                int randomNumber = randomObject.Next(4);

                Console.ForegroundColor = (ConsoleColor)randomObject.Next(15);

                // use random number to determine response
                switch (randomNumber)
                {
                    case 0:
                        {
                            Console.WriteLine("YES");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("NO");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Hell NO");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Hell Yeah!!");
                            break;
                        }
                }
            }

            //cleaning up
            Console.ForegroundColor = oldColor;
        }
        static void TellPeople()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("M");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("agic 8-Ball");
        }

        static string GetQuestionFromUser() 
              {       
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("ask a question?: ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string questionString = Console.ReadLine();

                return questionString;
            }
            }
                }                  
