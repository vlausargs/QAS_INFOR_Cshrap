//PROJECT NAME: ReportExt
//CLASS NAME: SLAPPostingDraftRemittanceReport.cs

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
    [IDOExtensionClass("SLAPPostingDraftRemittanceReport")]
    public class SLAPPostingDraftRemittanceReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_APPostingDraftRemittanceSp([Optional] string BankCode,
		                                                [Optional] string VendNumStart,
		                                                [Optional] string VendNumEnd,
		                                                [Optional] byte? DisplayHeader,
		                                                [Optional] int? PStartingDraftNum,
		                                                [Optional] int? PEndingDraftNum,
		                                                [Optional] DateTime? PStartingDueDate,
		                                                [Optional] DateTime? PEndingDueDate,
		                                                [Optional] string SSessionIDChar,
		                                                [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_APPostingDraftRemittanceExt = new Rpt_APPostingDraftRemittanceFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_APPostingDraftRemittanceExt.Rpt_APPostingDraftRemittanceSp(BankCode,
				                                                                             VendNumStart,
				                                                                             VendNumEnd,
				                                                                             DisplayHeader,
				                                                                             PStartingDraftNum,
				                                                                             PEndingDraftNum,
				                                                                             PStartingDueDate,
				                                                                             PEndingDueDate,
				                                                                             SSessionIDChar,
				                                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
