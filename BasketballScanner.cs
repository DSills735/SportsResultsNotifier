using HtmlAgilityPack;
using System.Numerics;

namespace SportsResultsNotifier;

internal class BasketballScanner
{
    public static void Scan()
    {
        HtmlWeb web = new HtmlWeb();
        //HtmlDocument document = web.Load("https://www.basketball-reference.com/boxscores/");
        HtmlDocument document = web.Load("https://www.basketball-reference.com/boxscores/?month=05&day=01&year=2026");

        var games = document.DocumentNode.SelectNodes("//div[@class='game_summary expanded nohover']");

        if (games != null)
        {
            foreach (var game in games)
            {
                var winner = game.SelectSingleNode(".//tr[@class='winner']").InnerText.Trim();
                var loser = game.SelectSingleNode(".//tr[@class='loser']").InnerText.Trim();

                Console.WriteLine($"Winner: {winner}, Loser: {loser}");
            }
        }
        else
        {
            Console.WriteLine("No games played today.");
        }
    }
}


///html/body/div[4]/div[3]/div[2]/div[1]/p/strong <- leads to no games played today, but if there were games, the path would be: //div[@class='game_summary expanded nohover']