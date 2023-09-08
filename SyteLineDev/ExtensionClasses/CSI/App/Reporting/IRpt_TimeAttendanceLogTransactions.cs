//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TimeAttendanceLogTransactions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TimeAttendanceLogTransactions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TimeAttendanceLogTransactionsSp(string ex_optdf_dc_att_stat = null,
		string ex_optdf_dcta_type = null,
		int? ex_optsz_sort_dept = null,
		string ex_optdf_dept_page = null,
		string ex_optdf_emp_page = null,
		string ex_optdf_empl_type = null,
		DateTime? ex_hbeg_trans_date = null,
		DateTime? ex_end_trans_date = null,
		int? ex_hbeg_trans_time = null,
		int? ex_end_trans_time = null,
		DateTime? ex_hbeg_post_date = null,
		DateTime? ex_end_post_date = null,
		string ex_hbeg_termid = null,
		string ex_end_termid = null,
		string ex_hbeg_emp_num = null,
		string ex_end_emp_num = null,
		string ex_hbeg_shift = null,
		string ex_end_shift = null,
		string ex_hbeg_dept = null,
		string ex_end_dept = null,
		int? StartingDateOffset = null,
		int? EndingDateOffset = null,
		int? StartingPostDateOffset = null,
		int? EndingPostDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

