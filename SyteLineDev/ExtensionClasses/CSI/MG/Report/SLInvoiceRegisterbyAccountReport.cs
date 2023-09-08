//PROJECT NAME: ReportExt
//CLASS NAME: SLInvoiceRegisterbyAccountReport.cs

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
    [IDOExtensionClass("SLInvoiceRegisterbyAccountReport")]
    public class SLInvoiceRegisterbyAccountReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InvoiceRegisterbyAccountSp(string AccountStarting,
		string AccountEnding,
		string InvNumStarting,
		string InvNumEnding,
		DateTime? InvoiceDateStarting,
		DateTime? InvoiceDateEnding,
		string OrderStarting,
		string OrderEnding,
		string CustomerStarting,
		string CustomerEnding,
		string StateStarting,
		string StateEnding,
		string ItemStarting,
		string ItemEnding,
		string InvoiceSourceOrder,
		string InvoiceSourceAR,
		int? TranslateToDomesticCurrency,
		[Optional] int? InvoiceDateStartingOffset,
		[Optional] int? InvoiceDateEndingOffset,
		int? ShowPrice,
		int? DisplayHeader,
		[Optional] int? TaskId,
		int? SSSFSIncludeSourceSRO,
		int? SSSFSIncludeSourceContract,
		string SSSFSSROStarting,
		string SSSFSSROEnding,
		string SSSFSContractStarting,
		string SSSFSContractEnding,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_InvoiceRegisterbyAccountExt = new Rpt_InvoiceRegisterbyAccountFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_InvoiceRegisterbyAccountExt.Rpt_InvoiceRegisterbyAccountSp(AccountStarting,
				AccountEnding,
				InvNumStarting,
				InvNumEnding,
				InvoiceDateStarting,
				InvoiceDateEnding,
				OrderStarting,
				OrderEnding,
				CustomerStarting,
				CustomerEnding,
				StateStarting,
				StateEnding,
				ItemStarting,
				ItemEnding,
				InvoiceSourceOrder,
				InvoiceSourceAR,
				TranslateToDomesticCurrency,
				InvoiceDateStartingOffset,
				InvoiceDateEndingOffset,
				ShowPrice,
				DisplayHeader,
				TaskId,
				SSSFSIncludeSourceSRO,
				SSSFSIncludeSourceContract,
				SSSFSSROStarting,
				SSSFSSROEnding,
				SSSFSContractStarting,
				SSSFSContractEnding,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
