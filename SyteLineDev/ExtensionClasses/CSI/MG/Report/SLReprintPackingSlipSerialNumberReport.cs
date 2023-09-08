//PROJECT NAME: ReportExt
//CLASS NAME: SLReprintPackingSlipSerialNumberReport.cs

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
	[IDOExtensionClass("SLReprintPackingSlipSerialNumberReport")]
	public class SLReprintPackingSlipSerialNumberReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ReprintPackingSlipSerialNumberSp([Optional] string PckitemCoNum,
		[Optional] int? PckitemCoLine,
		[Optional] int? PckitemCoRelease,
		[Optional] int? PckHdrPackNum,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ReprintPackingSlipSerialNumberExt = new Rpt_ReprintPackingSlipSerialNumberFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ReprintPackingSlipSerialNumberExt.Rpt_ReprintPackingSlipSerialNumberSp(PckitemCoNum,
				PckitemCoLine,
				PckitemCoRelease,
				PckHdrPackNum,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
