//PROJECT NAME: ReportExt
//CLASS NAME: SLInvoiceRevisionDayReport.cs

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
	[IDOExtensionClass("SLInvoiceRevisionDayReport")]
	public class SLInvoiceRevisionDayReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InvoiceRevisionDaySp([Optional] string PStartInvoice,
		[Optional] string PEndInvoice,
		[Optional] DateTime? PStartInvDate,
		[Optional] DateTime? PEndInvDate,
		[Optional] string PStartCustomer,
		[Optional] string PEndCustomer,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_InvoiceRevisionDayExt = new Rpt_InvoiceRevisionDayFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_InvoiceRevisionDayExt.Rpt_InvoiceRevisionDaySp(PStartInvoice,
				PEndInvoice,
				PStartInvDate,
				PEndInvDate,
				PStartCustomer,
				PEndCustomer,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
