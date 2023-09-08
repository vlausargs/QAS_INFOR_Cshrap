//PROJECT NAME: ReportExt
//CLASS NAME: SLCHSMultiBucketMainReport.cs

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
    [IDOExtensionClass("SLCHSMultiBucketMainReport")]
    public class SLCHSMultiBucketMainReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_MultiBucketMainSp(string SessionID,
		                                          short? RptLines,
		                                          byte? BalColIsLast,
		                                          int? BGCount,
		                                          [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_MultiBucketMainExt = new CHSRpt_MultiBucketMainFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_MultiBucketMainExt.CHSRpt_MultiBucketMainSp(SessionID,
				                                                                 RptLines,
				                                                                 BalColIsLast,
				                                                                 BGCount,
				                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
