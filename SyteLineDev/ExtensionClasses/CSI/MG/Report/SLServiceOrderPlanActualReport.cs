//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderPlanActualReport.cs

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
	[IDOExtensionClass("SLServiceOrderPlanActualReport")]
	public class SLServiceOrderPlanActualReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROPlanActualSp([Optional] string SRONumBeg,
		[Optional] string SRONumEnd,
		[Optional] int? SROLineBeg,
		[Optional] int? SROLineEnd,
		[Optional] int? SROOperBeg,
		[Optional] int? SROOperEnd,
		[Optional] string ItemBeg,
		[Optional] string ItemEnd,
		[Optional] string WCBeg,
		[Optional] string WCEnd,
		[Optional] string MCBeg,
		[Optional] string MCEnd,
		[Optional, DefaultParameterValue("P")] string CostPrice,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROPlanActualExt = new SSSFSRpt_SROPlanActualFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROPlanActualExt.SSSFSRpt_SROPlanActualSp(SRONumBeg,
				SRONumEnd,
				SROLineBeg,
				SROLineEnd,
				SROOperBeg,
				SROOperEnd,
				ItemBeg,
				ItemEnd,
				WCBeg,
				WCEnd,
				MCBeg,
				MCEnd,
				CostPrice,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
