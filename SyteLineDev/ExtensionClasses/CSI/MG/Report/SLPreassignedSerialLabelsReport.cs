//PROJECT NAME: ReportExt
//CLASS NAME: SLPreassignedSerialLabelsReport.cs

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
    [IDOExtensionClass("SLPreassignedSerialLabelsReport")]
    public class SLPreassignedSerialLabelsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PreassignedSerialLabelsSp([Optional] string SerialStarting,
		[Optional] string SerialEnding,
		[Optional, DefaultParameterValue(0)] int? IncludePO,
		[Optional] string PoStarting,
		[Optional] string PoEnding,
		[Optional] int? PoLineStarting,
		[Optional] int? PoLineEnding,
		[Optional, DefaultParameterValue(0)] int? PoReleaseStarting,
		[Optional, DefaultParameterValue(0)] int? PoReleaseEnding,
		[Optional, DefaultParameterValue(0)] int? IncludeJob,
		[Optional] string JobStarting,
		[Optional] string JobEnding,
		[Optional] int? SuffixStarting,
		[Optional] int? SuffixEnding,
		[Optional, DefaultParameterValue(0)] int? IncludeTrn,
		[Optional] string TrnStarting,
		[Optional] string TrnEnding,
		[Optional] int? TrnLineStarting,
		[Optional] int? TrnLineEnding,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PreassignedSerialLabelsExt = new Rpt_PreassignedSerialLabelsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PreassignedSerialLabelsExt.Rpt_PreassignedSerialLabelsSp(SerialStarting,
				SerialEnding,
				IncludePO,
				PoStarting,
				PoEnding,
				PoLineStarting,
				PoLineEnding,
				PoReleaseStarting,
				PoReleaseEnding,
				IncludeJob,
				JobStarting,
				JobEnding,
				SuffixStarting,
				SuffixEnding,
				IncludeTrn,
				TrnStarting,
				TrnEnding,
				TrnLineStarting,
				TrnLineEnding,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
