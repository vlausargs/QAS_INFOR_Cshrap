//PROJECT NAME: ReportExt
//CLASS NAME: SLPostProjectInvoiceMilestonesLaserReport.cs

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
	[IDOExtensionClass("SLPostProjectInvoiceMilestonesLaserReport")]
	public class SLPostProjectInvoiceMilestonesLaserReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjNomInvSp([Optional] string StartingProjNum,
		[Optional] string EndingProjNum,
		[Optional] string StartingInvMsNum,
		[Optional] string EndingInvMsNum,
		[Optional] string StartingInvNum,
		[Optional] string EndingInvNum,
		[Optional] int? PrintMilestoneNotes,
		[Optional] int? PrintCustomerNotes,
		[Optional] int? PrintProjectNotes,
		[Optional] int? PrintStandardNotes,
		[Optional] int? PrintEuroTotal,
		[Optional] int? XLateToDomestic,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskID,
		[Optional] string Username,
		[Optional] string BGSessionId,
		[Optional, DefaultParameterValue(0)] int? PrintDiscountAmt,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjNomInvExt = new Rpt_ProjNomInvFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjNomInvExt.Rpt_ProjNomInvSp(StartingProjNum,
				EndingProjNum,
				StartingInvMsNum,
				EndingInvMsNum,
				StartingInvNum,
				EndingInvNum,
				PrintMilestoneNotes,
				PrintCustomerNotes,
				PrintProjectNotes,
				PrintStandardNotes,
				PrintEuroTotal,
				XLateToDomestic,
				ShowInternal,
				ShowExternal,
				DisplayHeader,
				TaskID,
				Username,
				BGSessionId,
				PrintDiscountAmt,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
