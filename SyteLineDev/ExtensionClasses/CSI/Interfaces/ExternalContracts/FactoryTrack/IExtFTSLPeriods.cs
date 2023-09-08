
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLPeriods
    {

        int DateChkSp([Optional] DateTime? PDate,
                [Optional] string FieldLabel,
                [Optional] string FunctionLabel,
                [Optional] ref string Infobar,
                [Optional] ref string PromptMsg,
                [Optional] ref string PromptButtons); 

    }
}
    
