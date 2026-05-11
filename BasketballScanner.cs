using HtmlAgilityPack;

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
                    var team1 = game.SelectSingleNode(".//tr[1]/td[1]/a").InnerText.Trim();
                    var team1Score = game.SelectSingleNode(".//tr[1]/td[2]").InnerText.Trim();
                    var team2 = game.SelectSingleNode(".//tr[2]/td[1]/a").InnerText.Trim();
                    var team2Score = game.SelectSingleNode(".//tr[2]/td[2]").InnerText.Trim();

                    Console.WriteLine($"Game Found: {team1} Score: {team1Score} vs {team2} Score: {team2Score}");
                    
                    Console.WriteLine($"Winner: {(int.Parse(team1Score) > int.Parse(team2Score) ? team1 : team2)}");
                }
            }
        }
        else
        {
            Console.WriteLine("No games found on the page.");
        }

    }
}
