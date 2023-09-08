//PROJECT NAME: ReportExt
//CLASS NAME: SLSalesTaxReport.cs

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
    [IDOExtensionClass("SLSalesTaxReport")]
    public class SLSalesTaxReport : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SalesTaxSp([Optional] int? TranslateToDomesticCurrency,
		[Optional] string InvoiceStarting,
		[Optional] string InvoiceEnding,
		[Optional] DateTime? InvoiceDateStarting,
		[Optional] DateTime? InvoiceDateEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? InvoiceDateStartingOffset,
		[Optional] int? InvoiceDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SalesTaxExt = new Rpt_SalesTaxFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SalesTaxExt.Rpt_SalesTaxSp(TranslateToDomesticCurrency,
				InvoiceStarting,
				InvoiceEnding,
				InvoiceDateStarting,
				InvoiceDateEnding,
				CustomerStarting,
				CustomerEnding,
				InvoiceDateStartingOffset,
				InvoiceDateEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable THARpt_SalesTaxSp([Optional] int? TranslateToDomesticCurrency,
		[Optional] string InvoiceStarting,
		[Optional] string InvoiceEnding,
		[Optional] DateTime? InvoiceDateStarting,
		[Optional] DateTime? InvoiceDateEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? InvoiceDateStartingOffset,
		[Optional] int? InvoiceDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite,
		[Optional, DefaultParameterValue(0)] int? UnPostedVAT,
		[Optional, DefaultParameterValue(1)] int? PostedVAT,
		[Optional] string BranchId)
		{
			var iTHARpt_SalesTaxExt = new THARpt_SalesTaxFactory().Create(this, true);
			
			var result = iTHARpt_SalesTaxExt.THARpt_SalesTaxSp(TranslateToDomesticCurrency,
			InvoiceStarting,
			InvoiceEnding,
			InvoiceDateStarting,
			InvoiceDateEnding,
			CustomerStarting,
			CustomerEnding,
			InvoiceDateStartingOffset,
			InvoiceDateEndingOffset,
			DisplayHeader,
			pSite,
			UnPostedVAT,
			PostedVAT,
			BranchId);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
    }
}
