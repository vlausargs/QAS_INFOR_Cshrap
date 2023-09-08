//PROJECT NAME: ReportExt
//CLASS NAME: SLMXIETUReport.cs

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
    [IDOExtensionClass("SLMXIETUReport")]
    public class SLMXIETUReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MXIETUSp([Optional] string EntityStarting,
		[Optional] string EntityEnding,
		[Optional] DateTime? ReconDateStarting,
		[Optional] DateTime? ReconDateEnding,
		[Optional] string IetuClasification,
		[Optional] int? EndPeriod,
		[Optional] int? FiscalYear,
		[Optional, DefaultParameterValue("D")] string ReportMode,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MXIETUExt = new Rpt_MXIETUFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MXIETUExt.Rpt_MXIETUSp(EntityStarting,
				EntityEnding,
				ReconDateStarting,
				ReconDateEnding,
				IetuClasification,
				EndPeriod,
				FiscalYear,
				ReportMode,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
