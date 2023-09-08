//PROJECT NAME: ReportExt
//CLASS NAME: SLEUSupplimentaryStatisticalDeclarationReport.cs

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
	[IDOExtensionClass("SLEUSupplimentaryStatisticalDeclarationReport")]
	public class SLEUSupplimentaryStatisticalDeclarationReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable rpt_ECSupplimentaryStatisticalDeclarationSp([Optional] DateTime? PeriodStarting,
		[Optional] DateTime? PeriodEnding,
		[Optional] string ExOptdfEcSsdOpt,
		[Optional] int? ExOptszSummaryOrDetail,
		[Optional] int? ExOptdfEcSsdTrade,
		[Optional] int? ExOptdfEcSsdNotc,
		[Optional] int? ExOptdfElOutput,
		[Optional] string TElOut,
		[Optional] string CommCodeStarting,
		[Optional] string CommCodeEnding,
		[Optional] string ECCodeStarting,
		[Optional] string ECCodeEnding,
		[Optional] int? PeriodStartingOffset,
		[Optional] int? PeriodEndingOffset,
		[Optional] int? ExOptszPreviewOrPrint,
		[Optional, DefaultParameterValue(0)] int? PrintFlag,
		[Optional] string ExPrintPeriod,
		[Optional, DefaultParameterValue(1)] int? ReportingLevel,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var irpt_ECSupplimentaryStatisticalDeclarationExt = new rpt_ECSupplimentaryStatisticalDeclarationFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = irpt_ECSupplimentaryStatisticalDeclarationExt.rpt_ECSupplimentaryStatisticalDeclarationSp(PeriodStarting,
				PeriodEnding,
				ExOptdfEcSsdOpt,
				ExOptszSummaryOrDetail,
				ExOptdfEcSsdTrade,
				ExOptdfEcSsdNotc,
				ExOptdfElOutput,
				TElOut,
				CommCodeStarting,
				CommCodeEnding,
				ECCodeStarting,
				ECCodeEnding,
				PeriodStartingOffset,
				PeriodEndingOffset,
				ExOptszPreviewOrPrint,
				PrintFlag,
				ExPrintPeriod,
				ReportingLevel,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
