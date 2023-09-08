//PROJECT NAME: ReportExt
//CLASS NAME: SLW2FormsSingleWideReport.cs

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
	[IDOExtensionClass("SLW2FormsSingleWideReport")]
	public class SLW2FormsSingleWideReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PrintW2FormsSp(DateTime? YearStartDate,
		DateTime? YearEndDate,
		[Optional, DefaultParameterValue(0)] int? W3Information,
		[Optional, DefaultParameterValue(0)] int? ConsolidateState,
		[Optional] string EmpNumStarting,
		[Optional] string EmpNumEnding,
		[Optional] int? EmpTypeHourlyPerm,
		[Optional] int? EmpTypeSalaryPerm,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PrintW2FormsExt = new Rpt_PrintW2FormsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PrintW2FormsExt.Rpt_PrintW2FormsSp(YearStartDate,
				YearEndDate,
				W3Information,
				ConsolidateState,
				EmpNumStarting,
				EmpNumEnding,
				EmpTypeHourlyPerm,
				EmpTypeSalaryPerm,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
