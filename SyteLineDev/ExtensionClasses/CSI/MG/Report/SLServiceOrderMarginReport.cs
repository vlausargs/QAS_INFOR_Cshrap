//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderMarginReport.cs

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
	[IDOExtensionClass("SLServiceOrderMarginReport")]
	public class SLServiceOrderMarginReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROMarginSP([Optional] string SRONumBeg,
		[Optional] string SRONumEnd,
		[Optional] string CustNumBeg,
		[Optional] string CustNumEnd,
		[Optional] string SerNumBeg,
		[Optional] string SerNumEnd,
		[Optional] string IncNumBeg,
		[Optional] string IncNumEnd,
		[Optional] DateTime? TransDateBeg,
		[Optional] DateTime? TransDateEnd,
		[Optional] string RegionBeg,
		[Optional] string RegionEnd,
		[Optional, DefaultParameterValue(0)] int? MatDetail,
		[Optional, DefaultParameterValue(0)] int? LabDetail,
		[Optional, DefaultParameterValue(0)] int? MiscDetail,
		[Optional, DefaultParameterValue(0)] int? SROPageBreak,
		[Optional] int? TransDateOffSetBeg,
		[Optional, DefaultParameterValue("S")] string SortBy,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional] DateTime? PostDateBeg,
		[Optional] DateTime? PostDateEnd,
		[Optional] int? PostDateOffSetBeg,
		[Optional, DefaultParameterValue(0)] int? ExBillCodeC,
		[Optional, DefaultParameterValue(0)] int? ExBillCodeN,
		[Optional, DefaultParameterValue(0)] int? ExBillCodeR,
		[Optional, DefaultParameterValue(0)] int? ExBillCodeL,
		[Optional, DefaultParameterValue(0)] int? ExBillCodeW,
		[Optional, DefaultParameterValue(0)] int? ExBillCodeU,
		[Optional] DateTime? CloseDateBeg,
		[Optional] DateTime? CloseDateEnd,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROMarginExt = new SSSFSRpt_SROMarginFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROMarginExt.SSSFSRpt_SROMarginSP(SRONumBeg,
				SRONumEnd,
				CustNumBeg,
				CustNumEnd,
				SerNumBeg,
				SerNumEnd,
				IncNumBeg,
				IncNumEnd,
				TransDateBeg,
				TransDateEnd,
				RegionBeg,
				RegionEnd,
				MatDetail,
				LabDetail,
				MiscDetail,
				SROPageBreak,
				TransDateOffSetBeg,
				SortBy,
				DisplayHeader,
				PostDateBeg,
				PostDateEnd,
				PostDateOffSetBeg,
				ExBillCodeC,
				ExBillCodeN,
				ExBillCodeR,
				ExBillCodeL,
				ExBillCodeW,
				ExBillCodeU,
				CloseDateBeg,
				CloseDateEnd,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
