//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSCheckOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSCheckOper
	{
		(int? ReturnCode,
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
			decimal? o_amt);
	}
}

