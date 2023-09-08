using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.OfficeIntegration.Outlook
{
    public interface ISLInteractionDetails
    {
        int GetMaxInteractionDetailsSequenceSp(decimal? InteractionId,
                                               ref decimal? MaxSequence,
                                               ref string InfobarType);
    }
}
