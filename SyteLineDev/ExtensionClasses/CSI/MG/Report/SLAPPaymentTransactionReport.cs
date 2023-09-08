//PROJECT NAME: ReportExt
//CLASS NAME: SLAPPaymentTransactionReport.cs

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
    [IDOExtensionClass("SLAPPaymentTransactionReport")]
    public class SLAPPaymentTransactionReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_APPaymentTransactionSp([Optional] string PaymentType,
		                                            [Optional] string BankCode,
		                                            [Optional] byte? DisplayDistDetail,
		                                            [Optional] string VendorStarting,
		                                            [Optional] string VendorEnding,
		                                            [Optional] byte? DisplayHeader,
		                                            [Optional] DateTime? PayDateStarting,
		                                            [Optional] DateTime? PayDateEnding,
		                                            [Optional] short? PayDateStartingOffset,
		                                            [Optional] short? PayDateEndingOffset,
		                                            [Optional] string BGSessionId,
		                                            [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_APPaymentTransactionExt = new Rpt_APPaymentTransactionFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_APPaymentTransactionExt.Rpt_APPaymentTransactionSp(PaymentType,
				                                                                     BankCode,
				                                                                     DisplayDistDetail,
				                                                                     VendorStarting,
				                                                                     VendorEnding,
				                                                                     DisplayHeader,
				                                                                     PayDateStarting,
				                                                                     PayDateEnding,
				                                                                     PayDateStartingOffset,
				                                                                     PayDateEndingOffset,
				                                                                     BGSessionId,
				                                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
