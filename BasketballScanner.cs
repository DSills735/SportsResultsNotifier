using HtmlAgilityPack;
using System.Numerics;

namespace SportsResultsNotifier;

internal class BasketballScanner
{
    public static void Scan()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load("https://www.basketball-reference.com/boxscores/");




        var games = document.DocumentNode.SelectNodes("//div[contains(@class, 'game_summary')]");

        if (games != null)
        {
            foreach (var game in games)
            {
                var teams = game.SelectNodes(".//tr");

                if (teams != null && teams.Count >= 2)
                {
                    string team1 = teams[0].InnerText.Trim();
                    string team2 = teams[1].InnerText.Trim();

                    Console.WriteLine($"Game Found: {team1} vs {team2}");
                }
            }
        }
        else
        {
            Console.WriteLine("No games found on the page.");
        }

    }
}
