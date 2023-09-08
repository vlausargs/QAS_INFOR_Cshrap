using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Logger
{
    public class UserMessageLogger : IUserMessageLogger
    {
        public void LogUserMessage(string messageSource, CSIUserDefinedMessageType messageType, string format, params object[] args)
        {
            Mongoose.IDO.IDORuntime.LogUserMessage
                (messageSource, (Mongoose.IDO.UserDefinedMessageType)(messageType), format, args);
        }

        public void LogUserMessage(string messageSource, CSIUserDefinedMessageType messageType, string message)
        {
            Mongoose.IDO.IDORuntime.LogUserMessage
                   (messageSource, (Mongoose.IDO.UserDefinedMessageType)(messageType), message);
        }
    }
}
