//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCheckOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSCheckOper : ISSSFSCheckOper
	{
		readonly IApplicationDB appDB;
		
		public SSSFSCheckOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? o_amt) SSSFSCheckOperSp(
			string beg_sro_num,
			string end_sro_num,
			string beg_cust_num,
			string end_cust_num,
			string beg_ser_num,
			string end_ser_num,
			string beg_item,
			string end_item,
			DateTime? beg_open_date,
			DateTime? end_open_date,
			string beg_sro_type,
			string end_sro_type,
			DateTime? beg_trans_date,
			DateTime? end_trans_date,
			string sro_stat,
			int? exclude_0_oper,
			string i_oper_code,
			string i_desc,
			decimal? o_amt)
		{
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
			FSStatCodeType _sro_stat = sro_stat;
			ListYesNoType _exclude_0_oper = exclude_0_oper;
			FSOperCodeType _i_oper_code = i_oper_code;
			DescriptionType _i_desc = i_desc;
			AmountType _o_amt = o_amt;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSCheckOperSp";
				
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
				appDB.AddCommandParameter(cmd, "sro_stat", _sro_stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "exclude_0_oper", _exclude_0_oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_oper_code", _i_oper_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_desc", _i_desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_amt", _o_amt, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_amt = _o_amt;
				
				return (Severity, o_amt);
			}
		}
	}
}
