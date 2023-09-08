using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface IMessageProvider
    {
        string GetMessage(string messageId);
        string GetMessage(string messageId, params object[] args);
        string AppendMessage(string message, string messageID);
        string AppendMessage(string message, string messageID, params object[] args);
    }
}
