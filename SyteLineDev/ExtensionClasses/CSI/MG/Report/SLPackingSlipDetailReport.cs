//PROJECT NAME: ReportExt
//CLASS NAME: SLPackingSlipDetailReport.cs

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
    [IDOExtensionClass("SLPackingSlipDetailReport")]
    public class SLPackingSlipDetailReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PackingSlipDetailSp([Optional] string OrderStarting,
		[Optional] string OrderEnding,
		[Optional] int? OrderLineStarting,
		[Optional] int? OrderLineEnding,
		[Optional] int? OrderReleaseStarting,
		[Optional] int? OrderReleaseEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? PackSlipStarting,
		[Optional] int? PackSlipEnding,
		[Optional] DateTime? PackDateStarting,
		[Optional] DateTime? PackDateEnding,
		[Optional] int? PackDateStartingOffset,
		[Optional] int? PackDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PackingSlipDetailExt = new Rpt_PackingSlipDetailFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PackingSlipDetailExt.Rpt_PackingSlipDetailSp(OrderStarting,
				OrderEnding,
				OrderLineStarting,
				OrderLineEnding,
				OrderReleaseStarting,
				OrderReleaseEnding,
				CustomerStarting,
				CustomerEnding,
				PackSlipStarting,
				PackSlipEnding,
				PackDateStarting,
				PackDateEnding,
				PackDateStartingOffset,
				PackDateEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
