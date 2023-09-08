//PROJECT NAME: ReportExt
//CLASS NAME: SLReprintProjectInvoicesLaserReport.cs

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
	[IDOExtensionClass("SLReprintProjectInvoicesLaserReport")]
	public class SLReprintProjectInvoicesLaserReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ReprintProjectInvoiceSp([Optional] string InvoiceStarting,
		[Optional] string InvoiceEnding,
		[Optional] DateTime? InvoiceDateStarting,
		[Optional] DateTime? InvoiceDateEnding,
		[Optional] string ProjectStarting,
		[Optional] string ProjectEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? PrintEuroTotal,
		[Optional] int? TransDomCurr,
		[Optional] int? InvoiceDateStartingOffset,
		[Optional] int? InvoiceDateEndingOffset,
		[Optional] int? PrintMilestoneNotes,
		[Optional] int? PrintCustomerNotes,
		[Optional] int? PrintProjectNotes,
		[Optional] int? PrintStandardNotes,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] int? DisplayHeader,
		[Optional, DefaultParameterValue(0)] int? PrintDiscountAmt,
		[Optional] int? TaskId,
		[Optional] string pSite,
		[Optional, DefaultParameterValue(0)] int? CallFromReport)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ReprintProjectInvoiceExt = new Rpt_ReprintProjectInvoiceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ReprintProjectInvoiceExt.Rpt_ReprintProjectInvoiceSp(InvoiceStarting,
				InvoiceEnding,
				InvoiceDateStarting,
				InvoiceDateEnding,
				ProjectStarting,
				ProjectEnding,
				CustomerStarting,
				CustomerEnding,
				PrintEuroTotal,
				TransDomCurr,
				InvoiceDateStartingOffset,
				InvoiceDateEndingOffset,
				PrintMilestoneNotes,
				PrintCustomerNotes,
				PrintProjectNotes,
				PrintStandardNotes,
				ShowInternal,
				ShowExternal,
				DisplayHeader,
				PrintDiscountAmt,
				TaskId,
				pSite,
				CallFromReport);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
