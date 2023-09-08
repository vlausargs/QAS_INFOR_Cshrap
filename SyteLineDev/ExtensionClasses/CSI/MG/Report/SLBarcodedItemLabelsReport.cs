//PROJECT NAME: ReportExt
//CLASS NAME: SLBarcodedItemLabelsReport.cs

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
    [IDOExtensionClass("SLBarcodedItemLabelsReport")]
    public class SLBarcodedItemLabelsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_BarcodedItemLabelsSp([Optional, DefaultParameterValue(2)] int? LabelSets,
		[Optional, DefaultParameterValue((byte)0)] byte? DisplayLot,
		[Optional] string WarehouseStarting,
		[Optional] string WarehouseEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string LotStarting,
		[Optional] string LotEnding,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_BarcodedItemLabelsExt = new Rpt_BarcodedItemLabelsFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_BarcodedItemLabelsExt.Rpt_BarcodedItemLabelsSp(LabelSets,
				                                                                 DisplayLot,
				                                                                 WarehouseStarting,
				                                                                 WarehouseEnding,
				                                                                 ItemStarting,
				                                                                 ItemEnding,
				                                                                 LotStarting,
				                                                                 LotEnding,
				                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
