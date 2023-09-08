//PROJECT NAME: ReportExt
//CLASS NAME: SLPSTInvoicedReport.cs

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
    [IDOExtensionClass("SLPSTInvoicedReport")]
    public class SLPSTInvoicedReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PSTInvoicedSp([Optional] DateTime? SPerDate,
		[Optional] DateTime? EPerDate,
		[Optional] int? SPerDateOffSET,
		[Optional] int? EPerDateOffSET,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PSTInvoicedExt = new Rpt_PSTInvoicedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PSTInvoicedExt.Rpt_PSTInvoicedSp(SPerDate,
				EPerDate,
				SPerDateOffSET,
				EPerDateOffSET,
				DisplayHeader,
				BGSessionId,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
