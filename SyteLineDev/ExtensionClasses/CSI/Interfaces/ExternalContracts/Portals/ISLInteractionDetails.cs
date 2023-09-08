using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLInteractionDetails
    {
        int AddToPortalInteractionSp(ref decimal? InteractionId,
                                            string Note,
                                            string InteractionType,
                                            string Description,
                                            string Topic,
                                            string RefType,
                                            Guid? RefRowPointer,
                                            [Optional, DefaultParameterValue(0)] int? CustSeq,
        ref string IntHeaderText,
        ref string Infobar);

        int GetMaxInteractionDetailsSequenceSp(decimal? InteractionId,
                                                      ref decimal? MaxSequence,
                                                      ref string InfobarType);
    }
}
