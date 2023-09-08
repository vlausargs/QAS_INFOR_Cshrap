//PROJECT NAME: ReportExt
//CLASS NAME: SLVATReport.cs

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
	[IDOExtensionClass("SLVATReport")]
	public class SLVATReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VATSp([Optional] int? TaxJurTaxSystem,
		[Optional] int? ExOptszShowDetail,
		[Optional] string TaxJurTaxJur,
		[Optional] DateTime? ExBegInvStaxInvDate,
		[Optional] DateTime? ExEndInvStaxInvDate,
		[Optional] int? TaxDateStartingOffset,
		[Optional] int? TaxDateEndingOffset,
		[Optional] string ExOptgoJournalId,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite,
		[Optional] string BGUser,
		[Optional] string SortBy,
		[Optional, DefaultParameterValue(0)] int? ExcludeNullLineNum,
		[Optional, DefaultParameterValue(0)] int? ExcludeJournalEntries)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VATExt = new Rpt_VATFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VATExt.Rpt_VATSp(TaxJurTaxSystem,
				ExOptszShowDetail,
				TaxJurTaxJur,
				ExBegInvStaxInvDate,
				ExEndInvStaxInvDate,
				TaxDateStartingOffset,
				TaxDateEndingOffset,
				ExOptgoJournalId,
				DisplayHeader,
				BGSessionId,
				TaskId,
				pSite,
				BGUser,
				SortBy,
				ExcludeNullLineNum,
				ExcludeJournalEntries);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
