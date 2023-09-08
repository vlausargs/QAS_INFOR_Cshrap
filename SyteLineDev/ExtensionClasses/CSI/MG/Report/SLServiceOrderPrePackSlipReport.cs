//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderPrePackSlipReport.cs

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
	[IDOExtensionClass("SLServiceOrderPrePackSlipReport")]
	public class SLServiceOrderPrePackSlipReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROPrePackSlipSp([Optional] string BegSroNum,
		[Optional] string EndSroNum,
		[Optional] int? BegSroLine,
		[Optional] int? EndSroLine,
		[Optional] int? BegSroOper,
		[Optional] int? EndSroOper,
		[Optional] string BegCustNum,
		[Optional] string EndCustNum,
		[Optional] DateTime? BegOpenDate,
		[Optional] DateTime? EndOpenDate,
		[Optional] DateTime? BegTransDate,
		[Optional] DateTime? EndTransDate,
		[Optional] DateTime? PackDate,
		[Optional, DefaultParameterValue(1)] int? InclOpen,
		[Optional, DefaultParameterValue(1)] int? InclInvoice,
		[Optional, DefaultParameterValue(1)] int? InclClosed,
		[Optional, DefaultParameterValue(0)] int? PrintSerials,
		[Optional, DefaultParameterValue(0)] int? PrintSroNotes,
		[Optional, DefaultParameterValue(0)] int? PrintLineNotes,
		[Optional, DefaultParameterValue(0)] int? PrintOperNotes,
		[Optional, DefaultParameterValue(0)] int? PrintTransNotes,
		[Optional, DefaultParameterValue(1)] int? PrintInternalNotes,
		[Optional, DefaultParameterValue(1)] int? PrintExternalNotes,
		[Optional, DefaultParameterValue("C")] string ShipToAddress,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROPrePackSlipExt = new SSSFSRpt_SROPrePackSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROPrePackSlipExt.SSSFSRpt_SROPrePackSlipSp(BegSroNum,
				EndSroNum,
				BegSroLine,
				EndSroLine,
				BegSroOper,
				EndSroOper,
				BegCustNum,
				EndCustNum,
				BegOpenDate,
				EndOpenDate,
				BegTransDate,
				EndTransDate,
				PackDate,
				InclOpen,
				InclInvoice,
				InclClosed,
				PrintSerials,
				PrintSroNotes,
				PrintLineNotes,
				PrintOperNotes,
				PrintTransNotes,
				PrintInternalNotes,
				PrintExternalNotes,
				ShipToAddress,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
