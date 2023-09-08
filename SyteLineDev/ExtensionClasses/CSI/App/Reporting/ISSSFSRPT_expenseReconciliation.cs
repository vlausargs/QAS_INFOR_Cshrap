//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRPT_expenseReconciliation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRPT_expenseReconciliation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRPT_expenseReconciliationSp(string beg_pay_type,
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
		string pSite = null);
	}
}

