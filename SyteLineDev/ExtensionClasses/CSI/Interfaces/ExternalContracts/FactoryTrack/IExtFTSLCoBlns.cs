
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLCoBlns
    {

        int ValidateItemCustSp(string CustNum,
                string CustItem,
                string Item,
                ref string NewItem,
                ref int? ItemCustExists,
                ref int? ItemCustUpdate,
                ref int? ItemCustAdd,
                ref string WarningMsg,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar); 

    }
}
    
