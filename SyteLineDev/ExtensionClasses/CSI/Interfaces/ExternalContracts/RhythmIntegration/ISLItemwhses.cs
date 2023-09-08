using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.RhythmIntegration
{
    public interface ISLItemwhses
    {
        int WhseQtyListSp([DefaultParameterValue(null), Optional] string PWhse, string PIitem, ref decimal? PTotalOnHand, ref string PWhseOnHand);
    }
}
