//PROJECT NAME: ReportExt
//CLASS NAME: SLAPBalanceReport.cs

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
	[IDOExtensionClass("SLAPBalanceReport")]
	public class SLAPBalanceReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_APBalanceReportSp(string FromVendNum,
		string ToVendNum,
		int? FromPeriod,
		int? ToPeriod,
		int? FromYear,
		int? ToYear,
		[Optional] int? DisplayHeader,
		ref string Infobar,
		[Optional] string pSite,
        string ProcessId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_APBalanceReportExt = new Rpt_APBalanceReportFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_APBalanceReportExt.Rpt_APBalanceReportSp(FromVendNum,
				ToVendNum,
				FromPeriod,
				ToPeriod,
				FromYear,
				ToYear,
				DisplayHeader,
				Infobar,
				pSite,
                ProcessId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
	}
}
