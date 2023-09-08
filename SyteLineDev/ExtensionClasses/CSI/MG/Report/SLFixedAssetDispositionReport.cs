//PROJECT NAME: ReportExt
//CLASS NAME: SLFixedAssetDispositionReport.cs

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
	[IDOExtensionClass("SLFixedAssetDispositionReport")]
	public class SLFixedAssetDispositionReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_FixedAssetDispositionSp([Optional] DateTime? PStartingDisposalDate,
		[Optional] DateTime? PEndingDisposalDate,
		[Optional, DefaultParameterValue("R")] string PAssetTypes,
		[Optional] string PStartingAssetNum,
		[Optional] string PEndingAssetNum,
		[Optional] string PStartingClassCode,
		[Optional] string PEndingClassCode,
		[Optional] string PStartingDepartment,
		[Optional] string PEndingDepartment,
		[Optional] string PStartingLocation,
		[Optional] string PEndingLocation,
		[Optional] int? PStartingDisposalDateOffset,
		[Optional] int? PEndingDisposalDateOffset,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_FixedAssetDispositionExt = new Rpt_FixedAssetDispositionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_FixedAssetDispositionExt.Rpt_FixedAssetDispositionSp(PStartingDisposalDate,
				PEndingDisposalDate,
				PAssetTypes,
				PStartingAssetNum,
				PEndingAssetNum,
				PStartingClassCode,
				PEndingClassCode,
				PStartingDepartment,
				PEndingDepartment,
				PStartingLocation,
				PEndingLocation,
				PStartingDisposalDateOffset,
				PEndingDisposalDateOffset,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
