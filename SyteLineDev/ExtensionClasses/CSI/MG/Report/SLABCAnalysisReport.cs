//PROJECT NAME: ReportExt
//CLASS NAME: SLABCAnalysisReport.cs

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
    [IDOExtensionClass("SLABCAnalysisReport")]
    public class SLABCAnalysisReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ItemABCAnalysisSp(string Process,
		                                   byte? Background,
		                                   int? TaskId,
		                                   string AnalysisMethod,
		                                   string ByValOrUnits,
		                                   string PMTCode,
		                                   int? ABC1,
		                                   int? ABC2,
		                                   int? ABC3,
		                                   ref string Infobar,
		                                   [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iItemABCAnalysisExt = new ItemABCAnalysisFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iItemABCAnalysisExt.ItemABCAnalysisSP(Process,
				                                                   Background,
				                                                   TaskId,
				                                                   AnalysisMethod,
				                                                   ByValOrUnits,
				                                                   PMTCode,
				                                                   ABC1,
				                                                   ABC2,
				                                                   ABC3,
				                                                   Infobar,
				                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
    }
}
