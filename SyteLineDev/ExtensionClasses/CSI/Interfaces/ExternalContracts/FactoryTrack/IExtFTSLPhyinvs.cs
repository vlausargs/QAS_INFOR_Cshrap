
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLPhyinvs
    {

        int ChgReplaceSheetSp(string Whse,
                int? SheetNum,
                short? Increment,
                ref string Infobar); 

        int PhyinvItemVSp(string Whse,
                string Item,
                ref byte? LotTracked,
                ref byte? SerialTracked,
                ref string Infobar); 

        int PhyinvLotV2Sp(string Whse,
                string Item,
                string Loc,
                string Lot,
                int? Step,
                ref string Infobar,
                ref string PromptMsg,
                ref string PromptButtons,
                [Optional] string Revision); 

        int PhyinvSerialV2Sp(string Whse,
                string Item,
                string Loc,
                string Lot,
                string SerNum,
                int? Step,
                ref string Infobar,
                ref string PromptMsg,
                ref string PromptButtons,
                string ImportDocId,
                [Optional] Guid? CurrentRowPointer); 

        int PhyinvSheetVSp(string Whse,
                string Item,
                string Loc,
                string Lot,
                string SerNum,
                int? LotTracked,
                int? SerialTracked,
                int? SheetNum,
                int? NewSheet,
                ref int? TagXref,
                ref string Infobar,
                string ImportDocId,
                int? TaxFreeMatl); 

        int PhyinvValEmployeeSp(string Employee,
                string Validate,
                int? MType,
                ref string Infobar); 

    }
}
    
