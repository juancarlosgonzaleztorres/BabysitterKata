using BabysittingBusinessLogic;
using System;

namespace Babysitter
{
    class Program
    {        
        static void Main(string[] args)
        {
            var babysitting = new Babysitting();            
            while(true)
            {
                Console.Clear();
                try
                {
                    Console.WriteLine("Babysitter Kata");
                    Console.WriteLine("Instructions: Enter date and hour where requested. Example 4/24/2018 5pm");
                    Console.WriteLine("For finishing the program press Ctrl+C\n");
                    Console.Write("Start hour: ");
                    var startHour = Console.ReadLine();
                    babysitting.StartTime(DateTime.Parse(startHour));
                    Console.Write("End hour: ");
                    var endHour = Console.ReadLine();
                    babysitting.EndTime(DateTime.Parse(endHour));
                    Console.Write("Bed time: ");
                    var bedTime = Console.ReadLine();
                    babysitting.BedTime(DateTime.Parse(bedTime));
                    Console.Write("Calculated nightly charge: ${0} dollars", babysitting.CalculateNightlyCharge());
                    Console.ReadLine();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Date/hour not entered.");
                    Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Date/hour writen in wrong format.");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            
        }
    }
}
