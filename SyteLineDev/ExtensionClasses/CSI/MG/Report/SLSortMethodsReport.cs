//PROJECT NAME: ReportExt
//CLASS NAME: SLSortMethodsReport.cs

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
	[IDOExtensionClass("SLSortMethodsReport")]
	public class SLSortMethodsReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SortMethodsSp([Optional] string ReportID,
		[Optional, DefaultParameterValue("M")] string ReportType,
		[Optional] string SiteGroup,
		[Optional, DefaultParameterValue(0)] int? AcctDetail,
		[Optional, DefaultParameterValue(0)] int? Unit1Detail,
		[Optional, DefaultParameterValue(0)] int? Unit2Detail,
		[Optional, DefaultParameterValue(0)] int? Unit3Detail,
		[Optional, DefaultParameterValue(0)] int? Unit4Detail,
		[Optional] string SAcctUnit1,
		[Optional] string SAcctUnit2,
		[Optional] string SAcctUnit3,
		[Optional] string SAcctUnit4,
		[Optional] string EAcctUnit1,
		[Optional] string EAcctUnit2,
		[Optional] string EAcctUnit3,
		[Optional] string EAcctUnit4,
		[Optional, DefaultParameterValue(0)] int? AcctSort__1,
		[Optional, DefaultParameterValue(0)] int? AcctSort__2,
		[Optional, DefaultParameterValue(0)] int? AcctSort__3,
		[Optional, DefaultParameterValue(0)] int? AcctSort__4,
		[Optional, DefaultParameterValue(0)] int? AcctSort__5,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SortMethodsExt = new Rpt_SortMethodsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SortMethodsExt.Rpt_SortMethodsSp(ReportID,
				ReportType,
				SiteGroup,
				AcctDetail,
				Unit1Detail,
				Unit2Detail,
				Unit3Detail,
				Unit4Detail,
				SAcctUnit1,
				SAcctUnit2,
				SAcctUnit3,
				SAcctUnit4,
				EAcctUnit1,
				EAcctUnit2,
				EAcctUnit3,
				EAcctUnit4,
				AcctSort__1,
				AcctSort__2,
				AcctSort__3,
				AcctSort__4,
				AcctSort__5,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
