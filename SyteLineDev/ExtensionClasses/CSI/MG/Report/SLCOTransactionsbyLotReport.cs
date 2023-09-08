//PROJECT NAME: ReportExt
//CLASS NAME: SLCOTransactionsbyLotReport.cs

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
    [IDOExtensionClass("SLCOTransactionsbyLotReport")]
    public class SLCOTransactionsbyLotReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_COTransactionsByLotSp([Optional] string ItemStarting,
		                                           [Optional] string ItemEnding,
		                                           [Optional] string LotStarting,
		                                           [Optional] string LotEnding,
		                                           [Optional] byte? ExOptszSortItemLot,
		                                           [Optional] byte? DisplayHeader,
		                                           [Optional] string BGSessionId,
		                                           [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_COTransactionsByLotExt = new Rpt_COTransactionsByLotFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_COTransactionsByLotExt.Rpt_COTransactionsByLotSp(ItemStarting,
				                                                                   ItemEnding,
				                                                                   LotStarting,
				                                                                   LotEnding,
				                                                                   ExOptszSortItemLot,
				                                                                   DisplayHeader,
				                                                                   BGSessionId,
				                                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
