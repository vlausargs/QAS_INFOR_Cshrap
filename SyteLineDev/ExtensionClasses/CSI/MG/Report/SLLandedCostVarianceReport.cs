//PROJECT NAME: ReportExt
//CLASS NAME: SLLandedCostVarianceReport.cs

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
    [IDOExtensionClass("SLLandedCostVarianceReport")]
    public class SLLandedCostVarianceReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_LandedCostVarianceSp([Optional] string StartingPoNum,
		[Optional] string EndingPoNum,
		[Optional] string PoType,
		[Optional] string PoStat,
		[Optional] string PoitemStat,
		[Optional] int? TransDomCurr,
		[Optional] string StartingVendor,
		[Optional] string EndingVendor,
		[Optional] DateTime? StartingOrderDate,
		[Optional] DateTime? EndingOrderDate,
		[Optional] int? StartingOrderDateOffset,
		[Optional] int? EndingOrderDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_LandedCostVarianceExt = new Rpt_LandedCostVarianceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_LandedCostVarianceExt.Rpt_LandedCostVarianceSp(StartingPoNum,
				EndingPoNum,
				PoType,
				PoStat,
				PoitemStat,
				TransDomCurr,
				StartingVendor,
				EndingVendor,
				StartingOrderDate,
				EndingOrderDate,
				StartingOrderDateOffset,
				EndingOrderDateOffset,
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
