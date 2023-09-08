
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLCoitemShps
    {

        int COShippingCleanupSp(); 

        int COShippingLoopSp(int? OnHandNegative,
                ref int? FirstSequenceWithError,
                ref int? RecordsPosted,
                ref string Infobar,
                ref string PromptButtons,
                [Optional, DefaultParameterValue((byte)1)] byte? MsgFlag,
                [Optional, DefaultParameterValue((byte)1)] byte? SuppressReturnError,
                [Optional] string DocumentNum); 

        int SerialExpiryDateSp(string SerialNum,
                string SerialItem,
                [Optional, DefaultParameterValue((byte)1)] byte? SelectFlag,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string InfoBar); 

        int ShipLcrSp(string PCoNum,
                DateTime? PTransDate,
                string PMText,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar); 

    }
}
    
