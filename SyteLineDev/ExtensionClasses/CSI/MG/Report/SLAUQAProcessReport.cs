//PROJECT NAME: ReportExt
//CLASS NAME: SLAUQAProcessReport.cs

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
    [IDOExtensionClass("SLAUQAProcessReport")]
    public class SLAUQAProcessReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_Rpt_QAProcessSp([Optional] string QAprocessIDStarting,
		                                    [Optional] string QAprocessIDEnding,
		                                    [Optional] string QAProcessStarting,
		                                    [Optional] string QAProcessEnding,
		                                    [Optional] string ProcessSourceTypeStarting,
		                                    [Optional] string ProcessSourceTypeEnding,
		                                    [Optional] string ProcessSourceStarting,
		                                    [Optional] string ProcessSourceEnding,
		                                    [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iAU_Rpt_QAProcessExt = new AU_Rpt_QAProcessFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iAU_Rpt_QAProcessExt.AU_Rpt_QAProcessSp(QAprocessIDStarting,
				                                                     QAprocessIDEnding,
				                                                     QAProcessStarting,
				                                                     QAProcessEnding,
				                                                     ProcessSourceTypeStarting,
				                                                     ProcessSourceTypeEnding,
				                                                     ProcessSourceStarting,
				                                                     ProcessSourceEnding,
				                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
