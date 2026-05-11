namespace SportsResultsNotifier;

internal class Game
{
    public string Team1 { get; set; }
    public int Team1Score { get; set; }
    public string Team2 { get; set; }
    public int Team2Score { get; set; }

    public string Winner;

    public string Loser;
   

    public Game(string team1, int team1Score, string team2, int team2Score, string winner, string loser)
    {
        Team1 = team1;
        Team1Score = team1Score;
        Team2 = team2;
        Team2Score = team2Score;
        Winner = winner;
        Loser = loser;
    }
}
