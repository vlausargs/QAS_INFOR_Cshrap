//PROJECT NAME: ReportExt
//CLASS NAME: SLPostProjectRetentionInvoiceLaserReport.cs

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
	[IDOExtensionClass("SLPostProjectRetentionInvoiceLaserReport")]
	public class SLPostProjectRetentionInvoiceLaserReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjRetInvSp([Optional] string StartingProjNum,
		[Optional] string EndingProjNum,
		[Optional] DateTime? PostDate,
		[Optional] string InvoiceText,
		[Optional] int? PrintEuroTotal,
		[Optional] int? XLateToDomestic,
		[Optional] int? DoPost,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] int? DisplayHeader,
		[Optional] int? TransReport,
		[Optional, DefaultParameterValue(0)] int? PrintDiscountAmt,
		[Optional] decimal? UserId,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjRetInvExt = new Rpt_ProjRetInvFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjRetInvExt.Rpt_ProjRetInvSp(StartingProjNum,
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
				PrintDiscountAmt,
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
