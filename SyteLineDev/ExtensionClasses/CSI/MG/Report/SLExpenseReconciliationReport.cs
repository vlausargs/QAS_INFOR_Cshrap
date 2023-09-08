//PROJECT NAME: ReportExt
//CLASS NAME: SLExpenseReconciliationReport.cs

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
	[IDOExtensionClass("SLExpenseReconciliationReport")]
	public class SLExpenseReconciliationReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRPT_expenseReconciliationSp(string beg_pay_type,
		string beg_partner_id,
		DateTime? beg_trans_date,
		string beg_sro_num,
		int? beg_sro_line,
		int? beg_sro_oper,
		string beg_misc_code,
		string end_pay_type,
		string end_partner_id,
		DateTime? end_trans_date,
		string end_sro_num,
		int? end_sro_line,
		int? end_sro_oper,
		string end_misc_code,
		int? ShowOpen,
		int? ShowPartial,
		int? ShowComplete,
		int? ShowHold,
		int? ShowApproved,
		int? t_page,
		int? t_inc_recon,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRPT_expenseReconciliationExt = new SSSFSRPT_expenseReconciliationFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRPT_expenseReconciliationExt.SSSFSRPT_expenseReconciliationSp(beg_pay_type,
				beg_partner_id,
				beg_trans_date,
				beg_sro_num,
				beg_sro_line,
				beg_sro_oper,
				beg_misc_code,
				end_pay_type,
				end_partner_id,
				end_trans_date,
				end_sro_num,
				end_sro_line,
				end_sro_oper,
				end_misc_code,
				ShowOpen,
				ShowPartial,
				ShowComplete,
				ShowHold,
				ShowApproved,
				t_page,
				t_inc_recon,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
