//PROJECT NAME: ReportExt
//CLASS NAME: SLCustomerOrderReports.cs

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
    [IDOExtensionClass("SLCustomerOrderReports")]
    public class SLCustomerOrderReports : ExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_OrderStatusSp([Optional] string ExOptBegCust_num,
		[Optional] string ExOptEndCust_num,
		[Optional] string ExOptacCoType,
		[Optional] string ExOptacCoStat,
		[Optional] string ExOptacCoitemStat,
		[Optional] int? ExOptszTransDomCur,
		[Optional] string ExOptCredit_Hold,
		[Optional] int? ExOptgoInclDo,
		[Optional] string ExOptszSite_Group,
		[Optional] string ExOptBegCo_num,
		[Optional] string ExOptEndCo_num,
		[Optional] DateTime? ExOptBegOrder_date,
		[Optional] DateTime? ExOptEndOrder_date,
		[Optional] string ExOptBegCust_Po,
		[Optional] string ExOptEndCust_Po,
		[Optional] string ExOptBegItem,
		[Optional] string ExOptEndItem,
		[Optional] string ExOptBegCust_Item,
		[Optional] string ExOptEndCust_Item,
		[Optional] DateTime? ExOptBegDue_date,
		[Optional] DateTime? ExOptEndDue_date,
		[Optional] DateTime? ExOptBegShip_date,
		[Optional] DateTime? ExOptEndShip_date,
		[Optional] string StartWhse,
		[Optional] string EndWhse,
		[Optional] int? StartOrder_dateOffset,
		[Optional] int? EndOrder_dateOffset,
		[Optional] int? StartDue_dateOffset,
		[Optional] int? EndDue_dateOffset,
		[Optional] int? StartShip_dateOffset,
		[Optional] int? EndShip_dateOffset,
		[Optional] string SortBy,
		[Optional] int? DisplayHeader,
		[Optional, DefaultParameterValue(0)] int? PrintPrice,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional] int? PrintInternalNotes,
		[Optional] int? PrintExternalNotes,
		[Optional] int? TaskId,
		[Optional] int? BackOrderOnly,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_OrderStatusExt = new Rpt_OrderStatusFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_OrderStatusExt.Rpt_OrderStatusSp(ExOptBegCust_num,
				ExOptEndCust_num,
				ExOptacCoType,
				ExOptacCoStat,
				ExOptacCoitemStat,
				ExOptszTransDomCur,
				ExOptCredit_Hold,
				ExOptgoInclDo,
				ExOptszSite_Group,
				ExOptBegCo_num,
				ExOptEndCo_num,
				ExOptBegOrder_date,
				ExOptEndOrder_date,
				ExOptBegCust_Po,
				ExOptEndCust_Po,
				ExOptBegItem,
				ExOptEndItem,
				ExOptBegCust_Item,
				ExOptEndCust_Item,
				ExOptBegDue_date,
				ExOptEndDue_date,
				ExOptBegShip_date,
				ExOptEndShip_date,
				StartWhse,
				EndWhse,
				StartOrder_dateOffset,
				EndOrder_dateOffset,
				StartDue_dateOffset,
				EndDue_dateOffset,
				StartShip_dateOffset,
				EndShip_dateOffset,
				SortBy,
				DisplayHeader,
				PrintPrice,
				PrintCost,
				PrintInternalNotes,
				PrintExternalNotes,
				TaskId,
				BackOrderOnly,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
