//PROJECT NAME: ReportExt
//CLASS NAME: SLEUVATReport.cs

using CSI.Data.SQL.UDDT;
using System;
using CSI.Data.RecordSets;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLEUVATReport")]
	public class SLEUVATReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ECVATsp([Optional] int? TaxJurTaxSystem,
		[Optional] int? ExOptszShowDetail,
		[Optional] string TaxJurTaxJur,
		[Optional] DateTime? ExBegInvStaxInvDate,
		[Optional] DateTime? ExEndInvStaxInvDate,
		[Optional] int? ExOptprPostTrx,
		[Optional] int? TaxDateStartingOffset,
		[Optional] int? TaxDateEndingOffset,
		[Optional] string ExOptgoJournalId,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ECVATExt = new Rpt_ECVATFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ECVATExt.Rpt_ECVATsp(TaxJurTaxSystem,
				ExOptszShowDetail,
				TaxJurTaxJur,
				ExBegInvStaxInvDate,
				ExEndInvStaxInvDate,
				ExOptprPostTrx,
				TaxDateStartingOffset,
				TaxDateEndingOffset,
				ExOptgoJournalId,
				DisplayHeader,
				BGSessionId,
				TaskId,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
