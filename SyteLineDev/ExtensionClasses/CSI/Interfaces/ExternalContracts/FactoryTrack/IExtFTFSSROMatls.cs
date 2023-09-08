
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTFSSROMatls
    {

        int SSSFSCustItemCreateSp(string Item,
                string CustNum,
                string CustItem,
                string UM,
                ref string Infobar); 

        int SSSFSSROMatlDCItemSp(string PartnerId,
                string SroNum,
                int? SroLine,
                int? SroOper,
                DateTime? TransDate,
                string Item,
                string Whse,
                decimal? QtyConv,
                string BillCode,
                string TransType,
                ref string Description,
                ref string UM,
                ref string Loc,
                ref string Lot,
                ref byte? LotTracked,
                ref byte? SerialTracked,
                ref decimal? UnitCostConv,
                ref decimal? UnitPriceConv,
                ref string CurrCode,
                ref string CustNum,
                ref string Pricecode,
                ref string Infobar,
                ref string CustItem,
                ref string LotPrefix,
                [Optional] ref string Prompt,
                [Optional] ref string PromptButtons,
                [Optional, DefaultParameterValue((byte)1)] byte? ValidteItemExistsFlag); 

        int SSSFSSROMatlDCSaveSp(string PartnerId,
                string SroNum,
                int? SroLine,
                int? SroOper,
                string Item,
                string TransType,
                DateTime? TransDate,
                decimal? QtyConv,
                string UM,
                string Whse,
                string Loc,
                string Lot,
                decimal? PriceConv,
                string BillCode,
                string NoteContent,
                ref Guid? RowPointer,
                ref int? TransNum,
                ref byte? AutoPost,
                ref string Infobar,
                string CustItem,
                [Optional] ref string Prompt,
                [Optional] ref string PromptButtons,
                [Optional] string MatlDescription,
                [Optional] string DocumentNum); 

        int SSSFSSROMatlDCValidSp(string Level,
                string PartnerID,
                DateTime? TransDate,
                string SRONum,
                ref int? SROLine,
                ref int? SROOper,
                ref string SroDesc,
                ref string LineItem,
                ref string OperDesc,
                ref string TransType,
                ref string BillCode,
                ref string Whse,
                ref string Infobar,
                ref string CustNum); 

        int SSSFSSROMatlRateSp(string InType,
                string InSroNum,
                int? InSroLine,
                int? InSroOper,
                string InItem,
                string InCustNum,
                DateTime? InTransDate,
                decimal? InQty,
                string InCurrCode,
                string InPricecode,
                string InBillCode,
                decimal? InCost,
                ref decimal? OutUnitPrice,
                ref string Prompt,
                ref string PromptButtons,
                ref string Infobar,
                string UM,
                ref decimal? OutUnitPriceConv,
                [Optional] string InCustItem); 

        int SSSFSSroTransPostMatlSp(Guid? iRowPointer,
                byte? iLineTrans,
                string iMode,
                ref string Infobar); 

    }
}
    
