//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectPackingSlipReport.cs

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
    [IDOExtensionClass("SLProjectPackingSlipReport")]
    public class SLProjectPackingSlipReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectPackingSlipSp(string PckCall,
		[Optional] int? MinPackNum,
		[Optional] int? MaxPackNum,
		[Optional, DefaultParameterValue(0)] int? PrintProjNotes,
		[Optional, DefaultParameterValue(0)] int? PrintResNotes,
		[Optional, DefaultParameterValue(0)] int? ShowInternal,
		[Optional, DefaultParameterValue(0)] int? ShowExternal,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional, DefaultParameterValue(1)] int? ActiveStatus,
		[Optional, DefaultParameterValue(1)] int? InActiveStatus,
		[Optional, DefaultParameterValue(1)] int? CompleteStatus,
		[Optional, DefaultParameterValue(0)] int? IncludeSN,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjectPackingSlipExt = new Rpt_ProjectPackingSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectPackingSlipExt.Rpt_ProjectPackingSlipSp(PckCall,
				MinPackNum,
				MaxPackNum,
				PrintProjNotes,
				PrintResNotes,
				ShowInternal,
				ShowExternal,
				DisplayHeader,
				ActiveStatus,
				InActiveStatus,
				CompleteStatus,
				IncludeSN,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
