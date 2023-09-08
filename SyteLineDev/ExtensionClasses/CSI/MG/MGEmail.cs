using CSI.Interfaces.Data;

namespace CSI.MG
{
    public class MGEmail : IEmail
    {
        private readonly IApplicationEvent _applicationEvent;

        public MGEmail(IApplicationEvent applicationEvent)
        {
            _applicationEvent = applicationEvent;
        }

        public void Send(
            string emailTo,
            string emailReplyTo,
            string emailCc,
            string emailBcc,
            string emailSubject,
            string emailMessage)
        {
            var parameters = new CSIApplicationEventParameter[5];

            parameters[0].Name = "EmailTo";
            parameters[0].Value = emailTo;
            parameters[1].Name = "EmailReplyTo";
            parameters[1].Value = emailReplyTo;
            parameters[2].Name = "EmailCc";
            parameters[2].Value = emailCc;
            parameters[3].Name = "EmailSubject";
            parameters[3].Value = emailSubject;
            parameters[4].Name = "EmailMessage";
            parameters[4].Value = emailMessage;

            _applicationEvent.FireApplicationEvent(
                "GenericSendEmail",
                false,
                true,
                out _,
                ref parameters);
        }
    }
}