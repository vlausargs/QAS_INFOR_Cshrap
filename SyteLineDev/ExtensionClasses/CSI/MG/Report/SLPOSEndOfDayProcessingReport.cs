//PROJECT NAME: ReportExt
//CLASS NAME: SLPOSEndOfDayProcessingReport.cs

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
	[IDOExtensionClass("SLPOSEndOfDayProcessingReport")]
	public class SLPOSEndOfDayProcessingReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSPOSRpt_EndOfDayProcessingSp([Optional] string CashDrawer,
		[Optional] DateTime? AdjustmentPostingDate,
		[Optional, DefaultParameterValue(0)] decimal? EndingCashBalance,
		[Optional, DefaultParameterValue(0)] decimal? EndingCheckBalance,
		int? CheckInBalance,
		int? CheckInNotBalance,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSPOSRpt_EndOfDayProcessingExt = new SSSPOSRpt_EndOfDayProcessingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSPOSRpt_EndOfDayProcessingExt.SSSPOSRpt_EndOfDayProcessingSp(CashDrawer,
				AdjustmentPostingDate,
				EndingCashBalance,
				EndingCheckBalance,
				CheckInBalance,
				CheckInNotBalance,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
