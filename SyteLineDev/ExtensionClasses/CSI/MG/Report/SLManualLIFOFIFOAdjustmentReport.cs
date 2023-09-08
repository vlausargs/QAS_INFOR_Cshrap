//PROJECT NAME: ReportExt
//CLASS NAME: SLManualLIFOFIFOAdjustmentReport.cs

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
    [IDOExtensionClass("SLManualLIFOFIFOAdjustmentReport")]
    public class SLManualLIFOFIFOAdjustmentReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ManualLIFOFIFOAdjustmentSp([Optional] string SessionIdChar,
		[Optional] string InvAdjAcct,
		[Optional] string InvAdjAcctDesc,
		[Optional] string ItemlifoItem,
		[Optional] string ItemlifoInvAcct,
		[Optional] string ItemlifoLbrAcct,
		[Optional] string ItemlifoFovhdAcct,
		[Optional] string ItemlifoVovhdAcct,
		[Optional] string ItemlifoOutAcct,
		[Optional] string CostMethod,
		[Optional] decimal? DerLocQtyOnHand,
		[Optional] decimal? DerStackValue,
		[Optional] decimal? DerStackQty,
		[Optional] decimal? AdjustedValue,
		[Optional] decimal? AdjustedQuantity,
		[Optional] string Whse,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ManualLIFOFIFOAdjustmentExt = new Rpt_ManualLIFOFIFOAdjustmentFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ManualLIFOFIFOAdjustmentExt.Rpt_ManualLIFOFIFOAdjustmentSp(SessionIdChar,
				InvAdjAcct,
				InvAdjAcctDesc,
				ItemlifoItem,
				ItemlifoInvAcct,
				ItemlifoLbrAcct,
				ItemlifoFovhdAcct,
				ItemlifoVovhdAcct,
				ItemlifoOutAcct,
				CostMethod,
				DerLocQtyOnHand,
				DerStackValue,
				DerStackQty,
				AdjustedValue,
				AdjustedQuantity,
				Whse,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
