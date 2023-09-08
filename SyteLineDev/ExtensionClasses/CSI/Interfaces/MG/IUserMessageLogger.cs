using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public enum CSIUserDefinedMessageType
    {
        UserDefined0 = 4096,
        UserDefined1 = 8192,
        UserDefined2 = 16384,
        UserDefined3 = 32768
    }
    public interface IUserMessageLogger
    {
        void LogUserMessage(string messageSource, CSIUserDefinedMessageType messageType, string format, params object[] args);
        void LogUserMessage(string messageSource, CSIUserDefinedMessageType messageType, string message);

    }
}
