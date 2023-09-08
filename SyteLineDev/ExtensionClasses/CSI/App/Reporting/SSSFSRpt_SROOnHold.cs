//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROOnHold.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROOnHold : ISSSFSRpt_SROOnHold
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROOnHold(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROOnHoldSp(DateTime? beg_trans_date,
		DateTime? end_trans_date,
		string beg_sro_num,
		string end_sro_num,
		int? beg_sro_line,
		int? end_sro_line,
		int? beg_sro_oper,
		int? end_sro_oper,
		string beg_cust_num,
		string end_cust_num,
		int? t_page,
		string pSite = null)
		{
			DateType _beg_trans_date = beg_trans_date;
			DateType _end_trans_date = end_trans_date;
			FSSRONumType _beg_sro_num = beg_sro_num;
			FSSRONumType _end_sro_num = end_sro_num;
			FSSROLineType _beg_sro_line = beg_sro_line;
			FSSROLineType _end_sro_line = end_sro_line;
			FSSROOperType _beg_sro_oper = beg_sro_oper;
			FSSROOperType _end_sro_oper = end_sro_oper;
			CustNumType _beg_cust_num = beg_cust_num;
			CustNumType _end_cust_num = end_cust_num;
			ListYesNoType _t_page = t_page;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROOnHoldSp";
				
				appDB.AddCommandParameter(cmd, "beg_trans_date", _beg_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_trans_date", _end_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_sro_num", _beg_sro_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_sro_num", _end_sro_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_sro_line", _beg_sro_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_sro_line", _end_sro_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_sro_oper", _beg_sro_oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_sro_oper", _end_sro_oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_cust_num", _beg_cust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_cust_num", _end_cust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_page", _t_page, ParameterDirection.Input);
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
