
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLContainerItems
    {

        int ValidateContainerItemsSp(string ContainerNum,
                string CurWhse,
                string RefType,
                [Optional] string RefNum,
                [Optional] short? RefLineSuf,
                [Optional] short? RefRelease,
                [Optional, DefaultParameterValue((byte)0)] byte? MessageContentFlg,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar,
                [Optional, DefaultParameterValue((byte)0)] byte? VerifyQtyFlag,
                [Optional, DefaultParameterValue((byte)0)] byte? ExtScrap,
                [Optional] string TransType); 

        int WarningReceiveItemToContainerSp(string ContainerNum,
                ref string PromptMsg,
                ref string PromptButtons); 

    }
}
    
