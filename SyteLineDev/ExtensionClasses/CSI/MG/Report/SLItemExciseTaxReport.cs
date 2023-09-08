//PROJECT NAME: ReportExt
//CLASS NAME: SLItemExciseTaxReport.cs

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
    [IDOExtensionClass("SLItemExciseTaxReport")]
    public class SLItemExciseTaxReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemExciseTaxSp([Optional] string pStartItem,
		                                     [Optional] string pEndItem,
		                                     [Optional] DateTime? pStartInvDate,
		                                     [Optional] DateTime? pEndInvDate,
		                                     [Optional] string pStartCustNum,
		                                     [Optional] string pEndCustNum,
		                                     [Optional, DefaultParameterValue((byte)1)] byte? pDisplayHeader,
		[Optional] short? pStartInvDateOffset,
		[Optional] short? pEndInvDateOffset,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemExciseTaxExt = new Rpt_ItemExciseTaxFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemExciseTaxExt.Rpt_ItemExciseTaxSp(pStartItem,
				                                                       pEndItem,
				                                                       pStartInvDate,
				                                                       pEndInvDate,
				                                                       pStartCustNum,
				                                                       pEndCustNum,
				                                                       pDisplayHeader,
				                                                       pStartInvDateOffset,
				                                                       pEndInvDateOffset,
				                                                       BGSessionId,
				                                                       pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
