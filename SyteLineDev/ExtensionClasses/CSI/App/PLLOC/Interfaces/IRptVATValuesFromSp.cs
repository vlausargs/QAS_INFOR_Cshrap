using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IRptVATValuesFromSp
    {
        DataTable GetRpt_VATSp(byte? TaxJurTaxSystem = null, byte? ExOptszShowDetail = null, string TaxJurTaxJur = null, DateTime? ExBegInvStaxInvDate = null, DateTime? ExEndInvStaxInvDate = null, short? TaxDateStartingOffset = null, short? TaxDateEndingOffset = null, string ExOptgoJournalId = null, byte? DisplayHeader = null, string BGSessionId = null, int? TaskId = null, string pSite = null, string BGUser = null, string SortBy = null, byte? ExcludeNullLineNum = 0, byte? ExcludeJournalEntries = 0);
        DataTable GetCLM_VatProceduralMarkingsSp(DateTime? ExBegInvStaxInvDate = null, DateTime? ExEndInvStaxInvDate = null);
        bool SetResultToRPTVATManager(DataTable dtRpt_VATSp, DataTable dtCLM_VatProceduralMarkingsSp);
    }
}
