//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROOnHold.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROOnHold
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROOnHoldSp(DateTime? beg_trans_date,
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
		string pSite = null);
	}
}

