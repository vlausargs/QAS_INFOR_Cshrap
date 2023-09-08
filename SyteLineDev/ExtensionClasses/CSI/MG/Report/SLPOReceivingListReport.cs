//PROJECT NAME: ReportExt
//CLASS NAME: SLPOReceivingListReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLPOReceivingListReport")]
	public class SLPOReceivingListReport : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable POReceivingListProcessSp(string Whse,
		                                          string PoNum,
		                                          DateTime? PDate,
		                                          [Optional, DefaultParameterValue((byte)0)] byte? MatRcptPosting,
		[Optional, DefaultParameterValue((byte)0)] byte? PrBarCode,
		[Optional, DefaultParameterValue((byte)0)] byte? PrVendItem,
		[Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional, DefaultParameterValue((byte)0)] byte? PrPreLots,
		[Optional, DefaultParameterValue((byte)0)] byte? PrPreSerials,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintManufacturerItem,
		[Optional] decimal? UserID,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPOReceivingListProcessExt = new POReceivingListProcessFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iPOReceivingListProcessExt.POReceivingListProcessSp(Whse,
				                                                                 PoNum,
				                                                                 PDate,
				                                                                 MatRcptPosting,
				                                                                 PrBarCode,
				                                                                 PrVendItem,
				                                                                 DisplayHeader,
				                                                                 PrPreLots,
				                                                                 PrPreSerials,
				                                                                 PrintManufacturerItem,
				                                                                 UserID,
				                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
