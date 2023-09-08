//PROJECT NAME: ReportExt
//CLASS NAME: SLTaxableRevenueReport.cs

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
    [IDOExtensionClass("SLTaxableRevenueReport")]
    public class SLTaxableRevenueReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TaxableRevenueSP([Optional] string TaxCodeStarting,
		[Optional] string TaxCodeEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] DateTime? InvoiceDateStarting,
		[Optional] DateTime? InvoiceDateEnding,
		[Optional] int? InvoiceDateStartingOffset,
		[Optional] int? InvoiceDateEndingOffset,
		[Optional] int? ShowDetail,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TaxableRevenueExt = new Rpt_TaxableRevenueFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TaxableRevenueExt.Rpt_TaxableRevenueSP(TaxCodeStarting,
				TaxCodeEnding,
				CustomerStarting,
				CustomerEnding,
				InvoiceDateStarting,
				InvoiceDateEnding,
				InvoiceDateStartingOffset,
				InvoiceDateEndingOffset,
				ShowDetail,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
