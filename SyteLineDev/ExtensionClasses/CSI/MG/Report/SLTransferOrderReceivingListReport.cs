//PROJECT NAME: ReportExt
//CLASS NAME: SLTransferOrderReceivingListReport.cs

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
    [IDOExtensionClass("SLTransferOrderReceivingListReport")]
    public class SLTransferOrderReceivingListReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TransferOrderReceivingListSp([Optional] string ExOptprRecvTrans,
		[Optional] int? ExOptprPostRcpts,
		[Optional] DateTime? ExOptprPostDate,
		[Optional] int? ExOptprPrintBc,
		[Optional] int? ExOptprPrSerialNumbers,
		[Optional] int? DateStarting,
		[Optional] int? DisplayHeader,
		[Optional] decimal? UserId,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TransferOrderReceivingListExt = new Rpt_TransferOrderReceivingListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TransferOrderReceivingListExt.Rpt_TransferOrderReceivingListSp(ExOptprRecvTrans,
				ExOptprPostRcpts,
				ExOptprPostDate,
				ExOptprPrintBc,
				ExOptprPrSerialNumbers,
				DateStarting,
				DisplayHeader,
				UserId,
				BGSessionId,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
