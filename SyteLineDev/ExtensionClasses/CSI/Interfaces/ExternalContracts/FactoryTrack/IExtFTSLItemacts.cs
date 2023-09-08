
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLItemacts
    {

        int ContainerIssuePostSp(string ContainerNum,
                DateTime? TransDate,
                string AccountCode,
                string AcctUnit1,
                string AcctUnit2,
                string AcctUnit3,
                string AcctUnit4,
                string ReasonCode,
                ref string InfoBar,
                [Optional] string CallFrom,
                [Optional] string DocumentNum); 

        int MiscIssueGetLocQtyOnHandSp(string Whse,
                string Item,
                string Loc,
                decimal? QtyIssued,
                string Site,
                ref decimal? LocQtyOnHand,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar,
                [Optional, DefaultParameterValue(0)] ref int? CallForm,
                [Optional] string UM); 

        int MiscIssueGetLotAndLoc(string Whse,
                string Item,
                ref string Loc,
                ref string Lot,
                ref string ImportDocId,
                ref string TrxRestrictCode); 

    }
}
    
