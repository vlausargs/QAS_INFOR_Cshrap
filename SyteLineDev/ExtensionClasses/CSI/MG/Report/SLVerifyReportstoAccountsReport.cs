//PROJECT NAME: ReportExt
//CLASS NAME: SLVerifyReportstoAccountsReport.cs

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
	[IDOExtensionClass("SLVerifyReportstoAccountsReport")]
	public class SLVerifyReportstoAccountsReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VerifyReportstoAccountsSp([Optional] string AccountStarting,
		[Optional] string AccountEnding,
		[Optional] int? InvalidAccountsOnly,
		[Optional] int? DisplayHeader,
		[Optional] string PMessageLanguage,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VerifyReportstoAccountsExt = new Rpt_VerifyReportstoAccountsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VerifyReportstoAccountsExt.Rpt_VerifyReportstoAccountsSp(AccountStarting,
				AccountEnding,
				InvalidAccountsOnly,
				DisplayHeader,
				PMessageLanguage,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
