//PROJECT NAME: ReportExt
//CLASS NAME: CHSOutputLedgerReport.cs

using CSI.Data.SQL.UDDT;
using System;
using CSI.Data.SQL;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
	[IDOExtensionClass("CHSOutputLedgerReport")]
	public class CHSOutputLedgerReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_OutputLedgerSp([Optional] DateTime? BegTransDate,
		[Optional] DateTime? EndTransDate,
		[Optional] decimal? BegTransNum,
		[Optional] decimal? EndTransNum,
		[Optional] string JournalId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSRpt_OutputLedgerExt = new CHSRpt_OutputLedgerFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSRpt_OutputLedgerExt.CHSRpt_OutputLedgerSp(BegTransDate,
				EndTransDate,
				BegTransNum,
				EndTransNum,
				JournalId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
