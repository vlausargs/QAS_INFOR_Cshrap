//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobOperationListing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_JobOperationListing
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) Rpt_JobOperationListingSp(
            string StartJob = null,
            string EndJob = null,
            int? StartSuffix = null,
            int? EndSuffix = null,
            string JobStat = null,
            string StartItem = null,
            string EndItem = null,
            string StartProdMix = null,
            string EndProdMix = null,
            DateTime? StartJobDate = null,
            DateTime? EndJobDate = null,
            int? StartOpera = null,
            int? EndOpera = null,
            int? OperLstDate = null,
            int? OperLstHr = null,
            string OperLstBC = null,
            string PrintCfgDetail = null,
            int? PrintBCFmt = null,
            int? PageOpera = null,
            int? DisplayRefFields = null,
            int? StartJobDateOffset = null,
            int? EndJobDateOffset = null,
            int? ShowInternal = null,
            int? ShowExternal = null,
            int? JobRouteNotes = null,
            int? JobMatlNotes = null,
            int? DisplayHeader = null,
            string BGSessionId = null,
            string pSite = null);
    }
}

