using System.Net.Mail;

namespace SportsResultsNotifier;

internal class Email
{

    public static void Send(List<Game> games)
    {
        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        bool enableSSL = true;
        string fromEmail = "david.sills100@gmail.com";
        string toEmail = "recipient@example.com";
        string password = "your_email_password";
        string subject = "Sports Results Notification";
        string body = "Here are the latest sports results: \n";

        if (games != null && games.Count > 0)
        {
            foreach (Game game in games)
            {
                string res = $"\n\n{game.Winner} beat the  {game.Loser} with a score of {game.Team2Score} to {game.Team1Score}";
                body += res;
                res = "";
            }
        }
        else
        {
            body = "No NBA games were found.";
        }
        /* UNCOMMENT WHEN ABLE TO TEST SMTP
        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = false;
            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.Credentials = new System.Net.NetworkCredential(fromEmail, password);
                smtp.EnableSsl = enableSSL;
                smtp.Send(mail);
            }
         }
        */
    TestEmailBodyOutput(body);
    }
    internal static void TestEmailBodyOutput(string t){

        Console.WriteLine($"{t}");
        }
    
}
