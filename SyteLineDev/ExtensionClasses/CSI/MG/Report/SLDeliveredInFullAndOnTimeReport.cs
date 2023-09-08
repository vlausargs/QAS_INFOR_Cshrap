//PROJECT NAME: ReportExt
//CLASS NAME: SLDeliveredInFullAndOnTimeReport.cs

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
    [IDOExtensionClass("SLDeliveredInFullAndOnTimeReport")]
    public class SLDeliveredInFullAndOnTimeReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_DeliveryInFullAndOnTimeSp([Optional] string PCustomerStarting,
		                                               [Optional] string PCustomerEnding,
		                                               [Optional] string POrderStarting,
		                                               [Optional] string POrderEnding,
		                                               [Optional] string PProductCodeStarting,
		                                               [Optional] string PProductCodeEnding,
		                                               [Optional] string PItemStarting,
		                                               [Optional] string PItemEnding,
		                                               [Optional] DateTime? PLastShipDateStarting,
		                                               [Optional] DateTime? PLastShipDateEnding,
		                                               [Optional] short? PLastShipDateStartingOffset,
		                                               [Optional] short? PLastShipDateEndingOffset,
		                                               [Optional] DateTime? PDueDateStarting,
		                                               [Optional] DateTime? PDueDateEnding,
		                                               [Optional] short? PDueDateStartingOffset,
		                                               [Optional] short? PDueDateEndingOffset,
		                                               [Optional] DateTime? POrderDateStarting,
		                                               [Optional] DateTime? POrderDateEnding,
		                                               [Optional] short? POrderDateStartingOffset,
		                                               [Optional] short? POrderDateEndingOffset,
		                                               [Optional] string PSummary,
		                                               [Optional] string PCOItemStatus,
		                                               [Optional] int? PSuccess,
		                                               [Optional] int? PFail,
		                                               [Optional] string PSiteGroup,
		                                               [Optional] byte? DisplayHeader,
		                                               [Optional] int? TaskId,
		                                               [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_DeliveryInFullAndOnTimeExt = new Rpt_DeliveryInFullAndOnTimeFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_DeliveryInFullAndOnTimeExt.Rpt_DeliveryInFullAndOnTimeSp(PCustomerStarting,
				                                                                           PCustomerEnding,
				                                                                           POrderStarting,
				                                                                           POrderEnding,
				                                                                           PProductCodeStarting,
				                                                                           PProductCodeEnding,
				                                                                           PItemStarting,
				                                                                           PItemEnding,
				                                                                           PLastShipDateStarting,
				                                                                           PLastShipDateEnding,
				                                                                           PLastShipDateStartingOffset,
				                                                                           PLastShipDateEndingOffset,
				                                                                           PDueDateStarting,
				                                                                           PDueDateEnding,
				                                                                           PDueDateStartingOffset,
				                                                                           PDueDateEndingOffset,
				                                                                           POrderDateStarting,
				                                                                           POrderDateEnding,
				                                                                           POrderDateStartingOffset,
				                                                                           POrderDateEndingOffset,
				                                                                           PSummary,
				                                                                           PCOItemStatus,
				                                                                           PSuccess,
				                                                                           PFail,
				                                                                           PSiteGroup,
				                                                                           DisplayHeader,
				                                                                           TaskId,
				                                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
