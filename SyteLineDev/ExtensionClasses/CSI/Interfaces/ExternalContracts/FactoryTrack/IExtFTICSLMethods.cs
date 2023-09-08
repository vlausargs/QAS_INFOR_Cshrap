
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTICSLMethods
    {

        int ICCreateOrUpdateBlanketPoSp(ref string PPoNum,
                ref int? PPoLine,
                ref int? PPoLineRelease,
                string PVendNum,
                string PItem,
                decimal? PQty,
                ref string Infobar); 

        int ICCreateOrUpdatePoSp(ref string PPoNum,
                ref int? PPoLine,
                string PVendNum,
                string PItem,
                decimal? PQty,
                ref string Infobar); 

        int ICUpdateUserInitialSp(string UserInitial,
                ref string Infobar); 

        int NextTrnSp(string Context,
                string Prefix,
                int? KeyLength,
                ref string Key,
                ref string Infobar); 

        int TransAddSp(string PTrnNum,
                string PItem,
                string PFromSite,
                string PFromWhse,
                string PToSite,
                string PToWhse,
                decimal? PQtyOrdered,
                DateTime? PDueDate,
                string PToRefType,
                string PToRefNum,
                int? PToRefLineSuf,
                int? PToRefRelease,
                int? PFromMrpFirm,
                string PRcptsRefNum,
                ref string CurTrnNum,
                ref int? CurTrnLine,
                string TrnLoc,
                string FOBSite,
                ref int? ItemLocQuestionAsked,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar,
                [Optional, DefaultParameterValue(0)] int? CreateTransitLoc); 

    }
}
    
