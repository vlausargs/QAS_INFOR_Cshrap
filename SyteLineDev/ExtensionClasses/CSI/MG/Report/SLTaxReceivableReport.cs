//PROJECT NAME: ReportExt
//CLASS NAME: SLTaxReceivableReport.cs

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
	[IDOExtensionClass("SLTaxReceivableReport")]
	public class SLTaxReceivableReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TaxReceivableSp([Optional] string StartingTaxCode,
		[Optional] string EndingTaxCode,
		[Optional] DateTime? StartingInvoiceDate,
		[Optional] DateTime? EndingInvoiceDate,
		[Optional] int? StartingInvoiceDateOffset,
		[Optional] int? EndingInvoiceDateOffset,
		[Optional] string StartingCust,
		[Optional] string EndingCust,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TaxReceivableExt = new Rpt_TaxReceivableFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TaxReceivableExt.Rpt_TaxReceivableSp(StartingTaxCode,
				EndingTaxCode,
				StartingInvoiceDate,
				EndingInvoiceDate,
				StartingInvoiceDateOffset,
				EndingInvoiceDateOffset,
				StartingCust,
				EndingCust,
				DisplayHeader,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
