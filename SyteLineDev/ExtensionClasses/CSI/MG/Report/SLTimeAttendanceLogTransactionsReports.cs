//PROJECT NAME: ReportExt
//CLASS NAME: SLTimeAttendanceLogTransactionsReports.cs

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
    [IDOExtensionClass("SLTimeAttendanceLogTransactionsReports")]
    public class SLTimeAttendanceLogTransactionsReports : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TimeAttendanceLogTransactionsSp([Optional] string ex_optdf_dc_att_stat,
		[Optional] string ex_optdf_dcta_type,
		[Optional] int? ex_optsz_sort_dept,
		[Optional] string ex_optdf_dept_page,
		[Optional] string ex_optdf_emp_page,
		[Optional] string ex_optdf_empl_type,
		[Optional] DateTime? ex_hbeg_trans_date,
		[Optional] DateTime? ex_end_trans_date,
		[Optional] int? ex_hbeg_trans_time,
		[Optional] int? ex_end_trans_time,
		[Optional] DateTime? ex_hbeg_post_date,
		[Optional] DateTime? ex_end_post_date,
		[Optional] string ex_hbeg_termid,
		[Optional] string ex_end_termid,
		[Optional] string ex_hbeg_emp_num,
		[Optional] string ex_end_emp_num,
		[Optional] string ex_hbeg_shift,
		[Optional] string ex_end_shift,
		[Optional] string ex_hbeg_dept,
		[Optional] string ex_end_dept,
		[Optional] int? StartingDateOffset,
		[Optional] int? EndingDateOffset,
		[Optional] int? StartingPostDateOffset,
		[Optional] int? EndingPostDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			var iRpt_TimeAttendanceLogTransactionsExt = new Rpt_TimeAttendanceLogTransactionsFactory().Create(this, true);
			
			var result = iRpt_TimeAttendanceLogTransactionsExt.Rpt_TimeAttendanceLogTransactionsSp(ex_optdf_dc_att_stat,
			ex_optdf_dcta_type,
			ex_optsz_sort_dept,
			ex_optdf_dept_page,
			ex_optdf_emp_page,
			ex_optdf_empl_type,
			ex_hbeg_trans_date,
			ex_end_trans_date,
			ex_hbeg_trans_time,
			ex_end_trans_time,
			ex_hbeg_post_date,
			ex_end_post_date,
			ex_hbeg_termid,
			ex_end_termid,
			ex_hbeg_emp_num,
			ex_end_emp_num,
			ex_hbeg_shift,
			ex_end_shift,
			ex_hbeg_dept,
			ex_end_dept,
			StartingDateOffset,
			EndingDateOffset,
			StartingPostDateOffset,
			EndingPostDateOffset,
			DisplayHeader,
			pSite);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

    }
}
