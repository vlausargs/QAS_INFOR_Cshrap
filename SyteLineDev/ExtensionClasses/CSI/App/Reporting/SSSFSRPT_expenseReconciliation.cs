//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRPT_expenseReconciliation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRPT_expenseReconciliation : ISSSFSRPT_expenseReconciliation
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRPT_expenseReconciliation(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRPT_expenseReconciliationSp(string beg_pay_type,
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
		string pSite = null)
		{
			FSPayTypeType _beg_pay_type = beg_pay_type;
			FSPartnerType _beg_partner_id = beg_partner_id;
			DateType _beg_trans_date = beg_trans_date;
			FSSRONumType _beg_sro_num = beg_sro_num;
			FSSROLineType _beg_sro_line = beg_sro_line;
			FSSROOperType _beg_sro_oper = beg_sro_oper;
			FSMiscCodeType _beg_misc_code = beg_misc_code;
			FSPayTypeType _end_pay_type = end_pay_type;
			FSPartnerType _end_partner_id = end_partner_id;
			DateType _end_trans_date = end_trans_date;
			FSSRONumType _end_sro_num = end_sro_num;
			FSSROLineType _end_sro_line = end_sro_line;
			FSSROOperType _end_sro_oper = end_sro_oper;
			FSMiscCodeType _end_misc_code = end_misc_code;
			ListYesNoType _ShowOpen = ShowOpen;
			ListYesNoType _ShowPartial = ShowPartial;
			ListYesNoType _ShowComplete = ShowComplete;
			ListYesNoType _ShowHold = ShowHold;
			ListYesNoType _ShowApproved = ShowApproved;
			ListYesNoType _t_page = t_page;
			ListYesNoType _t_inc_recon = t_inc_recon;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRPT_expenseReconciliationSp";
				
				appDB.AddCommandParameter(cmd, "beg_pay_type", _beg_pay_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_partner_id", _beg_partner_id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_trans_date", _beg_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_sro_num", _beg_sro_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_sro_line", _beg_sro_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_sro_oper", _beg_sro_oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_misc_code", _beg_misc_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_pay_type", _end_pay_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_partner_id", _end_partner_id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_trans_date", _end_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_sro_num", _end_sro_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_sro_line", _end_sro_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_sro_oper", _end_sro_oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_misc_code", _end_misc_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowOpen", _ShowOpen, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowPartial", _ShowPartial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowComplete", _ShowComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowHold", _ShowHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowApproved", _ShowApproved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_page", _t_page, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_inc_recon", _t_inc_recon, ParameterDirection.Input);
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
