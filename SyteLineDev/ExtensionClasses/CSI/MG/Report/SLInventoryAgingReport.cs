//PROJECT NAME: ReportExt
//CLASS NAME: SLInventoryAgingReport.cs

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
    [IDOExtensionClass("SLInventoryAgingReport")]
    public class SLInventoryAgingReport : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InventoryAgingSp([Optional] string ItemStarting,
			[Optional] string ItemEnding,
			[Optional] string ProductCodeStarting,
			[Optional] string ProductCodeEnding,
			[Optional] string WhseStarting,
			[Optional] string WhseEnding,
			[Optional] string LocStarting,
			[Optional] string LocEnding,
			[Optional] string AgingBasis,
			[Optional] int? DisplayHeader,
			[Optional] int? AgeDays1,
			[Optional] int? AgeDays2,
			[Optional] int? AgeDays3,
			[Optional] int? AgeDays4,
			[Optional] int? AgeDays5,
			[Optional] string AgeDesc1,
			[Optional] string AgeDesc2,
			[Optional] string AgeDesc3,
			[Optional] string AgeDesc4,
			[Optional] string AgeDesc5,
			[Optional] string pSite,
			[Optional] string DocumentNumStarting,
			[Optional] string DocumentNumEnding)
		{
			var iRpt_InventoryAgingExt = new Rpt_InventoryAgingFactory().Create(this, true);

			var result = iRpt_InventoryAgingExt.Rpt_InventoryAgingSp(ItemStarting,
				ItemEnding,
				ProductCodeStarting,
				ProductCodeEnding,
				WhseStarting,
				WhseEnding,
				LocStarting,
				LocEnding,
				AgingBasis,
				DisplayHeader,
				AgeDays1,
				AgeDays2,
				AgeDays3,
				AgeDays4,
				AgeDays5,
				AgeDesc1,
				AgeDesc2,
				AgeDesc3,
				AgeDesc4,
				AgeDesc5,
				pSite,
				DocumentNumStarting,
				DocumentNumEnding);

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
