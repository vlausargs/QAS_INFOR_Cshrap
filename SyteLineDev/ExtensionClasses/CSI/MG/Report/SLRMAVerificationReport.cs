//PROJECT NAME: ReportExt
//CLASS NAME: SLRMAVerificationReport.cs

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
    [IDOExtensionClass("SLRMAVerificationReport")]
    public class SLRMAVerificationReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RMAVerificationSp([Optional] string PStartingRMA,
		[Optional] string PEndingRMA,
		[Optional, DefaultParameterValue("OS")] string PStatus,
		[Optional] string PStartingCustomer,
		[Optional] string PEndingCustomer,
		[Optional] string PStartingWhse,
		[Optional] string PEndingWhse,
		[Optional] DateTime? PStartingRMADate,
		[Optional] DateTime? PEndingRMADate,
		[Optional] int? PStartingRMALine,
		[Optional] int? PEndingRMALine,
		[Optional, DefaultParameterValue(1)] int? ShowInternal,
		[Optional, DefaultParameterValue(1)] int? ShowExternal,
		[Optional, DefaultParameterValue(0)] int? PrintItemOverview,
		[Optional, DefaultParameterValue(1)] int? PrintRMATable,
		[Optional, DefaultParameterValue(1)] int? PrintRMAItemTable,
		[Optional, DefaultParameterValue(0)] int? PrintReasonText,
		[Optional] int? PStartingRMADateOffset,
		[Optional] int? PEndingRMADateOffset,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RMAVerificationExt = new Rpt_RMAVerificationFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RMAVerificationExt.Rpt_RMAVerificationSp(PStartingRMA,
				PEndingRMA,
				PStatus,
				PStartingCustomer,
				PEndingCustomer,
				PStartingWhse,
				PEndingWhse,
				PStartingRMADate,
				PEndingRMADate,
				PStartingRMALine,
				PEndingRMALine,
				ShowInternal,
				ShowExternal,
				PrintItemOverview,
				PrintRMATable,
				PrintRMAItemTable,
				PrintReasonText,
				PStartingRMADateOffset,
				PEndingRMADateOffset,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
