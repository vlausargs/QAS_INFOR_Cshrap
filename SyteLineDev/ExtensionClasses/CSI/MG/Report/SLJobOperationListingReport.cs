//PROJECT NAME: ReportExt
//CLASS NAME: SLJobOperationListingReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLJobOperationListingReport")]
    public class SLJobOperationListingReport : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_JobOperationListingSp([Optional] string StartJob,
            [Optional] string EndJob,
            [Optional] int? StartSuffix,
            [Optional] int? EndSuffix,
            [Optional] string JobStat,
            [Optional] string StartItem,
            [Optional] string EndItem,
            [Optional] string StartProdMix,
            [Optional] string EndProdMix,
            [Optional] DateTime? StartJobDate,
            [Optional] DateTime? EndJobDate,
            [Optional] int? StartOpera,
            [Optional] int? EndOpera,
            [Optional] int? OperLstDate,
            [Optional] int? OperLstHr,
            [Optional] string OperLstBC,
            [Optional] string PrintCfgDetail,
            [Optional] int? PrintBCFmt,
            [Optional] int? PageOpera,
            [Optional] int? DisplayRefFields,
            [Optional] int? StartJobDateOffset,
            [Optional] int? EndJobDateOffset,
            [Optional] int? ShowInternal,
            [Optional] int? ShowExternal,
            [Optional] int? JobRouteNotes,
            [Optional] int? JobMatlNotes,
            [Optional] int? DisplayHeader,
            [Optional] string BGSessionId,
            [Optional] string pSite)
        {
            var iRpt_JobOperationListingExt = new Rpt_JobOperationListingFactory().Create(this, true);

            var result = iRpt_JobOperationListingExt.Rpt_JobOperationListingSp(StartJob,
                EndJob,
                StartSuffix,
                EndSuffix,
                JobStat,
                StartItem,
                EndItem,
                StartProdMix,
                EndProdMix,
                StartJobDate,
                EndJobDate,
                StartOpera,
                EndOpera,
                OperLstDate,
                OperLstHr,
                OperLstBC,
                PrintCfgDetail,
                PrintBCFmt,
                PageOpera,
                DisplayRefFields,
                StartJobDateOffset,
                EndJobDateOffset,
                ShowInternal,
                ShowExternal,
                JobRouteNotes,
                JobMatlNotes,
                DisplayHeader,
                BGSessionId,
                pSite);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }
    }
}
