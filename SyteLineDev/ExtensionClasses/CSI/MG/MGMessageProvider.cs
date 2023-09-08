using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGMessageProvider : IMessageProvider
    {
        readonly Mongoose.IDO.IMessageProvider messageProvider;
        readonly CSIExtensionClassBase cSIExtensionClassBase;
        public MGMessageProvider(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            this.cSIExtensionClassBase = (CSIExtensionClassBase)cSIExtensionClassBase;
        }
        [Obsolete("Use the other constuctor. Obsolete since 9/15/2021. Remove at 12/15/2021.")]
        public MGMessageProvider(Mongoose.IDO.IMessageProvider messageProvider)
        {
            this.messageProvider = messageProvider;
        }
        private Mongoose.IDO.IMessageProvider MessageProvider
        {
            get
            {
                if (messageProvider != null) return messageProvider;
                return this.cSIExtensionClassBase.GetMessageProvider();
            }
        }
        public string GetMessage(string messageId)
        {
            return MessageProvider.GetMessage(messageId);
        }

        public string GetMessage(string messageId, params object[] args)
        {
            return MessageProvider.GetMessage(messageId, args);
        }

        public string AppendMessage(string message, string messageID)
        {
            return MessageProvider.AppendMessage(message, messageID);
        }

        public string AppendMessage(string message, string messageID, params object[] args)
        {
            return MessageProvider.AppendMessage(message, messageID, args);
        }
    }
}
