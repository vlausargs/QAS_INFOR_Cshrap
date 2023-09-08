//PROJECT NAME: ReportExt
//CLASS NAME: SLOrderCostReport.cs

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
    [IDOExtensionClass("SLOrderCostReport")]
    public class SLOrderCostReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RPT_OrderCostSP([Optional] string ExOptacCoStat07,
		[Optional] int? ExMiscPrintLine,
		[Optional] int? ExOptszShowDetail,
		[Optional] string Begconum,
		[Optional] string Endconum,
		[Optional] int? Begcoline,
		[Optional] int? Endcoline,
		[Optional] int? Begcorelease,
		[Optional] int? Endcorelease,
		[Optional] string Begcustnum,
		[Optional] string Endcustnum,
		[Optional] DateTime? Begorderdate,
		[Optional] DateTime? Endorderdate,
		[Optional] int? BegorderdateOffset,
		[Optional] int? EndorderdateOffset,
		[Optional, DefaultParameterValue(0)] int? PrintPrice,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRPT_OrderCostExt = new RPT_OrderCostFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRPT_OrderCostExt.RPT_OrderCostSP(ExOptacCoStat07,
				ExMiscPrintLine,
				ExOptszShowDetail,
				Begconum,
				Endconum,
				Begcoline,
				Endcoline,
				Begcorelease,
				Endcorelease,
				Begcustnum,
				Endcustnum,
				Begorderdate,
				Endorderdate,
				BegorderdateOffset,
				EndorderdateOffset,
				PrintPrice,
				PrintCost,
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
