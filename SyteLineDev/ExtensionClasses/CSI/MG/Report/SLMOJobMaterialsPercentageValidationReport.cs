//PROJECT NAME: ReportExt
//CLASS NAME: SLMOJobMaterialsPercentageValidationReport.cs

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
	[IDOExtensionClass("SLMOJobMaterialsPercentageValidationReport")]
	public class SLMOJobMaterialsPercentageValidationReport : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable MO_Rpt_JobMaterialsPercentageValidationSp([Optional] string PJobStarting,
		                                                           [Optional] string PJobEnding,
		                                                           [Optional] string PEstimateJobStarting,
		                                                           [Optional] string PEstimateJobEnding,
		                                                           [Optional] string PItemStarting,
		                                                           [Optional] string PItemEnding,
		                                                           [Optional] string PAlternateIDStarting,
		                                                           [Optional] string PAlternateIDEnding,
		                                                           [Optional] string PAlternateItemStarting,
		                                                           [Optional] string PAlternateItemEnding,
		                                                           [Optional, DefaultParameterValue((byte)0)] byte? PJobBOM,
		[Optional, DefaultParameterValue((byte)0)] byte? PEstimateJobBOM,
		[Optional, DefaultParameterValue((byte)0)] byte? PCurrentBOM,
		[Optional, DefaultParameterValue((byte)0)] byte? PAlternateBOM,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iMO_Rpt_JobMaterialsPercentageValidationExt = new MO_Rpt_JobMaterialsPercentageValidationFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iMO_Rpt_JobMaterialsPercentageValidationExt.MO_Rpt_JobMaterialsPercentageValidationSp(PJobStarting,
				                                                                                                   PJobEnding,
				                                                                                                   PEstimateJobStarting,
				                                                                                                   PEstimateJobEnding,
				                                                                                                   PItemStarting,
				                                                                                                   PItemEnding,
				                                                                                                   PAlternateIDStarting,
				                                                                                                   PAlternateIDEnding,
				                                                                                                   PAlternateItemStarting,
				                                                                                                   PAlternateItemEnding,
				                                                                                                   PJobBOM,
				                                                                                                   PEstimateJobBOM,
				                                                                                                   PCurrentBOM,
				                                                                                                   PAlternateBOM,
				                                                                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
