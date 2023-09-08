//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROOperationCodeCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROOperationCodeCost : ISSSFSRpt_SROOperationCodeCost
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROOperationCodeCost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROOperationCodeCostSp(string beg_oper_code = null,
		string end_oper_code = null,
		string beg_sro_num = null,
		string end_sro_num = null,
		string beg_cust_num = null,
		string end_cust_num = null,
		string beg_ser_num = null,
		string end_ser_num = null,
		string beg_item = null,
		string end_item = null,
		DateTime? beg_open_date = null,
		DateTime? end_open_date = null,
		string beg_sro_type = null,
		string end_sro_type = null,
		DateTime? beg_trans_date = null,
		DateTime? end_trans_date = null,
		int? InclOpen = 1,
		int? InclClosed = 1,
		int? show_sro_notes = 1,
		int? show_oper_notes = 1,
		int? exclude_0_oper = 1,
		int? exclude_0_line = 1,
		int? include_cost = 1,
		int? t_page = 1,
		int? Internal1 = 1,
		int? External1 = 1,
		int? Internal2 = 1,
		int? External2 = 1,
		string BADInfobar = null,
		string pSite = null)
		{
			FSOperCodeType _beg_oper_code = beg_oper_code;
			FSOperCodeType _end_oper_code = end_oper_code;
			FSSRONumType _beg_sro_num = beg_sro_num;
			FSSRONumType _end_sro_num = end_sro_num;
			CustNumType _beg_cust_num = beg_cust_num;
			CustNumType _end_cust_num = end_cust_num;
			SerNumType _beg_ser_num = beg_ser_num;
			SerNumType _end_ser_num = end_ser_num;
			ItemType _beg_item = beg_item;
			ItemType _end_item = end_item;
			DateType _beg_open_date = beg_open_date;
			DateType _end_open_date = end_open_date;
			FSSROTypeType _beg_sro_type = beg_sro_type;
			FSSROTypeType _end_sro_type = end_sro_type;
			DateType _beg_trans_date = beg_trans_date;
			DateType _end_trans_date = end_trans_date;
			ListYesNoType _InclOpen = InclOpen;
			ListYesNoType _InclClosed = InclClosed;
			ListYesNoType _show_sro_notes = show_sro_notes;
			ListYesNoType _show_oper_notes = show_oper_notes;
			ListYesNoType _exclude_0_oper = exclude_0_oper;
			ListYesNoType _exclude_0_line = exclude_0_line;
			ListYesNoType _include_cost = include_cost;
			ListYesNoType _t_page = t_page;
			ListYesNoType _Internal1 = Internal1;
			ListYesNoType _External1 = External1;
			ListYesNoType _Internal2 = Internal2;
			ListYesNoType _External2 = External2;
			InfobarType _BADInfobar = BADInfobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROOperationCodeCostSp";
				
				appDB.AddCommandParameter(cmd, "beg_oper_code", _beg_oper_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_oper_code", _end_oper_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_sro_num", _beg_sro_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_sro_num", _end_sro_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_cust_num", _beg_cust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_cust_num", _end_cust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_ser_num", _beg_ser_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_ser_num", _end_ser_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_item", _beg_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_item", _end_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_open_date", _beg_open_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_open_date", _end_open_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_sro_type", _beg_sro_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_sro_type", _end_sro_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_trans_date", _beg_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_trans_date", _end_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclOpen", _InclOpen, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclClosed", _InclClosed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "show_sro_notes", _show_sro_notes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "show_oper_notes", _show_oper_notes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "exclude_0_oper", _exclude_0_oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "exclude_0_line", _exclude_0_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "include_cost", _include_cost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_page", _t_page, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Internal1", _Internal1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "External1", _External1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Internal2", _Internal2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "External2", _External2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BADInfobar", _BADInfobar, ParameterDirection.Input);
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
