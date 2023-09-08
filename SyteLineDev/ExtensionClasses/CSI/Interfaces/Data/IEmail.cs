namespace CSI.Interfaces.Data
{
    public interface IEmail
    {
        void Send(
            string emailTo,
            string emailReplyTo,
            string emailCc,
            string emailBcc,
            string emailSubject,
            string emailMessage);
    }
}