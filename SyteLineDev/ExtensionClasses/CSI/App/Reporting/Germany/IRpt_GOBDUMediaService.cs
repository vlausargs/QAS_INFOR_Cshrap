using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Reporting.Germany
{
    public interface IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_GetBDTransferData(string ProgramName, DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID );
    }

    public enum GOBDUMediaServiceEnum
    {
        Rpt_SLAptrxps,
        Rpt_SLArtrans,
        Rpt_SLBankAddrs,
        Rpt_SLBankHdrs,
        Rpt_SLCharts,
        Rpt_SLCoitems,
        Rpt_SLCos,
        Rpt_SLCurrates,
        Rpt_SLCurrencyCodes,
        Rpt_SLCustomers,
        Rpt_SLDepts,
        Rpt_SLEmployees,
        Rpt_SLEmpPrBanks,
        Rpt_SLFaclasses,
        Rpt_SLFaCosts,
        Rpt_SLFaDeprs,
        Rpt_SLFaDisps,
        Rpt_SLFamasters,
        Rpt_SLFaTrans,
        Rpt_SLInvHdrs,
        Rpt_SLInvItemAlls,
        Rpt_SLInvItemSurcharges,
        Rpt_SLInvStaxs,
        Rpt_SLItemContentRefs,
        Rpt_SLItems,
        Rpt_SLJourHdrs,
        Rpt_SLLedgers,
        Rpt_SLNonInventoryItems,
        Rpt_SLPoItems,
        Rpt_SLPos,
        Rpt_SLPrbanks,
        Rpt_SLPrdecds,
        Rpt_SLProjMatls,
        Rpt_SLProjs,
        Rpt_SLProjTasks,
        Rpt_SLProjTrans,
        Rpt_SLPrtaxts,
        Rpt_SLPrtrxps,
        Rpt_SLTaxcodes,
        Rpt_SLTaxJurs,
        Rpt_SLUMs,
        Rpt_SLUnitcd1s,
        Rpt_SLUnitcd2s,
        Rpt_SLUnitcd3s,
        Rpt_SLUnitcd4s,
        Rpt_SLVchHdrs,
        Rpt_SLVchItemAlls,
        Rpt_SLVchStaxs,
        Rpt_SLVendors,
        None
    }
}
