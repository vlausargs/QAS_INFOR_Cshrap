//PROJECT NAME: ReportExt
//CLASS NAME: SLMXDIOTExeptionsReport.cs

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
    [IDOExtensionClass("SLMXDIOTExeptionsReport")]
    public class SLMXDIOTExeptionsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MXDIOTExeptionsSp([Optional] DateTime? ReconDateStarting,
		[Optional] DateTime? ReconDateEnding,
		[Optional] int? EndPeriod,
		[Optional] int? FiscalYear,
		[Optional, DefaultParameterValue(0)] int? Reprint,
		[Optional, DefaultParameterValue(0)] int? Close,
		[Optional, DefaultParameterValue("P")] string PrintOrCommit,
		[Optional, DefaultParameterValue("D")] string ReportType,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MXDIOTExeptionsExt = new Rpt_MXDIOTExeptionsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MXDIOTExeptionsExt.Rpt_MXDIOTExeptionsSp(ReconDateStarting,
				ReconDateEnding,
				EndPeriod,
				FiscalYear,
				Reprint,
				Close,
				PrintOrCommit,
				ReportType,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
