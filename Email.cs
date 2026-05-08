using System.Net.Mail;

namespace SportsResultsNotifier;

internal class Email
{
        
    public static void Send(string subject, string body)
    {
       string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        bool enableSSL = true;
        string fromEmail = "david.sills100@gmail.com";
        string toEmail = "recipient@example.com";
        string password = "your_email_password";
        string subject = "test";
        string body = "This is a test email from C# application.";

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
    }
}
