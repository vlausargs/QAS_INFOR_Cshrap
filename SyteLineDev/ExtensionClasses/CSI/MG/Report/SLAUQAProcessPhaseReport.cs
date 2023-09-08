//PROJECT NAME: ReportExt
//CLASS NAME: SLAUQAProcessPhaseReport.cs

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
    [IDOExtensionClass("SLAUQAProcessPhaseReport")]
    public class SLAUQAProcessPhaseReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_Rpt_QAProcessPhaseSp([Optional] string QAProcessID,
		                                         [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iAU_Rpt_QAProcessPhaseExt = new AU_Rpt_QAProcessPhaseFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iAU_Rpt_QAProcessPhaseExt.AU_Rpt_QAProcessPhaseSp(QAProcessID,
				                                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
