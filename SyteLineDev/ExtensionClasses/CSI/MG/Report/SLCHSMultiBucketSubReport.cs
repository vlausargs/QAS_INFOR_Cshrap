//PROJECT NAME: ReportExt
//CLASS NAME: SLCHSMultiBucketSubReport.cs

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
    [IDOExtensionClass("SLCHSMultiBucketSubReport")]
    public class SLCHSMultiBucketSubReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_MultiBucketSubSp(string SessionID,
		                                         int? ReportID,
		                                         short? RptLines,
		                                         byte? BalColIsLast,
		                                         [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_MultiBucketSubExt = new CHSRpt_MultiBucketSubFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_MultiBucketSubExt.CHSRpt_MultiBucketSubSp(SessionID,
				                                                               ReportID,
				                                                               RptLines,
				                                                               BalColIsLast,
				                                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
