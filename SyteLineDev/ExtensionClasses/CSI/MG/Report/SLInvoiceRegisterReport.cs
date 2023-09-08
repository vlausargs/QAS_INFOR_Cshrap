//PROJECT NAME: ReportExt
//CLASS NAME: SLInvoiceRegisterReport.cs

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
    [IDOExtensionClass("SLInvoiceRegisterReport")]
    public class SLInvoiceRegisterReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InvoiceRegisterSp([Optional] string InvNumStarting,
		                                       [Optional] string InvNumEnding,
		                                       [Optional] DateTime? InvoiceDateStarting,
		                                       [Optional] DateTime? InvoiceDateEnding,
		                                       [Optional] string OrderStarting,
		                                       [Optional] string OrderEnding,
		                                       [Optional] string CustomerStarting,
		                                       [Optional] string CustomerEnding,
		                                       [Optional] string StateStarting,
		                                       [Optional] string StateEnding,
		                                       [Optional] byte? InvoiceSourceOrder,
		                                       [Optional] byte? InvoiceSourceAR,
		                                       [Optional] byte? ShowDetail,
		                                       [Optional] byte? PrintTaxCodeSummary,
		                                       [Optional] byte? TranslateToDomesticCurrency,
		                                       [Optional] short? InvoiceDateStartingOffset,
		                                       [Optional] short? InvoiceDateEndingOffset,
		                                       [Optional] byte? ShowCost,
		                                       [Optional] byte? ShowPrice,
		                                       [Optional] byte? DisplayHeader,
		                                       [Optional] byte? SSSFSInclSRO,
		                                       [Optional] byte? SSSFSInclContract,
		                                       [Optional] int? TaskId,
		                                       [Optional] string BGSessionId,
		                                       [Optional] string pSite,
		                                       [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InvoiceRegisterExt = new Rpt_InvoiceRegisterFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InvoiceRegisterExt.Rpt_InvoiceRegisterSp(InvNumStarting,
				                                                           InvNumEnding,
				                                                           InvoiceDateStarting,
				                                                           InvoiceDateEnding,
				                                                           OrderStarting,
				                                                           OrderEnding,
				                                                           CustomerStarting,
				                                                           CustomerEnding,
				                                                           StateStarting,
				                                                           StateEnding,
				                                                           InvoiceSourceOrder,
				                                                           InvoiceSourceAR,
				                                                           ShowDetail,
				                                                           PrintTaxCodeSummary,
				                                                           TranslateToDomesticCurrency,
				                                                           InvoiceDateStartingOffset,
				                                                           InvoiceDateEndingOffset,
				                                                           ShowCost,
				                                                           ShowPrice,
				                                                           DisplayHeader,
				                                                           SSSFSInclSRO,
				                                                           SSSFSInclContract,
				                                                           TaskId,
				                                                           BGSessionId,
				                                                           pSite,
				                                                           BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
