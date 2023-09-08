//PROJECT NAME: ReportExt
//CLASS NAME: SLAvailableToShipReport.cs

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
    [IDOExtensionClass("SLAvailableToShipReport")]
    public class SLAvailableToShipReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_AvailableToShipSp([Optional] string pCoType,
		                                       [Optional] string pCoStat,
		                                       [Optional] int? pBatchID,
		                                       [Optional] byte? pOverwriteBatch,
		                                       [Optional] string pCoitemStat,
		                                       [Optional] string pSortBy,
		                                       [Optional] string pStartCoNum,
		                                       [Optional] string pEndCoNum,
		                                       [Optional] string pStartCustNum,
		                                       [Optional] string pEndCustNum,
		                                       [Optional] string pStartItem,
		                                       [Optional] string pEndItem,
		                                       [Optional] string pStartWhse,
		                                       [Optional] string pEndWhse,
		                                       [Optional, DefaultParameterValue((byte)0)] byte? PrintPrice,
		[Optional] byte? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] byte? IncludeShipEarly,
		[Optional] DateTime? CutoffDate,
		[Optional] string pSite,
		[Optional] string BGUser,
		[Optional] byte? IncludeShipHold)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_AvailableToShipExt = new Rpt_AvailableToShipFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_AvailableToShipExt.Rpt_AvailableToShipSp(pCoType,
				                                                           pCoStat,
				                                                           pBatchID,
				                                                           pOverwriteBatch,
				                                                           pCoitemStat,
				                                                           pSortBy,
				                                                           pStartCoNum,
				                                                           pEndCoNum,
				                                                           pStartCustNum,
				                                                           pEndCustNum,
				                                                           pStartItem,
				                                                           pEndItem,
				                                                           pStartWhse,
				                                                           pEndWhse,
				                                                           PrintPrice,
				                                                           DisplayHeader,
				                                                           BGSessionId,
				                                                           TaskId,
				                                                           IncludeShipEarly,
				                                                           CutoffDate,
				                                                           pSite,
				                                                           BGUser,
				                                                           IncludeShipHold);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
