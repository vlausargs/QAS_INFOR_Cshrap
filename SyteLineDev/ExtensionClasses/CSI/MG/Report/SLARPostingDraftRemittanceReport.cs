//PROJECT NAME: ReportExt
//CLASS NAME: SLARPostingDraftRemittanceReport.cs

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
    [IDOExtensionClass("SLARPostingDraftRemittanceReport")]
    public class SLARPostingDraftRemittanceReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ARPostingDraftRemittanceSp([Optional] string PSessionID,
		                                                [Optional] string StartingBankCode,
		                                                [Optional] string EndingBankCode,
		                                                [Optional] int? StartDraftNumber,
		                                                [Optional] int? EndDraftNumber,
		                                                [Optional] string RemittanceOption,
		                                                [Optional] byte? DisplayHeader,
		                                                [Optional] string Infobar,
		                                                [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ARPostingDraftRemittanceExt = new Rpt_ARPostingDraftRemittanceFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ARPostingDraftRemittanceExt.Rpt_ARPostingDraftRemittanceSp(PSessionID,
				                                                                             StartingBankCode,
				                                                                             EndingBankCode,
				                                                                             StartDraftNumber,
				                                                                             EndDraftNumber,
				                                                                             RemittanceOption,
				                                                                             DisplayHeader,
				                                                                             Infobar,
				                                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
