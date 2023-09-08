//PROJECT NAME: MG
//CLASS NAME: SLPurchaseVATRegister012GTGT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLPurchaseVATRegister012GTGT")]
	public class SLPurchaseVATRegister012GTGT : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PurchaseVATRegister012GTGTSp([Optional] string TaxCodeStarting,
		[Optional] string TaxCodeEnding,
		[Optional] DateTime? TaxPeriodDateStarting,
		[Optional] DateTime? TaxPeriodDateEnding,
		[Optional] string InvoiceStarting,
		[Optional] string InvoiceEnding,
		[Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] int? TaxPeriodDateStartingOffset,
		[Optional] int? TaxPeriodDateEndingOffset,
		[Optional] string AccountPrefix,
		[Optional] string pSite)
		{
			var iRpt_PurchaseVATRegister012GTGTExt = new Rpt_PurchaseVATRegister012GTGTFactory().Create(this, true);
			
			var result = iRpt_PurchaseVATRegister012GTGTExt.Rpt_PurchaseVATRegister012GTGTSp(TaxCodeStarting,
			TaxCodeEnding,
			TaxPeriodDateStarting,
			TaxPeriodDateEnding,
			InvoiceStarting,
			InvoiceEnding,
			VendorStarting,
			VendorEnding,
			TaxPeriodDateStartingOffset,
			TaxPeriodDateEndingOffset,
			AccountPrefix,
			pSite);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
	}
}
