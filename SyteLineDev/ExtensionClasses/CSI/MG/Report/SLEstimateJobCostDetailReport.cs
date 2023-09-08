//PROJECT NAME: ReportExt
//CLASS NAME: SLEstimateJobCostDetailReport.cs

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
    [IDOExtensionClass("SLEstimateJobCostDetailReport")]
    public class SLEstimateJobCostDetailReport : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_EstimateJobCostDetailSp([Optional] string ExOpordnumStarting,
            [Optional] string ExOpordnumENDing,
            [Optional] string ExOptgoOrdType,
            [Optional] int? ExOpsuffixStarting,
            [Optional] int? ExOpsuffixENDing,
            [Optional] string ExOptdfEjobStat,
            [Optional] string ExOptacCostComponent,
            [Optional] string ExOpjobStarting,
            [Optional] string ExOpjobENDing,
            [Optional] string ExOpItemStarting,
            [Optional] string ExOpItemENDing,
            [Optional] string ExOpCustStarting,
            [Optional] string ExOpCustENDing,
            [Optional] DateTime? ExOpJobDateStarting,
            [Optional] DateTime? ExOpJobDateENDing,
            [Optional] int? DateStartingOffset,
            [Optional] int? DateENDingOffset,
            [Optional] int? DisplayHeader,
            [Optional] string StartProspect,
            [Optional] string EndProspect,
            [Optional] string pSite)
        {
            var iRpt_EstimateJobCostDetailExt = new Rpt_EstimateJobCostDetailFactory().Create(this, true);

            var result = iRpt_EstimateJobCostDetailExt.Rpt_EstimateJobCostDetailSp(ExOpordnumStarting,
                ExOpordnumENDing,
                ExOptgoOrdType,
                ExOpsuffixStarting,
                ExOpsuffixENDing,
                ExOptdfEjobStat,
                ExOptacCostComponent,
                ExOpjobStarting,
                ExOpjobENDing,
                ExOpItemStarting,
                ExOpItemENDing,
                ExOpCustStarting,
                ExOpCustENDing,
                ExOpJobDateStarting,
                ExOpJobDateENDing,
                DateStartingOffset,
                DateENDingOffset,
                DisplayHeader,
                StartProspect,
                EndProspect,
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
