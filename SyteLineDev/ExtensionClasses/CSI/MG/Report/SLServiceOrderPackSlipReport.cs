//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderPackSlipReport.cs

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
	[IDOExtensionClass("SLServiceOrderPackSlipReport")]
	public class SLServiceOrderPackSlipReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROPackSlipSp([Optional] int? BegPackNum,
		[Optional] int? EndPackNum,
		[Optional] int? BegPackSeq,
		[Optional] int? EndPackSeq,
		[Optional] string BegCustNum,
		[Optional] string EndCustNum,
		[Optional, DefaultParameterValue(0)] int? PrintSerials,
		[Optional, DefaultParameterValue(0)] int? PrintPckHdrNotes,
		[Optional, DefaultParameterValue(0)] int? PrintPckLineNotes,
		[Optional, DefaultParameterValue(1)] int? PrintInternalNotes,
		[Optional, DefaultParameterValue(1)] int? PrintExternalNotes,
		[Optional] DateTime? BegPackDate,
		[Optional] DateTime? EndPackDate,
		[Optional, DefaultParameterValue(0)] int? PrintSROOperNotes,
		[Optional, DefaultParameterValue(0)] int? PrintSROLineNotes,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional, DefaultParameterValue(0)] int? PrintSRONotes,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROPackSlipExt = new SSSFSRpt_SROPackSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROPackSlipExt.SSSFSRpt_SROPackSlipSp(BegPackNum,
				EndPackNum,
				BegPackSeq,
				EndPackSeq,
				BegCustNum,
				EndCustNum,
				PrintSerials,
				PrintPckHdrNotes,
				PrintPckLineNotes,
				PrintInternalNotes,
				PrintExternalNotes,
				BegPackDate,
				EndPackDate,
				PrintSROOperNotes,
				PrintSROLineNotes,
				DisplayHeader,
				PrintSRONotes,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
