//PROJECT NAME: ReportExt
//CLASS NAME: SLResourceGroupLoadProfileComparisonAPSReport.cs

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
	[IDOExtensionClass("SLResourceGroupLoadProfileComparisonAPSReport")]
	public class SLResourceGroupLoadProfileComparisonAPSReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ResourceGroupLoadProfileComparisonAPSSp(string RGIDStarting,
		string RGIDEnding,
		[Optional] DateTime? StartDate,
		[Optional, DefaultParameterValue(12)] int? IntervalCount,
		[Optional, DefaultParameterValue(3)] int? IntervalType,
		[Optional, DefaultParameterValue(0)] int? AltNum,
		[Optional, DefaultParameterValue(0)] int? AltNum2,
		[Optional] int? GroupAllocOnly,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ResourceGroupLoadProfileComparisonAPSExt = new Rpt_ResourceGroupLoadProfileComparisonAPSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ResourceGroupLoadProfileComparisonAPSExt.Rpt_ResourceGroupLoadProfileComparisonAPSSp(RGIDStarting,
				RGIDEnding,
				StartDate,
				IntervalCount,
				IntervalType,
				AltNum,
				AltNum2,
				GroupAllocOnly,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
