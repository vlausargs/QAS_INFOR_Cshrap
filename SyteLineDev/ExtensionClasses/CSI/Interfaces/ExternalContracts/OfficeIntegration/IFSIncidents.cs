using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.OfficeIntegration.Outlook
{
    public interface IFSIncidents
    {
        int SSSFSIncPriorityDatesSp(string PriorCode,
                                           DateTime? IncDateTime,
                                           string CustNum,
                                           string SerNum,
                                           string Item,
                                           ref DateTime? FollowupDateTime,
                                           ref DateTime? WarningDateTime,
                                           ref DateTime? LateDateTime,
                                           ref string InfoBar);
    }
}
