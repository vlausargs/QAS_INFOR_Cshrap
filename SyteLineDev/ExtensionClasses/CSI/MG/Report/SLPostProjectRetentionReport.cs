//PROJECT NAME: ReportExt
//CLASS NAME: SLPostProjectRetentionReport.cs

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
	[IDOExtensionClass("SLPostProjectRetentionReport")]
	public class SLPostProjectRetentionReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjRetTransSp([Optional] string StartingProjNum,
		[Optional] string EndingProjNum,
		DateTime? PostDate,
		[Optional, DefaultParameterValue("PLS")] string InvoiceText,
		[Optional, DefaultParameterValue(0)] int? PrintEuroTotal,
		[Optional, DefaultParameterValue(0)] int? XLateToDomestic,
		[Optional, DefaultParameterValue(0)] int? DoPost,
		[Optional, DefaultParameterValue(1)] int? ShowInternal,
		[Optional, DefaultParameterValue(1)] int? ShowExternal,
		[Optional, DefaultParameterValue(1)] int? DisplayHeader,
		[Optional, DefaultParameterValue(1)] int? TransReport,
		[Optional] decimal? UserId,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjRetTransExt = new Rpt_ProjRetTransFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjRetTransExt.Rpt_ProjRetTransSp(StartingProjNum,
				EndingProjNum,
				PostDate,
				InvoiceText,
				PrintEuroTotal,
				XLateToDomestic,
				DoPost,
				ShowInternal,
				ShowExternal,
				DisplayHeader,
				TransReport,
				UserId,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
