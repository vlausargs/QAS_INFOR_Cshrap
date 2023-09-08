//PROJECT NAME: ReportExt
//CLASS NAME: SLCustomerOrdersforReservableItemsReport.cs

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
    [IDOExtensionClass("SLCustomerOrdersforReservableItemsReport")]
    public class SLCustomerOrdersforReservableItemsReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CustomerOrdersforReservableItemsSp([Optional] string WhseStarting,
		                                                        [Optional] string WhseEnding,
		                                                        [Optional] string ItemStarting,
		                                                        [Optional] string ItemEnding,
		                                                        [Optional] byte? SortByDueDate,
		                                                        [Optional] string DisplayOrder,
		                                                        [Optional] DateTime? DueDateStarting,
		                                                        [Optional] DateTime? DueDateEnding,
		                                                        [Optional] short? DueDateStartingOffset,
		                                                        [Optional] short? DueDateEndingOffset,
		                                                        [Optional] string OrderStarting,
		                                                        [Optional] string OrderEnding,
		                                                        [Optional] string CustStarting,
		                                                        [Optional] string CustEnding,
		                                                        [Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CustomerOrdersforReservableItemsExt = new Rpt_CustomerOrdersforReservableItemsFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CustomerOrdersforReservableItemsExt.Rpt_CustomerOrdersforReservableItemsSp(WhseStarting,
				                                                                                             WhseEnding,
				                                                                                             ItemStarting,
				                                                                                             ItemEnding,
				                                                                                             SortByDueDate,
				                                                                                             DisplayOrder,
				                                                                                             DueDateStarting,
				                                                                                             DueDateEnding,
				                                                                                             DueDateStartingOffset,
				                                                                                             DueDateEndingOffset,
				                                                                                             OrderStarting,
				                                                                                             OrderEnding,
				                                                                                             CustStarting,
				                                                                                             CustEnding,
				                                                                                             DisplayHeader,
				                                                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
