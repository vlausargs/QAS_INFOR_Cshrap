//PROJECT NAME: ReportExt
//CLASS NAME: SLCostToCompleteLogReport.cs

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
    [IDOExtensionClass("SLCostToCompleteLogReport")]
    public class SLCostToCompleteLogReport : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CostToCompleteLogSp([Optional] string ProjectStarting,
			[Optional] string ProjectEnding,
			[Optional] int? TaskStarting,
			[Optional] int? TaskEnding,
			[Optional] string CostCodeStarting,
			[Optional] string CostCodeEnding,
			[Optional] string ProjectStatus,
			[Optional] DateTime? Date,
			[Optional] int? DateOffset,
			[Optional, DefaultParameterValue(0)] int? Printcost,
			[Optional, DefaultParameterValue(1)] int? DisplayHeader,
			[Optional] string pSite)
		{
			var iRpt_CostToCompleteLogExt = new Rpt_CostToCompleteLogFactory().Create(this, true);
			
			var result = iRpt_CostToCompleteLogExt.Rpt_CostToCompleteLogSp(ProjectStarting,
				ProjectEnding,
				TaskStarting,
				TaskEnding,
				CostCodeStarting,
				CostCodeEnding,
				ProjectStatus,
				Date,
				DateOffset,
				Printcost,
				DisplayHeader,
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
