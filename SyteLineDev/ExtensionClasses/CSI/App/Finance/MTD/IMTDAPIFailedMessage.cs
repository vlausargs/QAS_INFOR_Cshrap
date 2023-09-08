using System.Collections.Generic;
using System.Net;

namespace CSI.Finance.MTD
{
    public interface IMTDAPIFailedMessage
    {
        Dictionary<string, string> GetCallFailedMassage(WebException e);
    }
}