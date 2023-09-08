//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROOperationCodeCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROOperationCodeCost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROOperationCodeCostSp(string beg_oper_code = null,
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
		string pSite = null);
	}
}

