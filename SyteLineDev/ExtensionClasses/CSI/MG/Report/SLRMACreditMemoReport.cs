//PROJECT NAME: ReportExt
//CLASS NAME: SLRMACreditMemoReport.cs

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
    [IDOExtensionClass("SLRMACreditMemoReport")]
    public class SLRMACreditMemoReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RMACreditMemoSp([Optional] Guid? pSessionID,
		[Optional, DefaultParameterValue("R")] string ProcessReprint,
		[Optional, DefaultParameterValue("CI")] string PrintItemCustItem,
		[Optional, DefaultParameterValue(0)] int? TPrSerialNum,
		[Optional, DefaultParameterValue(0)] int? TTransDomCurr,
		[Optional] string BCrmNum,
		[Optional] string ECrmNum,
		[Optional] DateTime? BCrmDate,
		[Optional] DateTime? ECrmDate,
		[Optional, DefaultParameterValue(0)] int? PrintOrderNotes,
		[Optional, DefaultParameterValue(0)] int? PrintRMANotes,
		[Optional, DefaultParameterValue(0)] int? PrintShipToNotes,
		[Optional, DefaultParameterValue(0)] int? PrintBillToNotes,
		[Optional, DefaultParameterValue(0)] int? ShowInternal,
		[Optional, DefaultParameterValue(0)] int? ShowExternal,
		[Optional] int? PrintItemOverview,
		[Optional, DefaultParameterValue(0)] int? PrintRMALineNotes,
		[Optional, DefaultParameterValue(1)] int? PrintLotNumbers,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RMACreditMemoExt = new Rpt_RMACreditMemoFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RMACreditMemoExt.Rpt_RMACreditMemoSp(pSessionID,
				ProcessReprint,
				PrintItemCustItem,
				TPrSerialNum,
				TTransDomCurr,
				BCrmNum,
				ECrmNum,
				BCrmDate,
				ECrmDate,
				PrintOrderNotes,
				PrintRMANotes,
				PrintShipToNotes,
				PrintBillToNotes,
				ShowInternal,
				ShowExternal,
				PrintItemOverview,
				PrintRMALineNotes,
				PrintLotNumbers,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
