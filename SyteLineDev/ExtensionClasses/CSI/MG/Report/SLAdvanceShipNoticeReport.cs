//PROJECT NAME: ReportExt
//CLASS NAME: SLAdvanceShipNoticeReport.cs

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
    [IDOExtensionClass("SLAdvanceShipNoticeReport")]
    public class SLAdvanceShipNoticeReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_AdvanceShipNoticeSp([Optional] string StartCustNum,
		                                         [Optional] string EndCustNum,
		                                         [Optional] int? StartCustSeq,
		                                         [Optional] int? EndCustSeq,
		                                         [Optional] string StartDoNum,
		                                         [Optional] string EndDoNum,
		                                         [Optional] decimal? StartShipmentID,
		                                         [Optional] decimal? EndShipmentID,
		                                         [Optional] byte? DisplayHeader,
		                                         [Optional] string PrintType,
		                                         [Optional] byte? PrintSwitchFlag,
		                                         [Optional] int? TaskId,
		                                         [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_AdvanceShipNoticeExt = new Rpt_AdvanceShipNoticeFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_AdvanceShipNoticeExt.Rpt_AdvanceShipNoticeSp(StartCustNum,
				                                                               EndCustNum,
				                                                               StartCustSeq,
				                                                               EndCustSeq,
				                                                               StartDoNum,
				                                                               EndDoNum,
				                                                               StartShipmentID,
				                                                               EndShipmentID,
				                                                               DisplayHeader,
				                                                               PrintType,
				                                                               PrintSwitchFlag,
				                                                               TaskId,
				                                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
