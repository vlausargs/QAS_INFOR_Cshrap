
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLReasons
    {

        int ReasonGetInvAdjAcctSp(string ReasonCode,
                string ReasonClass,
                string Item,
                ref string Acct,
                ref string AcctUnit1,
                ref string AcctUnit2,
                ref string AcctUnit3,
                ref string AcctUnit4,
                ref string AccessUnit1,
                ref string AccessUnit2,
                ref string AccessUnit3,
                ref string AccessUnit4,
                ref string Description,
                ref string Infobar,
                [Optional, DefaultParameterValue((byte)0)] byte? ByContainer,
                ref byte? AcctIsControl); 

    }
}
    
