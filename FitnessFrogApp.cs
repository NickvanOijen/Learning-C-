using System;

namespace Treehouse.FitnessFrog

{
  class Program
  {
    static void Main()
    {
      
      var runningTotal = 0.0;
            
      while (true)
      {
          // Prompt the user for minutes exercised
          Console.Write("Enter how many minutes you exercised or type \"quit\" to exit: ");
          var entry = Console.ReadLine();
        
          if (entry.ToLower() == "quit")
        {
              break;
        }
        try
        {
           var minutes = double.Parse(entry);
                
           if(minutes <=0)
           {
           Console.WriteLine( minutes + " is not an acceptable value");
                
           continue;
           }
           else if(minutes <= 10)
           {  
           Console.WriteLine(" DUDE, that's Better than nothing, am i right?");
           }
           else if(minutes <= 30)
           {
           Console.WriteLine(" way to go, but ways to go");
           }
           else if(minutes <= 60)
           {
           Console.WriteLine(" you must be an ninja warrior in training");
           }
           else 
           {
           Console.WriteLine(" now you are just showing off");
           }
                     
// Add minutes exercised total
          runningTotal += minutes;
                 }
                 catch(FormatException)
                 {
                 Console.WriteLine(" dude, type numbers!");
                 continue;
                 }
             
   
      // display minutes exercised to the screen
          Console.WriteLine(" You've entered " + runningTotal + " minutes");
        }
      // Repeat until the user quits
          
      Console.WriteLine(" Goodbye ");
    }
  }
}

// CLASS NOTES:
// all code is contained in a class (everything in curly thingies
// static void main = method, organises codes en separeates them in parts
// methods can run other methods, its called calling methods
// methods named main ALWAYS are the first methods that run
// software developers work by solving problems. the 4P's of problemsolving:
// Preparation  -  understand the problem and think of a solution
// Plan  -  plan out the solution
// Perform  -  perform the actions required for the purposed solution
// Perfect  -  Perfect the solution
// a well defined problem is understanding the nature of the problem and the information //needed to solve it.
// Plan: where to begin?  split a problem in more "smaller" problems
// framework is a large collection of code
// Namespace.ClassName.MethodName(Parameter1Type Parameter1Name, Parameter2Type);
// stad.postcode.straat

// REPL = Read Evaluate Print Loop
// makes running lines possible without creating a file and writing classes/methods

// parsing = extracting information from text
// Integer = number without decimals

// == equality operator 
