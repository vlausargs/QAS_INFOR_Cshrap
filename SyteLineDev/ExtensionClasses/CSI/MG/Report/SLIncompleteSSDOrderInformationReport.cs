//PROJECT NAME: ReportExt
//CLASS NAME: SLIncompleteSSDOrderInformationReport.cs

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
	[IDOExtensionClass("SLIncompleteSSDOrderInformationReport")]
	public class SLIncompleteSSDOrderInformationReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_IncompleteSSDOrderInformationSp([Optional] DateTime? PStartingPeriod,
		[Optional] DateTime? PEndingPeriod,
		[Optional] int? PStartingPeriodOffset,
		[Optional] int? PEndingPeriodOffset,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_IncompleteSSDOrderInformationExt = new Rpt_IncompleteSSDOrderInformationFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_IncompleteSSDOrderInformationExt.Rpt_IncompleteSSDOrderInformationSp(PStartingPeriod,
				PEndingPeriod,
				PStartingPeriodOffset,
				PEndingPeriodOffset,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
