//PROJECT NAME: ReportExt
//CLASS NAME: SLEmployeeLogHoursReport.cs

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
	[IDOExtensionClass("SLEmployeeLogHoursReport")]
	public class SLEmployeeLogHoursReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmployeeLogHoursSp([Optional] string PStartingEmployee,
		[Optional] string PEndingEmployee,
		[Optional] DateTime? PStartingDate,
		[Optional] DateTime? PEndingDate,
		[Optional] decimal? PStartingTrans,
		[Optional] decimal? PEndingTrans,
		[Optional] string PCheckType,
		[Optional] string PPayType,
		[Optional] string PEmployeeType,
		[Optional] int? PStartingDateOffset,
		[Optional] int? PEndingDateOffset,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string PStartEmpCate,
		[Optional] string PEndEmpCate,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_EmployeeLogHoursExt = new Rpt_EmployeeLogHoursFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_EmployeeLogHoursExt.Rpt_EmployeeLogHoursSp(PStartingEmployee,
				PEndingEmployee,
				PStartingDate,
				PEndingDate,
				PStartingTrans,
				PEndingTrans,
				PCheckType,
				PPayType,
				PEmployeeType,
				PStartingDateOffset,
				PEndingDateOffset,
				PrintCost,
				PDisplayHeader,
				PStartEmpCate,
				PEndEmpCate,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
