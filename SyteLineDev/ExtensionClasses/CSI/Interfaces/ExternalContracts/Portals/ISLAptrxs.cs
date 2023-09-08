using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLAptrxs
    {
        int GetRateSp(string ForCurrCode, byte? UseBuyRate, [Optional] DateTime? TransDate, [Optional, DefaultParameterValue((byte)0)] byte? SetResultantRateDiv, [Optional, DefaultParameterValue((byte)0)] byte? UseCustomsAndExciseRates, [Optional] string Site, [Optional] string DomCurrCode, [Optional] ref decimal? ResultantRate, [Optional] ref byte? ResultantRateDiv, [Optional] ref decimal? DomToEuro, [Optional] ref byte? DomToEuroDiv, [Optional] ref decimal? ForToEuro, [Optional] ref byte? ForToEuroDiv, [Optional] ref byte? EuroBasis, ref string Infobar);
    }
}
