using HtmlAgilityPack;

namespace SportsResultsNotifier;
public class Program
{
    public static void Main(string[] args)
    {
        TimeOnly runningTime = new TimeOnly(23, 0, 0); //11PM
        Console.WriteLine($"Waiting until {runningTime} to scan...");

        while (true)
        {
            if (TimeOnly.FromDateTime(DateTime.Now) >= runningTime)
            {
                BasketballScanner.Scan();
                break; 
            }
            Thread.Sleep(10000);
        }
    }

}
