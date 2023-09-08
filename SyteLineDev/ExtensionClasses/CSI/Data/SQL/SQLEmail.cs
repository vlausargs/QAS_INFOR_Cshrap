using CSI.Interfaces.Data;

namespace CSI.Data.SQL
{
    public class SQLEmail : IEmail
    {
        public void Send(
            string emailTo,
            string emailReplyTo,
            string emailCc,
            string emailBcc,
            string emailSubject,
            string emailMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}