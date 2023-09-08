//PROJECT NAME: ReportExt
//CLASS NAME: SLRMAStatusReport.cs

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
	[IDOExtensionClass("SLRMAStatusReport")]
	public class SLRMAStatusReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RMAStatusSp([Optional, DefaultParameterValue("OSCHR")] string RMAStatus,
		[Optional, DefaultParameterValue("OFCH")] string RMALineStatus,
		[Optional, DefaultParameterValue(0)] int? PrintExternalNotes,
		[Optional, DefaultParameterValue(0)] int? PrintInternalNotes,
		[Optional, DefaultParameterValue(0)] int? TranslateToDomesticCurrency,
		[Optional, DefaultParameterValue(0)] int? ToBeCredited,
		[Optional, DefaultParameterValue("R")] string SortBy,
		[Optional] string RMAStarting,
		[Optional] string RMAEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] string WhseStarting,
		[Optional] string WhseEnding,
		[Optional] DateTime? RMADateStarting,
		[Optional] DateTime? RMADateEnding,
		[Optional] string ProblemCodeStarting,
		[Optional] string ProblemCodeEnding,
		[Optional] int? RMALineStarting,
		[Optional] int? RMALineEnding,
		[Optional] string RMAItemStarting,
		[Optional] string RMAItemEnding,
		[Optional] string EvaluationStarting,
		[Optional] string EvaluationEnding,
		[Optional] string DispositionStarting,
		[Optional] string DispositionEnding,
		[Optional] int? RMADateStartingOffset,
		[Optional] int? RMADateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RMAStatusExt = new Rpt_RMAStatusFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RMAStatusExt.Rpt_RMAStatusSp(RMAStatus,
				RMALineStatus,
				PrintExternalNotes,
				PrintInternalNotes,
				TranslateToDomesticCurrency,
				ToBeCredited,
				SortBy,
				RMAStarting,
				RMAEnding,
				CustomerStarting,
				CustomerEnding,
				WhseStarting,
				WhseEnding,
				RMADateStarting,
				RMADateEnding,
				ProblemCodeStarting,
				ProblemCodeEnding,
				RMALineStarting,
				RMALineEnding,
				RMAItemStarting,
				RMAItemEnding,
				EvaluationStarting,
				EvaluationEnding,
				DispositionStarting,
				DispositionEnding,
				RMADateStartingOffset,
				RMADateEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
