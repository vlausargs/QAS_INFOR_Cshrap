//PROJECT NAME: ReportExt
//CLASS NAME: SLTotalWIPValuebyAccountReport.cs

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
    [IDOExtensionClass("SLTotalWIPValuebyAccountReport")]
    public class SLTotalWIPValuebyAccountReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TotalWIPValuebyAccountSp([Optional] string SAcct,
		[Optional] string EAcct,
		[Optional] string ExBegproductcode,
		[Optional] string ExEndProductcode,
		[Optional] string ExBegItem,
		[Optional] string ExEndItem,
		[Optional] string ExBegjob,
		[Optional] string ExEndJob,
		[Optional] int? ExBegSuffix,
		[Optional] int? ExEndSuffix,
		[Optional] string ExOptgoJJobStat,
		[Optional, DefaultParameterValue(0)] int? PUnitCode1,
		[Optional, DefaultParameterValue(0)] int? PUnitCode2,
		[Optional, DefaultParameterValue(0)] int? PUnitCode3,
		[Optional, DefaultParameterValue(0)] int? PUnitCode4,
		[Optional] int? Displayheader,
		[Optional] string SRONumBeg,
		[Optional] string SRONumEnd,
		[Optional] string SROOperStatus,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TotalWIPValuebyAccountExt = new Rpt_TotalWIPValuebyAccountFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TotalWIPValuebyAccountExt.Rpt_TotalWIPValuebyAccountSp(SAcct,
				EAcct,
				ExBegproductcode,
				ExEndProductcode,
				ExBegItem,
				ExEndItem,
				ExBegjob,
				ExEndJob,
				ExBegSuffix,
				ExEndSuffix,
				ExOptgoJJobStat,
				PUnitCode1,
				PUnitCode2,
				PUnitCode3,
				PUnitCode4,
				Displayheader,
				SRONumBeg,
				SRONumEnd,
				SROOperStatus,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
