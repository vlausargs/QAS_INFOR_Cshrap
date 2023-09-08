//PROJECT NAME: ReportExt
//CLASS NAME: SLResGpLoadProfileComparisonSchedReport.cs

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
	[IDOExtensionClass("SLResGpLoadProfileComparisonSchedReport")]
	public class SLResGpLoadProfileComparisonSchedReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ResourceGroupLoadProfileSchedulerComparisonSp(string RGIDStarting,
		string RGIDEnding,
		[Optional] DateTime? StartDate,
		[Optional, DefaultParameterValue(12)] int? IntervalCount,
		[Optional, DefaultParameterValue(3)] int? IntervalType,
		[Optional, DefaultParameterValue(0)] int? AltNum,
		[Optional, DefaultParameterValue(0)] int? AltNum2,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ResourceGroupLoadProfileSchedulerComparisonExt = new Rpt_ResourceGroupLoadProfileSchedulerComparisonFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ResourceGroupLoadProfileSchedulerComparisonExt.Rpt_ResourceGroupLoadProfileSchedulerComparisonSp(RGIDStarting,
				RGIDEnding,
				StartDate,
				IntervalCount,
				IntervalType,
				AltNum,
				AltNum2,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
