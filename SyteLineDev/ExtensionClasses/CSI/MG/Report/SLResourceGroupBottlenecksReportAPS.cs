//PROJECT NAME: ReportExt
//CLASS NAME: SLResourceGroupBottlenecksReportAPS.cs

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
	[IDOExtensionClass("SLResourceGroupBottlenecksReportAPS")]
	public class SLResourceGroupBottlenecksReportAPS : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ResourceGroupBottlenecksApsSp(string GroupStarting,
		string GroupEnding,
		DateTime? StartDate,
		DateTime? EndDate,
		int? ExcludeInfinite,
		int? ListDelays,
		int? DisplayHeader,
		int? ALTNO,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ResourceGroupBottlenecksApsExt = new Rpt_ResourceGroupBottlenecksApsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ResourceGroupBottlenecksApsExt.Rpt_ResourceGroupBottlenecksApsSp(GroupStarting,
				GroupEnding,
				StartDate,
				EndDate,
				ExcludeInfinite,
				ListDelays,
				DisplayHeader,
				ALTNO,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
