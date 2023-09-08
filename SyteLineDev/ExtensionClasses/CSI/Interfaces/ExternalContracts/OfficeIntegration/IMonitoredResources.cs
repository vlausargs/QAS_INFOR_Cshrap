using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.OfficeIntegration.Outlook
{
    public interface IMonitoredResources
    {
        int SLSp_ExecuteSqlSp(ref string Result,
                              string QueryStr,
                              ref string Infobar);

        int SLPreciseSearchPreferenceListsSp(string emailBody,
                                             string emailid,
                                             ref string InfobarType,
                                             ref string xmlResult,
                                             string formDBName);
    }
}
