//PROJECT NAME: ReportExt
//CLASS NAME: SLInventoryCostReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLInventoryCostReport")]
    public class SLInventoryCostReport : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InventoryCostSp([Optional] string ExbegWhse,
			[Optional] string ExendWhse,
			[Optional] string ExbegLoc,
			[Optional] string ExendLoc,
			[Optional] string ExbegProductcode,
			[Optional] string ExendProductcode,
			[Optional] string ExbegItem,
			[Optional] string ExendItem,
			[Optional, DefaultParameterValue("AOS")] string ExOptgoItemStat,
			[Optional, DefaultParameterValue("MTFO")] string ExOptgoMatlType,
			[Optional, DefaultParameterValue("PMT")] string ExOptprPMTCode,
			[Optional, DefaultParameterValue("B")] string ExOptszStocked,
			[Optional, DefaultParameterValue("ABC")] string ExOptacAbcCode,
			[Optional, DefaultParameterValue(0)] int? ExOptprPrZeroQty,
			[Optional, DefaultParameterValue(0)] int? ShowDetail,
			[Optional, DefaultParameterValue(0)] int? PrintCost,
			[Optional] int? DisplayHeader,
			[Optional] string PMessageLanguage,
			[Optional] string pSite,
			[Optional] Guid? ProcessId)
		{
			var iRpt_InventoryCostExt = this.GetService<IRpt_InventoryCost>();
			
			var result = iRpt_InventoryCostExt.Rpt_InventoryCostSp(ExbegWhse,
				ExendWhse,
				ExbegLoc,
				ExendLoc,
				ExbegProductcode,
				ExendProductcode,
				ExbegItem,
				ExendItem,
				ExOptgoItemStat,
				ExOptgoMatlType,
				ExOptprPMTCode,
				ExOptszStocked,
				ExOptacAbcCode,
				ExOptprPrZeroQty,
				ShowDetail,
				PrintCost,
				DisplayHeader,
				PMessageLanguage,
				pSite,
				ProcessId);
			
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
