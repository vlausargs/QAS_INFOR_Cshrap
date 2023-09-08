//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TimeAttendanceLogTransactions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TimeAttendanceLogTransactions : IRpt_TimeAttendanceLogTransactions
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TimeAttendanceLogTransactions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TimeAttendanceLogTransactionsSp(string ex_optdf_dc_att_stat = null,
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
		string pSite = null)
		{
			InfobarType _ex_optdf_dc_att_stat = ex_optdf_dc_att_stat;
			InfobarType _ex_optdf_dcta_type = ex_optdf_dcta_type;
			ListYesNoType _ex_optsz_sort_dept = ex_optsz_sort_dept;
			StringType _ex_optdf_dept_page = ex_optdf_dept_page;
			StringType _ex_optdf_emp_page = ex_optdf_emp_page;
			InfobarType _ex_optdf_empl_type = ex_optdf_empl_type;
			DateTimeType _ex_hbeg_trans_date = ex_hbeg_trans_date;
			DateTimeType _ex_end_trans_date = ex_end_trans_date;
			IntType _ex_hbeg_trans_time = ex_hbeg_trans_time;
			IntType _ex_end_trans_time = ex_end_trans_time;
			DateTimeType _ex_hbeg_post_date = ex_hbeg_post_date;
			DateTimeType _ex_end_post_date = ex_end_post_date;
			DcTermIdType _ex_hbeg_termid = ex_hbeg_termid;
			DcTermIdType _ex_end_termid = ex_end_termid;
			EmpNumType _ex_hbeg_emp_num = ex_hbeg_emp_num;
			EmpNumType _ex_end_emp_num = ex_end_emp_num;
			ShiftType _ex_hbeg_shift = ex_hbeg_shift;
			ShiftType _ex_end_shift = ex_end_shift;
			DeptType _ex_hbeg_dept = ex_hbeg_dept;
			DeptType _ex_end_dept = ex_end_dept;
			DateOffsetType _StartingDateOffset = StartingDateOffset;
			DateOffsetType _EndingDateOffset = EndingDateOffset;
			DateOffsetType _StartingPostDateOffset = StartingPostDateOffset;
			DateOffsetType _EndingPostDateOffset = EndingPostDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TimeAttendanceLogTransactionsSp";
				
				appDB.AddCommandParameter(cmd, "ex_optdf_dc_att_stat", _ex_optdf_dc_att_stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_optdf_dcta_type", _ex_optdf_dcta_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_optsz_sort_dept", _ex_optsz_sort_dept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_optdf_dept_page", _ex_optdf_dept_page, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_optdf_emp_page", _ex_optdf_emp_page, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_optdf_empl_type", _ex_optdf_empl_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_hbeg_trans_date", _ex_hbeg_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_end_trans_date", _ex_end_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_hbeg_trans_time", _ex_hbeg_trans_time, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_end_trans_time", _ex_end_trans_time, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_hbeg_post_date", _ex_hbeg_post_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_end_post_date", _ex_end_post_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_hbeg_termid", _ex_hbeg_termid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_end_termid", _ex_end_termid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_hbeg_emp_num", _ex_hbeg_emp_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_end_emp_num", _ex_end_emp_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_hbeg_shift", _ex_hbeg_shift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_end_shift", _ex_end_shift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_hbeg_dept", _ex_hbeg_dept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ex_end_dept", _ex_end_dept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDateOffset", _StartingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDateOffset", _EndingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPostDateOffset", _StartingPostDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPostDateOffset", _EndingPostDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
