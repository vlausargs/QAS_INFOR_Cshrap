//PROJECT NAME: ReportExt
//CLASS NAME: SLTransactionsbySerialNumberReport.cs

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
    [IDOExtensionClass("SLTransactionsbySerialNumberReport")]
    public class SLTransactionsbySerialNumberReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TransactionsbySerialNumberSp([Optional] string BegSerNum,
		[Optional] string EndSerNum,
		[Optional] string BegItem,
		[Optional] string EndItem,
		[Optional] string BegLot,
		[Optional] string EndLot,
		[Optional] int? DisplayHeader,
		[Optional] string MessageLanguage,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TransactionsbySerialNumberExt = new Rpt_TransactionsbySerialNumberFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TransactionsbySerialNumberExt.Rpt_TransactionsbySerialNumberSp(BegSerNum,
				EndSerNum,
				BegItem,
				EndItem,
				BegLot,
				EndLot,
				DisplayHeader,
				MessageLanguage,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
