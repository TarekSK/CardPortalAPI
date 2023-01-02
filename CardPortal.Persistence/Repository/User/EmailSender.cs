using CardPortal.Domain.Helper.ServiceResponse;
using System.Net;
using System.Net.Mail;

namespace CardPortal.Persistence.Repository.User
{
    public static class EmailSender
    {
        public static ServiceResponse EmailSend(string emailTo, string subject, string content)
        {
            // Service Response - Init
            ServiceResponse serviceResponse = new ServiceResponse();


            // Smtp Client
            SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);

            // Credentials
            smtpClient.Credentials = new NetworkCredential("tarek.sk@live.com", "@Nothingisfree1");

            // Delivery Method
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            // SSL - Enable
            smtpClient.EnableSsl = true;

            // Mail Message - Init
            MailMessage mail = new MailMessage();

            // Mail Message - From
            mail.From = new MailAddress("tarek.sk@live.com", "RevenueAI Task Email Sender");

            // Mail Message - To
            mail.To.Add(new MailAddress(emailTo));

            // Mail Message - Subject
            mail.Subject = subject;

            // Mail Message - Body
            mail.Body = content;

            try
            {
                // Mail Message - Send
                smtpClient.Send(mail);

                // Service Reponse - OK
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Reponse - InternalServer Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
            }

            // Service Response
            return serviceResponse;
        }
    }
}
