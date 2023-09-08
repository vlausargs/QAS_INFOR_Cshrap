//PROJECT NAME: ReportExt
//CLASS NAME: SLTHAPaymentTransactionReprintReport.cs

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
	[IDOExtensionClass("SLTHAPaymentTransactionReprintReport")]
	public class SLTHAPaymentTransactionReprintReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable THARpt_PCPaymentTransactionReprintSp(string PSessionID,
		string FormID,
		string PPayCode,
		string PSBankCode,
		string PEBankCode,
		string PSortNameNum,
		[Optional] int? DisplayHeader,
		[Optional] int? PDistDetail,
		[Optional] string PStartingVendNum,
		[Optional] string PEndingVendNum,
		[Optional] string PStartingVendName,
		[Optional] string PEndingVendName,
		[Optional] DateTime? PPayDateStarting,
		[Optional] DateTime? PPayDateEnding,
		int? SCheckNumber,
		int? ECheckNumber,
		[Optional] int? PSPayDateOffset,
		[Optional] int? PEPayDateOffset,
		[Optional] int? internalNotes,
		[Optional] int? ExternalNotes,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTHARpt_PCPaymentTransactionReprintExt = new THARpt_PCPaymentTransactionReprintFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTHARpt_PCPaymentTransactionReprintExt.THARpt_PCPaymentTransactionReprintSp(PSessionID,
				FormID,
				PPayCode,
				PSBankCode,
				PEBankCode,
				PSortNameNum,
				DisplayHeader,
				PDistDetail,
				PStartingVendNum,
				PEndingVendNum,
				PStartingVendName,
				PEndingVendName,
				PPayDateStarting,
				PPayDateEnding,
				SCheckNumber,
				ECheckNumber,
				PSPayDateOffset,
				PEPayDateOffset,
				internalNotes,
				ExternalNotes,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
