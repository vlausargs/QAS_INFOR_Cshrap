using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLInventoryLevels
    {
        int GetInvSumStartEndDates(ref DateTime? PStartDate, ref DateTime? PEndDate);
    }
}
