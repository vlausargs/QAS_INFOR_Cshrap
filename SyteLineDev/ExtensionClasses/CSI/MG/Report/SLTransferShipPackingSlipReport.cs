//PROJECT NAME: ReportExt
//CLASS NAME: SLTransferShipPackingSlipReport.cs

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
    [IDOExtensionClass("SLTransferShipPackingSlipReport")]
    public class SLTransferShipPackingSlipReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TransferPackingSlipSp([Optional] int? MinPackNum,
		[Optional] int? MaxPackNum,
		[Optional, DefaultParameterValue(0)] int? PrINTOrderText,
		[Optional, DefaultParameterValue(0)] int? PrINTLineText,
		[Optional, DefaultParameterValue(0)] int? ShowINTernal,
		[Optional, DefaultParameterValue(0)] int? ShowExternal,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional, DefaultParameterValue("TC")] string TrnStat,
		[Optional, DefaultParameterValue("TC")] string TrnitemStat,
		[Optional] string OrderStarting,
		[Optional] string OrderEnding,
		[Optional] int? OrderLineStarting,
		[Optional] int? OrderLineEnding,
		[Optional] string SiteStarting,
		[Optional] string SiteEnding,
		[Optional] string FromWhseStarting,
		[Optional] string FromWhseEnding,
		[Optional] string ToWhseStarting,
		[Optional] string ToWhseEnding,
		[Optional] DateTime? DueDateStarting,
		[Optional] DateTime? DueDateEnding,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TransferPackingSlipExt = new Rpt_TransferPackingSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TransferPackingSlipExt.Rpt_TransferPackingSlipSp(MinPackNum,
				MaxPackNum,
				PrINTOrderText,
				PrINTLineText,
				ShowINTernal,
				ShowExternal,
				DisplayHeader,
				TrnStat,
				TrnitemStat,
				OrderStarting,
				OrderEnding,
				OrderLineStarting,
				OrderLineEnding,
				SiteStarting,
				SiteEnding,
				FromWhseStarting,
				FromWhseEnding,
				ToWhseStarting,
				ToWhseEnding,
				DueDateStarting,
				DueDateEnding,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
